using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleManager
{
    public abstract class CommandReader
    {
        protected bool _isFinished = false;

        public void Execute()
        {
            while (!_isFinished)
            {
                try
                {
                    AskNextCommand();
                }
                catch (CommandException e)
                {
                    Console.WriteLine("Error! The command has next problems: ");
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            ExecuteResultInstructions();
            PrintResults();
        }

        public abstract void PrintResults();
        public abstract void ExecuteResultInstructions();

        protected int GetAmountOfArguments(string command)
        {
            string[] parts = command.Split(' ');
            return parts.Length;
        }

        public abstract void AskNextCommand();
    }
}
