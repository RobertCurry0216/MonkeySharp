using MonkeySharp.Tokens;
using System;
using System.Collections.Generic;
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
        private char? Char { get; set; }

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
                Char = null;
            }
            else
            {
                Char = Input[ReadPosition];
            }
            Position = ReadPosition;
            ReadPosition++;
        }

        #endregion Private Methods

        #region public Methods

        public Token NextToken()
        {
            Token token;
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
                case null: token = new Token(TokenType.Eof, ""); break;
                default:
                    throw new Exception($"Unknown Token encountered: {Char}");
            }

            ReadChar();
            return token;
        }

        #endregion public Methods
    }
}