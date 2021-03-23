using MonkeySharp.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeySharp.Lexer
{
    public class Lexer
    {
        #region properties

        /// <summary>
        /// input code as a string
        /// </summary>
        private string Input { get; set; }

        /// <summary>
        /// current reading position in input
        /// points to current char
        /// </summary>
        private int Position { get; set; }

        /// <summary>
        /// current reading position in input
        /// after the current char
        /// </summary>
        private int ReadPosition { get; set; }

        /// <summary>
        /// current char under examination
        /// </summary>
        private char Char { get; set; }

        #endregion properties

        public Lexer(string input)
        {
            Input = input;
            ReadChar();
        }

        #region Private Methods

        private void ReadChar()
        {
            if (ReadPosition >= Input.Length)
            {
                Char = '\0';
            }
            else
            {
                Char = Input[ReadPosition];
            }
            Position = ReadPosition;
            ReadPosition++;
        }

        private void SkipWhitespace()
        {
            while (char.IsWhiteSpace(Char))
            {
                ReadChar();
            }
        }

        private bool IsLetter(char input)
        {
            return char.IsLetter(input) || input == '_';
        }

        private bool IsDigit(char input)
        {
            return char.IsDigit(input);
        }

        private string ReadIdentifier()
        {
            var startPos = Position;
            while (IsLetter(Char))
            {
                ReadChar();
            }
            return Input.Substring(startPos, Position - startPos);
        }

        private string ReadNumber()
        {
            var startPos = Position;
            while (IsDigit(Char))
            {
                ReadChar();
            }
            return Input.Substring(startPos, Position - startPos);
        }

        #endregion Private Methods

        #region public Methods

        public Token NextToken()
        {
            Token token;

            SkipWhitespace();

            switch (Char)
            {
                case '=': token = new Token(TokenType.Assign, Char.ToString()); break;
                case '+': token = new Token(TokenType.Plus, Char.ToString()); break;
                case '(': token = new Token(TokenType.LParen, Char.ToString()); break;
                case ')': token = new Token(TokenType.RParen, Char.ToString()); break;
                case '{': token = new Token(TokenType.LBrace, Char.ToString()); break;
                case '}': token = new Token(TokenType.RBrace, Char.ToString()); break;
                case ',': token = new Token(TokenType.Comma, Char.ToString()); break;
                case ';': token = new Token(TokenType.Semicolon, Char.ToString()); break;
                case '\0': token = new Token(TokenType.Eof, ""); break;
                default:
                    if (IsLetter(Char))
                    {
                        var literal = ReadIdentifier();
                        var tokenType = Keywords.LookupType(literal);
                        token = new Token(tokenType, literal);
                        return token;
                    }
                    else if (IsDigit(Char))
                    {
                        var literal = ReadNumber();
                        var tokenType = TokenType.Int;
                        token = new Token(tokenType, literal);
                        return token;
                    }
                    else
                    {
                        token = new Token(TokenType.Illegal, Char.ToString());
                    }
                    break;
            }

            ReadChar();
            return token;
        }

        #endregion public Methods
    }
}