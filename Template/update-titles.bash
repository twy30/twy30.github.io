#!/bin/bash

# Change directory to this Git repository's root path.
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"

# Update all pages' Markdown titles with their HTML titles.
dotnet run --project Template/Code/UpdateTitles/ -- "${myWorkspacePath}"

# Change directory back.
popd
