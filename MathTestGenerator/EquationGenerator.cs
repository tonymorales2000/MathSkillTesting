using System;
using System.Collections.Generic;
using System.Data;
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

        private static bool EvaluateExpression(string mathString)
        {
            DataTable dt = new DataTable();
            
            var answer = dt.Compute(mathString, "").ToString();
            var isValid = decimal.TryParse(answer, out decimal _);
            return isValid;
        }

       
    }
}
