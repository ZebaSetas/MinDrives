using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleManager
{
    public interface CommandFactory
    {
        CommandReader BuildCommand(string[] args);
    }
}
