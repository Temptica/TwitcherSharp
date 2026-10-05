#!/usr/bin/env bash
# Runs the GoDotTest suites headless and checks the run is complete.
#
#   ./run-tests.sh                    all suites
#   ./run-tests.sh ChatMessageTest    one suite (or Suite.Method)
#
# Needs a .NET build of Godot (GODOT_BIN, default godot) and the Twitch CLI on PATH (or TWITCH_CLI) for the mock API.
# twitcher is fetched with fetch-twitcher.sh when addons/twitcher is missing; run that script to update it. The run
# fails when a test fails, when fewer tests ran than were discovered (an exception on the finalizer thread ends a run
# early), when Godot exits non-zero (a crash on exit means a leaked handle) or when the log holds a SCRIPT ERROR.
# TIMEOUT_SEC (default 600) limits the run.
set -uo pipefail
cd "$(dirname "$0")"

godot="${GODOT_BIN:-godot}"
tests="${1:-}"
timeout_sec="${TIMEOUT_SEC:-600}"
log="${TMPDIR:-/tmp}/twitchersharp-tests.log"

windows=false
case "$(uname -s)" in MINGW* | MSYS* | CYGWIN*) windows=true ;; esac

# On Windows the console build forwards stdout; the GUI build does not.
if [[ "$godot" == *.exe && -f "${godot%.exe}.console.exe" ]]; then godot="${godot%.exe}.console.exe"; fi

fail() { echo "FAILED: $*" >&2; exit 1; }

command -v "$godot" > /dev/null || fail "no Godot at '$godot'; set GODOT_BIN to a .NET build of Godot"

if [[ ! -f addons/twitcher/plugin.cfg ]]; then ./fetch-twitcher.sh || fail "could not fetch twitcher"; fi

dotnet build --nologo -v q -clp:ErrorsOnly || fail "build failed"
"$godot" --headless --path . --import > /dev/null 2>&1

# Kills a process and its children: Godot starts the Twitch mock, which must not outlive a hung run.
kill_tree() {
    if $windows; then
        taskkill //T //F //PID "$(cat "/proc/$1/winpid")" > /dev/null 2>&1
    else
        local child
        for child in $(pgrep -P "$1"); do kill_tree "$child"; done
        kill -9 "$1" 2> /dev/null
    fi
}

"$godot" --headless --path . "--run-tests${tests:+=$tests}" --quit-on-finish > "$log" 2>&1 &
pid=$!
for ((waited = 0; waited < timeout_sec; waited++)); do
    kill -0 "$pid" 2> /dev/null || break
    sleep 1
done
if kill -0 "$pid" 2> /dev/null; then
    kill_tree "$pid"
    fail "timed out after $timeout_sec s; see $log"
fi
wait "$pid"
exit_code=$?

grep -E 'GoTest\)|Discovered tests|SCRIPT ERROR|^\s+at ' "$log"

discovered=$(grep -oE 'Discovered tests: [0-9]+' "$log" | tail -1 | grep -oE '[0-9]+')
summary=$(grep -oE 'Passed: [0-9]+ \| Failed: [0-9]+ \| Skipped: [0-9]+' "$log" | tail -1)
script_errors=$(grep -c 'SCRIPT ERROR' "$log")

problems=()
[[ -n "$discovered" ]] || problems+=("no discovered count")
if [[ -z "$summary" ]]; then
    problems+=("no result summary (the run ended early)")
else
    read -r passed failed skipped <<< "$(grep -oE '[0-9]+' <<< "$summary" | tr '\n' ' ')"
    ran=$((passed + failed + skipped))
    echo "Discovered: $discovered, ran: $ran (passed $passed, failed $failed, skipped $skipped)"
    [[ "$ran" == "$discovered" ]] || problems+=("ran $ran of $discovered discovered tests")
    ((failed == 0)) || problems+=("$failed failed")
fi
((exit_code == 0)) || problems+=("Godot exited with $exit_code")
((script_errors == 0)) || problems+=("$script_errors SCRIPT ERROR(s) in the log")

echo "Exit code: $exit_code. Full log: $log"
if ((${#problems[@]} > 0)); then
    fail "$(printf '%s; ' "${problems[@]}" | sed 's/; $//')"
fi
echo "OK"
