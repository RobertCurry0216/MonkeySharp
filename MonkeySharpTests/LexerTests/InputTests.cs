using MonkeySharp.Lexer;
using MonkeySharp.Tokens;
using NUnit.Framework;
using System.Collections.Generic;

namespace MonkeySharpTests.LexerTests
{
    public class InputTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BasicInputTest()
        {
            var input = "=+(){},;";
            var expected = new List<Token>() {
                new Token(TokenType.Assign, "=" ),
                new Token(TokenType.Plus, "+" ),
                new Token(TokenType.LParen, "(" ),
                new Token(TokenType.RParen, ")" ),
                new Token(TokenType.LBrace, "{" ),
                new Token(TokenType.RBrace,  "}" ),
                new Token(TokenType.Comma, "," ),
                new Token(TokenType.Semicolon, ";" ),
            };

            var lexer = new Lexer(input);

            foreach (var expectedToken in expected)
            {
                var token = lexer.NextToken();
                Assert.AreEqual(expectedToken.Type, token.Type);
                Assert.AreEqual(expectedToken.Literal, token.Literal);
            }
        }

        [Test]
        public void ExtendedInputTest()
        {
            var input = @"let five = 5;
                        let ten = 10;
                        let add = fn(x, y) {
                            x + y;
                        };
                        let result = add(five, ten); ";
            var expected = new List<Token>() {
                new Token( TokenType.Let, "let"),
                new Token( TokenType.Ident, "five"),
                new Token( TokenType.Assign, "="),
                new Token( TokenType.Int, "5"),
                new Token( TokenType.Semicolon, ";"),
                new Token( TokenType.Let, "let"),
                new Token( TokenType.Ident, "ten"),
                new Token( TokenType.Assign, "="),
                new Token( TokenType.Int, "10"),
                new Token( TokenType.Semicolon, ";"),
                new Token( TokenType.Let, "let"),
                new Token( TokenType.Ident, "add"),
                new Token( TokenType.Assign, "="),
                new Token( TokenType.Function, "fn"),
                new Token( TokenType.LParen, "("),
                new Token( TokenType.Ident, "x"),
                new Token( TokenType.Comma, ","),
                new Token( TokenType.Ident, "y"),
                new Token( TokenType.RParen, ")"),
                new Token( TokenType.LBrace, "{"),
                new Token( TokenType.Ident, "x"),
                new Token( TokenType.Plus, "+"),
                new Token( TokenType.Ident, "y"),
                new Token( TokenType.Semicolon, ";"),
                new Token( TokenType.RBrace, "}"),
                new Token( TokenType.Semicolon, ";"),
                new Token( TokenType.Let, "let"),
                new Token( TokenType.Ident, "result"),
                new Token( TokenType.Assign, "="),
                new Token( TokenType.Ident, "add"),
                new Token( TokenType.LParen, "("),
                new Token( TokenType.Ident, "five"),
                new Token( TokenType.Comma, ","),
                new Token( TokenType.Ident, "ten"),
                new Token( TokenType.RParen, ")"),
                new Token( TokenType.Semicolon, ";"),
                new Token( TokenType.Eof, ""),
            };

            var lexer = new Lexer(input);

            foreach (var expectedToken in expected)
            {
                var token = lexer.NextToken();
                Assert.AreEqual(expectedToken.Type, token.Type);
                Assert.AreEqual(expectedToken.Literal, token.Literal);
            }
        }
    }
}