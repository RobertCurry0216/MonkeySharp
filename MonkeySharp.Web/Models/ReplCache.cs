using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeySharp.Web.Models
{
    public class ReplCache
    {
        public string ValueIn { get; set; } = "";
        public List<string> ValuesOut { get; set; } = new List<string>();
    }
}
