#!/usr/bin/env bash
# Puts twitcher into this test project as addons/twitcher.
#
#   ./fetch-twitcher.sh                                   clone, or update, the head of a twitcher branch
#   TWITCHER_PATH=../../twitcher/addons/twitcher ./fetch-twitcher.sh   use the addon of a local checkout instead
#
# TWITCHER_REPO (default kanimaru/twitcher on GitHub) and TWITCHER_BRANCH (default master) choose what is cloned.
# The clone is a shallow, sparse checkout of addons/twitcher in .twitcher/ (gitignored, and ignored by Godot).
# addons/twitcher links to the addon: a symbolic link, or a directory junction on Windows (Git Bash), which needs no
# admin rights.
set -euo pipefail
cd "$(dirname "$0")"

repo="${TWITCHER_REPO:-https://github.com/kanimaru/twitcher.git}"
branch="${TWITCHER_BRANCH:-master}"
clone=".twitcher"
link="addons/twitcher"

windows=false
case "$(uname -s)" in MINGW* | MSYS* | CYGWIN*) windows=true ;; esac

if [[ -n "${TWITCHER_PATH:-}" ]]; then
    target="$(cd "$TWITCHER_PATH" && pwd)"
else
    if [[ -d "$clone/.git" ]]; then
        git -C "$clone" remote set-url origin "$repo"
        git -C "$clone" fetch --quiet --depth 1 origin "$branch"
        git -C "$clone" checkout --quiet --force --detach FETCH_HEAD
    else
        rm -rf "$clone"
        git clone --quiet --depth 1 --branch "$branch" --filter=blob:none --sparse "$repo" "$clone"
        git -C "$clone" sparse-checkout set addons/twitcher
    fi
    # The clone holds a second copy of the addon under the project; Godot must not import it.
    touch "$clone/.gdignore"
    target="$(cd "$clone/addons/twitcher" && pwd)"
    echo "twitcher $branch at $(git -C "$clone" rev-parse --short HEAD)"
fi

# Replace an earlier link, never a real folder.
if [[ -L "$link" ]]; then
    if $windows; then cmd //c rmdir "$(cygpath -w "$link")" > /dev/null; else rm "$link"; fi
elif [[ -e "$link" ]]; then
    echo "$link exists and is not a link; move it away first." >&2
    exit 1
fi

mkdir -p "$(dirname "$link")"
if $windows; then
    cmd //c mklink //J "$(cygpath -w "$link")" "$(cygpath -w "$target")" > /dev/null
else
    ln -s "$target" "$link"
fi
echo "Linked $link -> $target ($(grep '^version=' "$link/plugin.cfg"))"
