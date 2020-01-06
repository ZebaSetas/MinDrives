using BusinessLogic.Interface;
using ConsoleManager;

namespace ProgramUI.Command
{
    internal class MinDrivesByFile : CommandReader
    {
        private ICalculatorLogic calculatorLogic;

        public MinDrivesByFile(ICalculatorLogic calculatorLogic)
        {
            this.calculatorLogic = calculatorLogic;
        }

        public override void AskNextCommand()
        {
            throw new System.NotImplementedException();
        }

        public override void ExecuteResultInstructions()
        {
            throw new System.NotImplementedException();
        }

        public override void PrintResults()
        {
            throw new System.NotImplementedException();
        }
    }
}