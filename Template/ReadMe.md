# How to Create a Page

See [`new-page.bash`](new-page.bash).

# How to Update the Table of Contents

See [`refresh-pages.bash`](refresh-pages.bash).

# How to Apply Template Changes to all Pages

See [`refresh-pages.bash`](refresh-pages.bash).

# How to Get 3rd-Party Libraries

```Bash
myWorkspacePath=$(git rev-parse --show-toplevel)
pushd "${myWorkspacePath}"

pushd Template/Theme/
# Bootstrap: https://github.com/twbs/bootstrap/tags
curl  --remote-name --url https://raw.githubusercontent.com/twbs/bootstrap/v5.0.1/dist/js/bootstrap.bundle.min.js
# Bootswatch: https://github.com/thomaspark/bootswatch/tags
curl  --remote-name --url https://raw.githubusercontent.com/thomaspark/bootswatch/v5.0.1/dist/cyborg/bootstrap.min.css
popd

pushd Template/Markdown-to-HTML/
# CommonMark: https://github.com/commonmark/commonmark.js/tags
curl  --remote-name --url https://raw.githubusercontent.com/commonmark/commonmark.js/0.29.3/dist/commonmark.min.js
popd

popd
```

## [Highlight.js](https://github.com/highlightjs/highlight.js/tags)

[`/Template/Syntax-Highlighting/highlight.min.js`](Syntax-Highlighting/highlight.min.js)
is a custom-built, slim version of Highlight.js.  See
[How to Build Highlight.js](https://www.twy30.com/Pages/Highlight.js-build.html)
for more details.
