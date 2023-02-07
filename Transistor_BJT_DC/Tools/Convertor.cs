using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transistor_BJT_DC.Tools
{
    public class Convertor
    {
        public static double converttokilo(string input)
        {

            if (input.EndsWith("k"))
            {
                input = input.Substring(0, input.Length - 1);
                double output = Convert.ToDouble(input);
                output *= 1000;
                return output;
            }
            else
            {
                return Convert.ToDouble(input);
            }
        }
    }
}
