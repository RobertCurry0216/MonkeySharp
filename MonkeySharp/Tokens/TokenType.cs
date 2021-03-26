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

        Bang,
        Assign,
        Plus,
        Minus,
        Slash,
        Asterisk,
        Equal,
        NotEqual,

        // delimiters

        Comma,
        Semicolon,
        LParen,
        RParen,
        LBrace,
        RBrace,
        LessThan,
        GreaterThan,

        // keywords

        Function,
        Let,
        If,
        Else,
        Return,

        // Primative Values

        True,
        False,
    }
}