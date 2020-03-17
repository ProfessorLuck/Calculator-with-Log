using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calc
    {
        static public double Add(string input, string input2)
        {
            double total = double.Parse(input) + double.Parse(input2);
            return total;
        }

        static public double Subtract(string input, string input2)
        {
            double total = double.Parse(input) - double.Parse(input2);
            return total;
        }

        static public double Multiply(string input, string input2)
        {
            double total = double.Parse(input) * double.Parse(input2);
            return total;
        }

        static public double Divide(string input, string input2)
        {
            double total = double.Parse(input) / double.Parse(input2);
            return total;
        }
    }
}
