using MonkeySharp.Repl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeySharp.Web.Models
{
    public class WebRepl
    {
        private IReader Reader;
        private IWriter Writer;

        public WebRepl(IReader reader, IWriter writer)
        {
            Reader = reader;
            Writer = writer;
        }

        public void Start()
        {
            Writer.WriteLine("Welcome to the MonkeySharp programming language!!");
            Writer.WriteLine("Feel free to try out some commands :)");

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
