using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeySharp.Tokens
{
    public static class Keywords
    {
        private static Dictionary<string, TokenType> keywords = new Dictionary<string, TokenType>() {
                {"fn", TokenType.Function },
                {"let", TokenType.Let },
                {"if", TokenType.If },
                {"else", TokenType.Else },
                {"return", TokenType.Return },
                {"true", TokenType.True },
                {"false", TokenType.False },
            };

        public static TokenType LookupType(string ident)
        {
            if (keywords.ContainsKey(ident)) return keywords[ident];
            return TokenType.Ident;
        }
    }
}