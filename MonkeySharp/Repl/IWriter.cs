using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeySharp.Repl
{
    public interface IWriter
    {
        void Write(string strout);

        void WriteLine(string strout);
    }
}