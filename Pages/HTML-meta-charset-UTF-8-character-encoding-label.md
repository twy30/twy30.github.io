# The Right Way to Set HTML `charset`

An example of `charset`:

```HTML
<meta charset="UTF-8">
```

I have seen `charset` set to `UTF-8`, `utf-8`, `UTF8`, or `utf8`; which
one is the right way?

# ASCII Case-Insensitive Match for Character Encoding's Label

All `UTF-8`, `utf-8`, `UTF8`, and `utf8` are right because they all are
ASCII case-insensitive matches for character encoding `UTF-8`'s labels:
`utf-8`, `utf8`.

## Character Encoding Names and Labels

https://encoding.spec.whatwg.org/commit-snapshots/75b988c17cc2b90266e69526f399c7916c3e0ef0/#names-and-labels

> Name
>
> UTF-8
>
> Labels
>
> * "unicode-1-1-utf-8"
> * "unicode11utf8"
> * "unicode20utf8"
> * "utf-8"
> * "utf8"
> * "x-unicode20utf8"

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

https://www.w3.org/TR/2021/SPSD-html52-20210128/references.html#biblio-encoding

> [ENCODING]
>
> Anne van Kesteren, Joshua Bell, Addison Phillips. Encoding. CR. URL:
> https://www.w3.org/TR/encoding/

https://www.w3.org/TR/encoding/ redirects to
https://encoding.spec.whatwg.org/ .