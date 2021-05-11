# The Right Way to Set HTML `lang`

Use an "IETF BCP 47 Language Tag".

* [2.  The Language Tag](https://www.rfc-editor.org/rfc/rfc5646.html#section-2)
* [Appendix A.  Examples of Language Tags (Informative)](https://www.rfc-editor.org/rfc/rfc5646.html#appendix-A)

## `lang`

https://www.w3.org/TR/2021/SPSD-html52-20210128/dom.html#the-lang-and-xmllang-attributes

> The lang attribute (in no namespace) specifies the primary language
> for the element’s contents and for any of the element’s attributes
> that contain text. Its value must be a valid BCP 47 language tag, or
> the empty string. Setting the attribute to the empty string indicates
> that the primary language is unknown. [BCP47]

## BCP 47

https://www.w3.org/TR/2021/SPSD-html52-20210128/references.html#biblio-bcp47

> [BCP47]
>
> A. Phillips; M. Davis. Tags for Identifying Languages. September 2009.
> IETF Best Current Practice. URL: https://tools.ietf.org/html/bcp47

## RFC 5646

https://www.rfc-editor.org/info/rfc5646

> IANA Language Subtag Registry

https://www.iana.org/assignments/language-subtag-registry/language-subtag-registry
