using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeySharp.Tokens
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Literal { get; set; }
    }
}