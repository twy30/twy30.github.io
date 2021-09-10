"use strict";

// Read Markdown-input.
var markdownInputElement = document.getElementById("Markdown-input")
var markdownInput = markdownInputElement.textContent;

// Get Markdown-to-HTML converter.
var commonmark = window.commonmark;
var markdownParser = new commonmark.Parser();
var htmlRenderer = new commonmark.HtmlRenderer();

// Write HTML-output.
var htmlOutputElement = document.getElementById("HTML-output")
var htmlOutput = htmlRenderer.render(markdownParser.parse(markdownInput));
htmlOutputElement.innerHTML = htmlOutput;

// If the code reaches here, there has not been any obvious failure.
// Now the Markdown-input element can be removed.
markdownInputElement.remove();
