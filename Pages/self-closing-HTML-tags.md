# Self-closing HTML Tags

If my understanding of
[HTML 5.2](https://www.w3.org/TR/2021/SPSD-html52-20210128/) is correct,

* Void elements (e.g. `br`, `hr`, `img`, and `input`) may be written as
  `<br>`, `<br/>`, or `<br />`.
  * The trailing slash `/` is optional for void elements.
* Foreign elements may be written as either start-end tag pairs or
  self-closing tags.
  * The trailing slash `/` is required for self-closing foreign element
    start tags.

## Void Elements

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#void-elements

> area, base, br, col, embed, hr, img, input, link, meta, param, source, track, wbr

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#writing-html-documents-elements

> Void elements can’t have any contents (since there’s no end tag, no
> content can be put between the start tag and the end tag).

## Foreign Elements

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#foreign-elements

> Elements from the MathML namespace and the SVG namespace.

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#writing-html-documents-elements

> Foreign elements whose start tag is marked as self-closing can’t have
> any contents (since, again, as there’s no end tag, no content can be
> put between the start tag and the end tag). Foreign elements whose
> start tag is not marked as self-closing can have text, character
> references, CDATA sections, other elements, and comments, but the text
> must not contain the character U+003C LESS-THAN SIGN (<) or an
> ambiguous ampersand.

## Start and End Tags

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#writing-html-documents-elements

> Foreign elements must either have a start tag and an end tag, or a
> start tag that is marked as self-closing, in which case they must not
> have an end tag.

> Void elements only have a start tag; end tags must not be specified
> for void elements.

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#start-tags

> Then, if the element is one of the void elements, or if the element is
> a foreign element, then there may be a single U+002F SOLIDUS character
> (/). This character has no effect on void elements, but on foreign
> elements it marks the start tag as self-closing.
