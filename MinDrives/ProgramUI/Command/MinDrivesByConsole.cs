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
                used = StringUtils.StringToIntArray(command);
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
                total = StringUtils.StringToIntArray(command);
                totalArrayRequested = true;
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