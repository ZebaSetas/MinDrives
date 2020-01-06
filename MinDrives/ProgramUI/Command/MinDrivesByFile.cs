using System;
using System.Collections.Generic;
using System.IO;
using BusinessLogic.Interface;
using ConsoleManager;

namespace ProgramUI.Command
{
    internal class MinDrivesByFile : CommandReader
    {
        private ICalculatorLogic calculatorLogic;
        private bool pathOfFileWasRequested = false;
        private string path;
        private string result = "";
        private string errorMessage;
        private List<int> results = new List<int>();
        public MinDrivesByFile(ICalculatorLogic calculatorLogic)
        {
            this.calculatorLogic = calculatorLogic;
        }

        public override void AskNextCommand()
        {
            if (!_isFinished)
            {
                AskPathOfFile();               
                _isFinished = true;
            }
        }

        private void AskPathOfFile()
        {            
            while (!pathOfFileWasRequested)
            {
                Console.WriteLine("Enter absolute path of file: ");
                path = Console.ReadLine();                
                pathOfFileWasRequested = true;
            }
        }

        public override void ExecuteResultInstructions()
        {
            try
            {
                string[] arrays = File.ReadAllLines(path);
                int[] used = null;
                int[] total  = null;
                for (int i = 1; i <= arrays.Length; i++)
                {
                    if (i % 3 == 1)
                    {
                        result += "Line " + i + ">> used array: " + arrays[i]+"\n";
                        try
                        {
                            used = StringUtils.StringToIntArray(arrays[i]);
                        }
                        catch (CommandException e)
                        {
                            result += e.Message + "\n";
                            used = null;
                        }                        
                    }
                    if (i % 3 == 2)
                    {
                        result += "Line " + i + ">> total array: " + arrays[i] + "\n";
                        try
                        {
                            total = StringUtils.StringToIntArray(arrays[i]);
                        }
                        catch (CommandException e)
                        {
                            result += e.Message + "\n";
                            total = null;
                        }
                    }
                    if(i%3 == 0)
                    {
                        try
                        {
                            int partialResult = calculatorLogic.MinDrives(used, total);
                            result += "For lines " + (i - 2) + " and " + (i - 1) + " the result is " + partialResult+"\n";  

                        }
                        catch(BusinessLogicException e)
                        {
                            result += "For lines " + (i - 2) + " and " + (i - 1) + " there is a next error>> " +e.Message + "\n";
                        }
                        used = null;
                        total = null;

                    }
                }
            }
            catch (IOException)
            {
                errorMessage = "The file no exist";
            }
            catch (Exception)
            {
                errorMessage = "Error reading file";

            }
        }

        public override void PrintResults()
        {
            if (errorMessage == null)
            {
                Console.WriteLine("The result is:");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
        }
    }
}
