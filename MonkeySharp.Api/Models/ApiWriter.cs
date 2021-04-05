using Microsoft.AspNetCore.SignalR;
using MonkeySharp.Api.Hubs.Clients;
using MonkeySharp.Repl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeySharp.Api.Models
{
    public class ApiWriter : IWriter
    {
        private Hub<IReplClient> _hub;

        public ApiWriter(Hub<IReplClient> hub)
        {
            _hub = hub;
        }

        public void Write(string strout)
        {
            _hub.Clients.Caller.Write(strout);
        }

        public void WriteLine(string strout)
        {
            _hub.Clients.Caller.WriteLine(strout);
        }
    }
}
