using Microsoft.AspNetCore.SignalR;
using MonkeySharp.Api.Hubs.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeySharp.Api.Hubs
{
    public class ReplHub : Hub<IReplClient>
    {
        public async Task ParseRawCode(string input)
        {
            Console.WriteLine("parse code");
            Console.WriteLine(input);
            await Task.Run(async () => { 
                await this.Clients.Caller.WriteLine(input); 
            });
        }
    }
}
