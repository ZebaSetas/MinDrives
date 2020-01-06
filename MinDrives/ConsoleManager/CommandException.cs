using System;

namespace ConsoleManager
{
    public class CommandException : Exception
    {
        public CommandException(string message) : base(message) { }
    }
}
