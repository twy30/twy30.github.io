#!/bin/bash

# Change directory to this Git repository's root path.
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"

# Create a new page from the `CopyMe.html` template.
myNewPageRelativePath=Pages/${1}.html
cp Template/CopyMe.html "${myNewPageRelativePath}"

# Open the new page in VSCode.
code "${myNewPageRelativePath}"

# Update the table of contents.
bash Template/update-index.bash

# Change directory back.
popd
