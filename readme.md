# VerbalExpression

VerbalExpressions is a fluent regular expression builder for .net, heavily inspired by the wonderful 
looking (haven't used it, but clearly the best idea ever!) [Verbal Expressions javascript library](https://github.com/jehna/VerbalExpressions).  

## How it works...

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



## Todo:
 - Lots and lots of stuff - I just started.

