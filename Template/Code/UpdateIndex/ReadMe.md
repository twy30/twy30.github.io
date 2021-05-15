This updates [`index.html`](../../../index.html)'s table of contents.

```Bash
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"
dotnet run --project Template/Code/UpdateIndex -- "${myWorkspacePath}"
popd
```
