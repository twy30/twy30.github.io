# How to Create a Page

1. Copy the [`CopyMe.html`](CopyMe.html) template to the
   [`Pages`](../Pages) directory.
2. Edit the copied template to customize it.
   * Filename
   * HTML `lang`
   * HTML `title`
   * HTML `textarea`

# How to Update the Table of Contents

```Bash
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"
dotnet run --project Template/Code/UpdateIndex -- "${myWorkspacePath}"
popd
```

# How to Apply Template Changes to all Pages

```Bash
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"
dotnet run --project Template/Code/UpdatePages -- "${myWorkspacePath}"
popd
```
