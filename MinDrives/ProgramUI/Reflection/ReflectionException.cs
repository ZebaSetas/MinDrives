using System;
using System.Runtime.Serialization;

namespace ProgramUI.Reflection
{
    [Serializable]
    internal class ReflectionException : Exception
    {
       
        public ReflectionException(string message) : base(message)
        {
        }

        public ReflectionException(string message,Exception inner) : base(message,inner)
        {
        }
    }
}