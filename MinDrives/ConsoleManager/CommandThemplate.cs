using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleManager
{
    public abstract class CommandThemplate
    {
        private CommandFactory commandFactory;
        public CommandThemplate(CommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public void Execute()
        {
            bool exit = false;
            PrintWelcomeMessage();
            while (!exit)
            {
                try
                {
                    PrintSelectionCommand();
                    string command = Console.ReadLine();
                    CommandReader commandReader = commandFactory.BuildCommand(command.Split(' '));
                    if (commandReader != null)
                    {
                        commandReader.Execute();
                    }
                    else
                    {
                        exit = true;
                        Console.WriteLine("The user selected EXIT, good bye!!!");
                        Environment.Exit(1);
                    }
                }
                catch (CommandException e)
                {
                    Console.WriteLine("Error! The command has next problems:");
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        protected abstract void PrintWelcomeMessage();

        protected abstract void PrintSelectionCommand();
    }
}

