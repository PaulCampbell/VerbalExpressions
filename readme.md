# VerbalExpression

VerbalExpressions is a fluent regular expression builder for .net, heavily inspired by the wonderful 
looking (haven't used it, but clearly the best idea ever!) [Verbal Expressions javascript library](https://github.com/jehna/VerbalExpressions).  

## How it works...

Add VerbalExpressions to your project:

	Install-Package VerbalExpressions

Check the tests for example uses, but the basics:

    var urlRegex = new VerbalExpression()
		.StartOfLine()
		.Then("http")
		.Maybe("s")
		.Then("://")
		.Anything()
		.EndOfLine();

		urlRegex.Test("http://www.google.com").ShouldBe(true);

		urlRegex.Test("https://www.google.com").ShouldBe(true);

		urlRegex.Test("httpT://www.google.com").ShouldBe(false);

		urlRegex.Test("google.com").ShouldBe(false);

### Interface

	- .StartOfLine()  start the regex 					`_regex = "^";`
	- .Then(string match)  Followed by this string  	`_regex = _regex + match;`
	- .Anything() Followed by anything 					`_regex = _regex + "(.|\n)*";`
	- .AnythingBut(string stringToExclude)				`_regex = _regex + string.Format("(?!{0})(.|\n)*", stringToExclude);`
	- .Maybe(string optionalPart) Possibly followed by	`_regex = _regex + string.Format("({0})?", optionalPart);`
	- .EndOfLine() End of line :)						`_regex = _regex + "$";`

## Todo:
Some things to consider... Maybe best to add these as the usecases arise in real projects - don't want this api getting out of hand from the get go! 
 - Do something with correct case / IgnoreCase
 - Anything overloads with min, max characters??? perhaps .Anything(int minChars) and .Anything(int minChars, int maxChars)
 - Anything overloads with TYPES??? perhaps .Anything(Type Int) or whatever...
 

