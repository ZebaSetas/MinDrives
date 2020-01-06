using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interface
{
    public class BusinessLogicException:Exception
    {
        public BusinessLogicException(string message) : base(message)
        {
        }
    }
}
