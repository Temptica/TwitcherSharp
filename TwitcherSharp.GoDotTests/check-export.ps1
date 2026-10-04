# Builds this project as a consumer of TwitcherSharp in the ExportRelease configuration Godot exports with, and fails
# when the output carries the editor assembly: a game must not ship GodotSharpEditor.dll.
$ErrorActionPreference = 'Continue'
Set-Location $PSScriptRoot

$output = Join-Path ([IO.Path]::GetTempPath()) 'twitchersharp-export-check'
if (Test-Path $output) { Remove-Item $output -Recurse -Force }

dotnet build --nologo -v q -clp:ErrorsOnly -c ExportRelease -o $output
if ($LASTEXITCODE -ne 0) { throw 'ExportRelease build failed.' }

$editor = @(Get-ChildItem $output -Recurse -Filter 'GodotSharpEditor*.dll')
Write-Host "TwitcherSharp.dll in output: $([bool](Get-ChildItem $output -Recurse -Filter 'TwitcherSharp.dll'))"
if ($editor.Count -gt 0) {
    Write-Host "FAILED: editor assembly in the ExportRelease output: $($editor.FullName -join ', ')" -ForegroundColor Red
    exit 1
}
Write-Host 'OK: no GodotSharpEditor.dll in the ExportRelease output' -ForegroundColor Green
