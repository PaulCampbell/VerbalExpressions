using NUnit.Framework;
using Shouldly;

namespace VerbalExpressions.Tests
{
    [TestFixture]
    public class BasicMatching
    {
        [Test]
        public void Matches_Then_Positive()
        {
            var urlRegex = new VerbalExpression()
            .StartOfLine()
            .Then("http")
            .Anything()
            .EndOfLine();

            var url = "http://www.google.com";

            urlRegex.Test(url).ShouldBe(true);
        }

        [Test]
        public void Matches_Then_Negative()
        {
            var urlRegex = new VerbalExpression()
            .StartOfLine()
            .Then("http")
            .Anything()
            .EndOfLine();

            var url = "not a url";

            urlRegex.Test(url).ShouldBe(false);
        }

        [Test]
        public void Matches_ChainedThen_Positive()
        {
            var urlRegex = new VerbalExpression()
            .StartOfLine()
            .Then("http")
            .Then("://")
            .Anything()
            .EndOfLine();

            var url = "http://www.google.com";

            urlRegex.Test(url).ShouldBe(true);
        }

        [Test]
        public void Matches_ChainedThen_Negative()
        {
            var urlRegex = new VerbalExpression()
            .StartOfLine()
            .Then("http")
            .Then("somethingelse")
            .Anything()
            .EndOfLine();

            var url = "http://www.google.com";

            urlRegex.Test(url).ShouldBe(false);
        }


        [Test]
        public void Matches_Maybe_Positive()
        {
            var urlRegex = new VerbalExpression()
            .StartOfLine()
            .Then("http")
            .Maybe("s")
            .Then("://")
            .Anything()
            .EndOfLine();

            var withoutMaybeUrl = "http://www.google.com";
            urlRegex.Test(withoutMaybeUrl).ShouldBe(true);

            var withMaybeUrl = "https://www.google.com";
            urlRegex.Test(withMaybeUrl).ShouldBe(true);
        }

        [Test]
        public void Matches_Maybe_Negative()
        {
            var urlRegex = new VerbalExpression()
            .StartOfLine()
            .Then("http")
            .Maybe("s")
            .Then("://")
            .Anything()
            .EndOfLine();

            var withMaybeUrl = "httpT://www.google.com";
            urlRegex.Test(withMaybeUrl).ShouldBe(false);
        }

        [Test]
        public void Matches_AnythingBut_Positive()
        {
            var urlRegex = new VerbalExpression()
            .StartOfLine()
            .Then("http://")
            .AnythingBut("google")
            .EndOfLine();

            var anythingButUrl = "http://google.com";
            urlRegex.Test(anythingButUrl).ShouldBe(false);
        }

        [Test]
        public void Matches_AnythingBut_Negative()
        {
            var urlRegex = new VerbalExpression()
            .StartOfLine()
            .Then("http://")
            .AnythingBut("somethingelse.com")
            .EndOfLine();

            var anythingButUrl = "http://google.com";
            urlRegex.Test(anythingButUrl).ShouldBe(true);
        }

        [Test]
        public void Matches_EndsWith_Positive()
        {
            var urlRegex = new VerbalExpression()
              .StartOfLine()
              .Then("http://")
              .Anything()
              .Then(".co")
              .EndOfLine();

            var dotCoUrl = "http://google.co";
            urlRegex.Test(dotCoUrl).ShouldBe(true);
        }

        [Test]
        public void Matches_EndsWith_Negative()
        {
            var urlRegex = new VerbalExpression()
              .StartOfLine()
              .Then("http://")
              .Anything()
              .Then(".co")
              .EndOfLine();

            var coUkUrl = "http://google.co.uk";
            urlRegex.Test(coUkUrl).ShouldBe(false);
        }

    }
}
