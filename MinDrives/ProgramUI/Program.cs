using ProgramUI.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleManager;

namespace ProgramUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CommandFactory commandFactory = new CommandFactoryImpl();
            CommandThemplate commandThemplate = new CommandThemplateImpl(commandFactory);
            commandThemplate.Execute();
        }
    }
}
