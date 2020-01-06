using BusinessLogic.Interface;
using ConsoleManager;
using System;

namespace ProgramUI.Command
{
    internal class MinDrivesByConsole : CommandReader
    {
        private ICalculatorLogic calculatorLogic;
        private int result;
        private string errorMessage = null;
        private bool usedArrayWasRequested = false;
        private bool totalArrayRequested = false;
        private int [] used;
        private int[] total;

        public MinDrivesByConsole(ICalculatorLogic calculatorLogic)
        {
            this.calculatorLogic = calculatorLogic;
        }

        public override void AskNextCommand()
        {
            if (!_isFinished)
            {
                AskUsedArray();
                AskTotalArray();
                _isFinished = true;
            }
        }
               

        private void AskUsedArray()
        {
            string command = "";
            while (!usedArrayWasRequested)
            {
                Console.WriteLine("Enter used space array (example: {1,1}): ");
                command = Console.ReadLine();
                used = StringToIntArray(command);
                usedArrayWasRequested = true;
            }
        }

        private void AskTotalArray()
        {
            string command = "";
            while (!totalArrayRequested)
            {
                Console.WriteLine("Enter total space array (example: {2,2}): ");
                command = Console.ReadLine();
                total = StringToIntArray(command);
                totalArrayRequested = true;
            }
        }

        private int [] StringToIntArray(string value)
        {
            try
            {
                string valueWithoutParenthesis = value.Substring(1, value.Length - 2);
                string[] parts = valueWithoutParenthesis.Split(',');
                int[] values = Array.ConvertAll(parts, s => int.Parse(s));
                return values;
            }
            catch(Exception)
            {
                throw new CommandException("The value: "+value+" is not array of integer");
            }            
        }

        public override void ExecuteResultInstructions()
        {
            try
            {
                result = calculatorLogic.MinDrives(used, total);
            }
            catch(BusinessLogicException e)
            {              
                errorMessage = e.Message;
            }
            
        }

        public override void PrintResults()
        {
            if(errorMessage == null)
            {
                Console.WriteLine("The result is " + result);
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
        }
    }
}