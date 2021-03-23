using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeySharp.Tokens
{
    public enum TokenType
    {
        Illegal,
        Eof,

        //identifiers and literals
        Ident,

        Int,

        // operators
        Assign,

        Plus,

        // delimiters
        Comma,

        Semicolon,

        LParen,
        RParen,
        LBrace,
        RBrace,

        // keywords
        Function,

        Let,
    }
}