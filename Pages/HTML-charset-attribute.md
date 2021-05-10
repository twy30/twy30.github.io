# HTML `charset` Attribute

If my understanding of
[HTML 5.2](https://www.w3.org/TR/2021/SPSD-html52-20210128/) is correct,

* `utf-8` and `utf8` are labels of the UTF-8.
  * Label-matching is "ASCII case-insensitive".

## `charset`

https://www.w3.org/TR/2021/SPSD-html52-20210128/document-metadata.html#the-meta-element

> The charset attribute specifies the character encoding used by the
> document. This is a character encoding declaration. If the attribute
> is present in an XML document, its value must be an ASCII
> case-insensitive match for the string "utf-8" (and the document is
> therefore forced to use UTF-8 as its encoding).

## Character Encoding

https://www.w3.org/TR/2021/SPSD-html52-20210128/document-metadata.html#specifying-the-documents-character-encoding

> The character encoding name given must be an ASCII case-insensitive
> match for one of the labels of the character encoding used to
> serialize the file. [ENCODING]

https://www.w3.org/TR/encoding/

https://encoding.spec.whatwg.org/#names-and-labels

> Name UTF-8
>
> Labels "utf-8" "utf8"
