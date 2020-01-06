using BusinessLogic;
using BusinessLogic.Interface;
using ConsoleManager;
using ProgramUI.Reflection;
using Strategies.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI.Command
{
    public class CommandFactoryImpl : CommandFactory
    {

        private ICalculatorLogic calculatorLogic;

        public CommandFactoryImpl(ICalculatorLogic calculatorLogic)
        {
            this.calculatorLogic = calculatorLogic;            
        }

        public CommandReader BuildCommand(string[] args)
        {
            if (args.Length != 1) throw new CommandException("Invalid number of arguments");
            if (args[0] == "1") return new MinDrivesByConsole(calculatorLogic);
            if (args[0] == "2") return new MinDrivesByFile(calculatorLogic);
            else throw new CommandException("Invalid command");
        }
    }

}
