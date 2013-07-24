using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Shouldly;

namespace VerbalExpressions.Tests
{
    [TestFixture]
    public class BasicMatching
    {
        [Test]
        public void Matches_StartsWith_Positive()
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
        public void Matches_StartsWith_Negative()
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
    }
}
