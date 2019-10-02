using System;
using System.Collections.Generic;
using System.Text;

namespace MathTestGenerator
{
    public class EquationGenerator
    {
        public static string GenerateMathTest()
        {
            return "";
        }

        public static bool IsValidEquation(string mathString)
        {
            bool isValid = EvaluateExpression(mathString); ;

            return isValid;
        }
    }
}
