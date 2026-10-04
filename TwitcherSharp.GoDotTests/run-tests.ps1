# Runs the GoDotTest suites headless and checks the run is complete.
#
#   ./run-tests.ps1                       all suites
#   ./run-tests.ps1 -Tests ChatMessageTest one suite (or Suite.Method)
#
# Needs a .NET build of Godot (GODOT_BIN or -Godot), twitcher linked into addons/twitcher (link-twitcher.ps1) and the
# Twitch CLI on PATH (or TWITCH_CLI) for the mock API. The run fails when a test fails, when fewer tests ran than were
# discovered (an exception on the finalizer thread ends a run early), when Godot exits non-zero (a crash on exit means
# a leaked handle) or when the log holds a SCRIPT ERROR.
param(
    [string]$Godot = $(if ($env:GODOT_BIN) { $env:GODOT_BIN } else { 'godot' }),
    [string]$Tests = '',
    [int]$TimeoutSec = 600
)

$ErrorActionPreference = 'Stop'
Set-Location $PSScriptRoot

# The console build forwards stdout; the GUI build does not.
$console = $Godot -replace '\.exe$', '.console.exe'
if ((Test-Path $console) -and $console -ne $Godot) { $Godot = $console }

if (-not (Test-Path 'addons/twitcher/plugin.cfg')) { throw 'addons/twitcher is missing; run link-twitcher.ps1 first.' }

# Native tools write to stderr; Windows PowerShell 5.1 would turn that into terminating errors.
$ErrorActionPreference = 'Continue'

dotnet build --nologo -v q -clp:ErrorsOnly
if ($LASTEXITCODE -ne 0) { throw 'Build failed.' }

& $Godot --headless --path . --import 2>&1 | Out-Null

$log = Join-Path ([IO.Path]::GetTempPath()) 'twitchersharp-tests.log'
$runArg = if ($Tests) { "--run-tests=$Tests" } else { '--run-tests' }
$process = Start-Process -FilePath $Godot -ArgumentList '--headless', '--path', '.', $runArg, '--quit-on-finish' `
    -NoNewWindow -PassThru -RedirectStandardOutput $log -RedirectStandardError "$log.err"
$null = $process.Handle # without a cached handle ExitCode stays empty
if (-not $process.WaitForExit($TimeoutSec * 1000)) {
    $process.Kill()
    throw "Timed out after $TimeoutSec s; see $log"
}
$exitCode = $process.ExitCode
$output = (Get-Content $log) + (Get-Content "$log.err")
$output | Where-Object { $_ -match 'GoTest\)|Discovered tests|SCRIPT ERROR|Error \(GoTest\)|^\s+at ' } | Write-Host

$discovered = ($output | Select-String 'Discovered tests: (\d+)' | Select-Object -Last 1).Matches.Groups[1].Value
$summary = ($output | Select-String 'Passed: (\d+) \| Failed: (\d+) \| Skipped: (\d+)' | Select-Object -Last 1)
$scriptErrors = @($output | Select-String 'SCRIPT ERROR').Count

$problems = @()
if (-not $discovered) { $problems += 'no discovered count' }
if (-not $summary) {
    $problems += 'no result summary (the run ended early)'
} else {
    $passed, $failed, $skipped = $summary.Matches.Groups[1..3] | ForEach-Object { [int]$_.Value }
    $ran = $passed + $failed + $skipped
    Write-Host "Discovered: $discovered, ran: $ran (passed $passed, failed $failed, skipped $skipped)"
    if ($ran -ne [int]$discovered) { $problems += "ran $ran of $discovered discovered tests" }
    if ($failed -gt 0) { $problems += "$failed failed" }
}
if ($exitCode -ne 0) { $problems += "Godot exited with $exitCode" }
if ($scriptErrors -gt 0) { $problems += "$scriptErrors SCRIPT ERROR(s) in the log" }

Write-Host "Exit code: $exitCode. Full log: $log"
if ($problems) {
    Write-Host "FAILED: $($problems -join '; ')" -ForegroundColor Red
    exit 1
}
Write-Host 'OK' -ForegroundColor Green
