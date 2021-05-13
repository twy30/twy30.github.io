This updates [`index.html`](../../index.html) and
[`Pages/*.html`](../../Pages) with the [`CopyMe.html`](../CopyMe.html)
template.

```Bash
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"
dotnet run --project Template/UpdatePages -- "${myWorkspacePath}"
popd
```
