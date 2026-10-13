#!/usr/bin/env bash
# Builds this project as a consumer of TwitcherSharp in the ExportRelease configuration Godot exports with, and fails
# when the output carries the editor assembly: a game must not ship GodotSharpEditor.dll.
set -euo pipefail
cd "$(dirname "$0")"

output="${TMPDIR:-/tmp}/twitchersharp-export-check"
rm -rf "$output"

dotnet build --nologo -v q -clp:ErrorsOnly -c ExportRelease -o "$output" || { echo "FAILED: ExportRelease build failed" >&2; exit 1; }

[[ -n "$(find "$output" -name TwitcherSharp.dll)" ]] || { echo "FAILED: no TwitcherSharp.dll in the output" >&2; exit 1; }
editor=$(find "$output" -name 'GodotSharpEditor*.dll')
if [[ -n "$editor" ]]; then
    echo "FAILED: editor assembly in the ExportRelease output: $editor" >&2
    exit 1
fi
echo "OK: no GodotSharpEditor.dll in the ExportRelease output"
