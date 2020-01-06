using BusinessLogic.Interface;
using ConsoleManager;
using Strategies.Interface;
using System;

namespace ProgramUI.Command
{
    internal class MinDrivesByConsole : CommandReader
    {
        private ICalculatorLogic calculatorLogic;
        private IStrategy strategy;
        private int result;
        private string errorMessage = null;
        private bool usedArrayWasRequested = false;
        private bool totalArrayRequested = false;
        private int [] used;
        private int[] total;

        public MinDrivesByConsole(ICalculatorLogic calculatorLogic, IStrategy strategy)
        {
            this.calculatorLogic = calculatorLogic;
            this.strategy = strategy;

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
                used = StringUtilities.StringToIntArray(command);
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
                total = StringUtilities.StringToIntArray(command);
                totalArrayRequested = true;
            }
        }

        public override void ExecuteResultInstructions()
        {
            try
            {
                result = calculatorLogic.MinDrives(used, total,strategy);
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