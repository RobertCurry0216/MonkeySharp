using MonkeySharp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeySharp.Api.Hubs.Clients
{
    public interface IReplClient
    {
        Task WriteLine(string output);
        Task Write(string output);
        Task Read(string input);
    }
}
