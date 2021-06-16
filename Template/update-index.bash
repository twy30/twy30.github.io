#!/bin/bash

# Change directory to this Git repository's root path.
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"

# Update the table of contents.
dotnet run --project Template/Code/UpdateIndex/ -- "${myWorkspacePath}"

# Change directory back.
popd
