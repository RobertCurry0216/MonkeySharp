using MonkeySharp.Repl;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeySharp.Cli.ConsoleCli
{
    internal class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}