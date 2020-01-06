using BusinessLogic.Interface;
using System;

namespace BusinessLogic
{
    public class CalculatorLogic : ICalculatorLogic
    {
        public void Calculate(object p1, object p2)
        {
            throw new BusinessLogicException("");
        }
    }
}
