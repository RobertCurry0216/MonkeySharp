using MonkeySharp.Cli.ConsoleIO;

namespace MonkeySharp.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var repl = new Repl.Repl(reader, writer);
            repl.Start();
        }
    }
}