# The Right Way to Use HTML Self-Closing Tags

I have seen the `br` element written as `<br>`, `<br/>`, and `<br />`;
which way is the right way?

All `<br>`, `<br/>`, and `<br />` are right.  However, technically they
are not self-closing tags because:

* `br` is a void element.
  * A void element has a start tag but no end tag.
  * The `/` is optional.
* A foreign element can be written as either a start-end tag pair or a
  self-closing tag.

## Void Elements

The `br` element is one of the
[void elements](https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#void-elements)
.

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#writing-html-documents-elements

> Void elements only have a start tag; end tags must not be specified
> for void elements.

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#writing-html-documents-elements

> Void elements can’t have any contents (since there’s no end tag, no
> content can be put between the start tag and the end tag).

## Foreign Elements

[Foreign elements](https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#foreign-elements)
can be written as either start-end tag pairs or self-closing tags; the
`/` is required for self-closing tags.

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#writing-html-documents-elements

> Foreign elements must either have a start tag and an end tag, or a
> start tag that is marked as self-closing, in which case they must not
> have an end tag.

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#writing-html-documents-elements

> Foreign elements whose start tag is marked as self-closing can’t have
> any contents (since, again, as there’s no end tag, no content can be
> put between the start tag and the end tag). Foreign elements whose
> start tag is not marked as self-closing can have text, character
> references, CDATA sections, other elements, and comments, but the text
> must not contain the character U+003C LESS-THAN SIGN (<) or an
> ambiguous ampersand.

## Start Tags

https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#start-tags

> Then, if the element is one of the void elements, or if the element is
> a foreign element, then there may be a single U+002F SOLIDUS character
> (/). This character has no effect on void elements, but on foreign
> elements it marks the start tag as self-closing.
