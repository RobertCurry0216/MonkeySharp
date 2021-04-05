using Microsoft.AspNetCore.SignalR;
using MonkeySharp.Api.Hubs.Clients;
using MonkeySharp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeySharp.Api.Hubs
{
    public class ReplHub : Hub<IReplClient>
    {
        public void ParseRawCode(string input)
        {
            var task = Task.Run(() =>
            {

                var reader = new ApiReader(this);
                var writer = new ApiWriter(this);

                var lexer = new Lexer.Lexer(input);
                Tokens.Token token;
                do
                {
                    token = lexer.NextToken();
                    writer.WriteLine(token.ToString());
                } while (token.Type != Tokens.TokenType.Eof);
            });

            task.Wait(1000);

            task.Dispose();
        }
    }
}
