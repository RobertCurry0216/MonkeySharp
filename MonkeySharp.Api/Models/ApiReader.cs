using Microsoft.AspNetCore.SignalR;
using MonkeySharp.Repl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeySharp.Api.Models
{
    public class ApiReader : IReader
    {
        private Hub _hub;

        public ApiReader(Hub hub)
        {
            _hub = hub;
        }

        public string Read()
        {
            return "1";
        }
    }
}
