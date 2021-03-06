#!/bin/bash

# Change directory to this Git repository's root path.
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"

# Update the table of contents.
bash Template/update-index.bash

# Apply template changes to all pages.
bash Template/update-pages.bash

# Update all pages' Markdown titles with their HTML titles.
bash Template/update-titles.bash

# List changed pages.
git status

# Change directory back.
popd
