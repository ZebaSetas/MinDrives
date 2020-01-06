using ConsoleManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI.Command
{
    public static class StringUtils
    {
        public static int[] StringToIntArray(string value)
        {
            try
            {
                string valueWithoutParenthesis = value.Substring(1, value.Length - 2);
                string[] parts = valueWithoutParenthesis.Split(',');
                int[] values = Array.ConvertAll(parts, s => int.Parse(s));
                return values;
            }
            catch (Exception)
            {
                throw new CommandException("The value: " + value + " is not array of integer");
            }
        }
    }
}
