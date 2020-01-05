using System;

namespace Strategies.Interface
{
    public class StrategyException : Exception
    {
      
        public StrategyException(string message) : base(message)
        {
        }      
    }
}
