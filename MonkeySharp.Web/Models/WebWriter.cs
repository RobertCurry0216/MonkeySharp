using MonkeySharp.Repl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeySharp.Web.Models
{
    public class WebWriter : IWriter
    {
        ReplCache Cache;

        public WebWriter(ReplCache cache)
        {
            Cache = cache;
        }
        public void Write(string strout)
        {
            if (Cache.ValuesOut.Count < 1)
            {
                Cache.ValuesOut.Add(strout);
                return;
            }
            Cache.ValuesOut[Cache.ValuesOut.Count - 1] = Cache.ValuesOut.Last() + strout;
        }

        public void WriteLine(string strout)
        {
            Cache.ValuesOut.Add(strout);
        }
    }
}
