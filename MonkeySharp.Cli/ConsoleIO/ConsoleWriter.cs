using MonkeySharp.Repl;
using System;

namespace MonkeySharp.Cli.ConsoleIO
{
    internal class ConsoleWriter : IWriter
    {
        public void Write(string strout)
        {
            Console.Write(strout);
        }

        public void WriteLine(string strout)
        {
            Console.WriteLine(strout);
        }
    }
}