using ProgramUI.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleManager;
using ProgramUI.Reflection;
using BusinessLogic.Interface;
using Strategies.Interface;

namespace ProgramUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ICalculatorLogic calculatorLogic = ReflectionDependencyUtilities.GetCalculatorLogicDependency();
                IStrategy strategyCalculator = ReflectionDependencyUtilities.GetStrategyDependency();
                CommandFactory commandFactory = new CommandFactoryImpl(calculatorLogic, strategyCalculator);
                CommandThemplate commandThemplate = new CommandThemplateImpl(commandFactory);
                commandThemplate.Execute();
            }
            catch(ReflectionException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
