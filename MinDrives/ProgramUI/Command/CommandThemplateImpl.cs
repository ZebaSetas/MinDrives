using ConsoleManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI.Command
{
    public class CommandThemplateImpl : CommandThemplate
    {
        public CommandThemplateImpl(CommandFactory commandFactory) : base(commandFactory) { }

        protected override void PrintSelectionCommand()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Check using the console");
            Console.WriteLine("2 - Check using the file");
            Console.WriteLine();
            Console.Write("Select menu option: ");
            
        }

        protected override void PrintWelcomeMessage()
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("*           Welcome to Mindrives!          *");
            Console.WriteLine("********************************************");
        }
    }
}
