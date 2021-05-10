# HTML `lang` Attribute

If my understanding of
[HTML 5.2](https://www.w3.org/TR/2021/SPSD-html52-20210128/) is correct,
the list of valid language tags is this:
https://www.iana.org/assignments/language-subtag-registry/language-subtag-registry
.

## `lang`

https://www.w3.org/TR/2021/SPSD-html52-20210128/dom.html#the-lang-and-xmllang-attributes

> The lang attribute (in no namespace) specifies the primary language
> for the element’s contents and for any of the element’s attributes
> that contain text. Its value must be a valid BCP 47 language tag, or
> the empty string. Setting the attribute to the empty string indicates
> that the primary language is unknown. [BCP47]

## RFC 5646, BCP 47

https://www.rfc-editor.org/info/rfc5646

> IANA Language Subtag Registry

> A complete list of approved registration forms is online through
> http://www.iana.org; readers should note that the Language Tag
> Registry is now obsolete and should instead look for the Language
> Subtag Registry.
