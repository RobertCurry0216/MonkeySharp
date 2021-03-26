using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeySharp.Repl
{
    public class Repl
    {
        private IReader Reader;
        private IWriter Writer;
        private string Prompt = ">> ";

        public Repl(IReader reader, IWriter writer)
        {
            Reader = reader;
            Writer = writer;
        }

        public void Start()
        {
            Writer.WriteLine("Welcome to the MonkeySharp programming language!!");
            Writer.WriteLine("Feel free to try out some commands :)");

            while (true)
            {
                Writer.Write(Prompt);
                var input = Reader.Read();

                var lexer = new Lexer.Lexer(input);

                Tokens.Token token;
                do
                {
                    token = lexer.NextToken();
                    Writer.WriteLine(token.ToString());
                } while (token.Type != Tokens.TokenType.Eof);
            }
        }
    }
}