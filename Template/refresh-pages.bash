#!/bin/bash

# Change directory to this Git repository's root path.
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"

# Apply template changes to all pages.
dotnet run --project Template/Code/UpdatePages/ -- "${myWorkspacePath}"

# Update the table of contents.
dotnet run --project Template/Code/UpdateIndex/ -- "${myWorkspacePath}"

# List changed pages.
git status

# Change directory back.
popd
