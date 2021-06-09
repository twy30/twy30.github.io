# How to Create a Page

1. Copy the [`CopyMe.html`](CopyMe.html) template to the
   [`Pages`](../Pages) directory.

```Bash
cp Template/CopyMe.html Pages/
```

2. Edit the copied template to customize it.
   * Filename
   * HTML `lang`
   * HTML `title`
   * HTML `textarea`

# How to Update the Table of Contents

```Bash
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"
dotnet run --project Template/Code/UpdateIndex/ -- "${myWorkspacePath}"
popd
```

# How to Apply Template Changes to all Pages

```Bash
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"
dotnet run --project Template/Code/UpdatePages/ -- "${myWorkspacePath}"
popd
```

# How to Get Third-Party Libraries

## [Bootstrap](https://github.com/twbs/bootstrap/tags)

```Bash
pushd Template/Theme/
curl  --remote-name --url https://raw.githubusercontent.com/twbs/bootstrap/v5.0.1/dist/js/bootstrap.bundle.min.js
popd
```

## [Bootswatch](https://github.com/thomaspark/bootswatch/tags)

```Bash
pushd Template/Theme/
curl  --remote-name --url https://raw.githubusercontent.com/thomaspark/bootswatch/v5.0.1/dist/cyborg/bootstrap.min.css
popd
```

## [CommonMark](https://github.com/commonmark/commonmark.js/tags)

```Bash
pushd Template/Markdown-to-HTML/
curl  --remote-name --url https://raw.githubusercontent.com/commonmark/commonmark.js/0.29.3/dist/commonmark.min.js
popd
```

## [Highlight.js](https://github.com/highlightjs/highlight.js/tags)

`Template/Syntax-Highlighting/highlight.min.js` is a custom-built, slim
version of Highlight.js.  See
[How to Build Highlight.js](../Pages/Highlight.js-build.html) for more
details.
