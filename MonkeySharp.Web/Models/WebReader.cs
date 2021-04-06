using MonkeySharp.Repl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeySharp.Web.Models
{
    public class WebReader : IReader
    {
        private ReplCache Cache;

        public WebReader(ReplCache cache)
        {
            Cache = cache;
        }

        public string Read()
        {
            return Cache.ValueIn;
        }
    }
}
