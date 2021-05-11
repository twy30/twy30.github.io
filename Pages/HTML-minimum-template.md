# The Minimum HTML Template

```HTML
<!DOCTYPE html>
<title></title>
```

## `DOCTYPE`

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#the-doctype

> A DOCTYPE is a required preamble.

## `html`

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#optional-tags

> An html element’s start tag may be omitted if the first thing inside
> the html element is not a comment.

> An html element’s end tag may be omitted if the html element is not
> immediately followed by a comment.

## `head`

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#optional-tags

> A head element’s start tag may be omitted if the element is empty, or
> if the first thing inside the head element is an element.

> A head element’s end tag may be omitted if the head element is not
> immediately followed by a space character or a comment.

## `title`

https://www.w3.org/TR/2021/SPSD-html52-20210128/document-metadata.html#the-head-element

> If the document is an iframe srcdoc document or if title information
> is available from a higher-level protocol: Zero or more elements of
> metadata content, of which no more than one is a title element and no
> more than one is a base element.
>
> Otherwise: One or more elements of metadata content, of which exactly
> one is a title element and no more than one is a base element.

## `body`

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#optional-tags

> A body element’s start tag may be omitted if the element is empty, or
> if the first thing inside the body element is not a space character or
> a comment, except if the first thing inside the body element is a
> meta, link, script, style, or template element.

> A body element’s end tag may be omitted if the body element is not
> immediately followed by a comment.