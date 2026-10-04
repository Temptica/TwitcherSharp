# Links a twitcher checkout into this test project as addons/twitcher (a directory junction, no admin rights needed).
# The tests target twitcher 2.5.1; pass the addon folder of a checkout at that version.
param(
    [string]$TwitcherAddon = (Join-Path $PSScriptRoot '..\..\twitcher\addons\twitcher')
)

$ErrorActionPreference = 'Stop'
$target = (Resolve-Path $TwitcherAddon).Path
$link = Join-Path $PSScriptRoot 'addons\twitcher'

if (Test-Path $link) {
    $item = Get-Item $link -Force
    if ($item.LinkType -ne 'Junction' -and $item.LinkType -ne 'SymbolicLink') {
        throw "$link exists and is not a link; move it away first."
    }
    $item.Delete()
}

New-Item -ItemType Directory -Force (Split-Path $link) | Out-Null
New-Item -ItemType Junction -Path $link -Target $target | Out-Null
$version = (Select-String -Path (Join-Path $link 'plugin.cfg') -Pattern '^version=').Line
Write-Host "Linked $link -> $target ($version)"
