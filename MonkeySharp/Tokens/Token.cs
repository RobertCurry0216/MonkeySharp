using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeySharp.Tokens
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Literal { get; set; }

        public Token(TokenType tokenType, string literal)
        {
            Type = tokenType;
            Literal = literal;
        }

        public override string ToString()
        {
            return $"{Type} : {Literal}";
        }
    }
}