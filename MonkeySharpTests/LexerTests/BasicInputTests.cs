using MonkeySharp.Lexer;
using MonkeySharp.Tokens;
using NUnit.Framework;
using System.Collections.Generic;

namespace MonkeySharpTests.LexerTests
{
    public class BasicInputTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BasicInputTest()
        {
            var input = "=+(){},;";
            var expected = new Dictionary<TokenType, string>() {
                { TokenType.Assign, "=" },
                { TokenType.Plus, "+" },
                { TokenType.LParen, "(" },
                { TokenType.RParen, ")" },
                { TokenType.LBrace, "{" },
                { TokenType.RBrace, "}" },
                { TokenType.Comma, "," },
                { TokenType.Semicolon, ";" },
            };

            var lexer = new Lexer(input);

            foreach (var expectedToken in expected)
            {
                var token = lexer.NextToken();
                Assert.AreEqual(token.Type, expectedToken.Key);
                Assert.AreEqual(token.Literal, expectedToken.Value);
            }
        }
    }
}