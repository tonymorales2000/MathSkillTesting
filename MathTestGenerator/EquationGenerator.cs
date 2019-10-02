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
            //get random number of operator

            return "";
        }


        public static IList<string> GetRandomOperatorList(int count)
        {
            IDictionary<int, string> operatorList = new Dictionary<int, string>();

            operatorList.Add(1, "+");
            operatorList.Add(2, "-");
            operatorList.Add(3, "*");
            operatorList.Add(4, "/");

            IList<string> returnOperatorList = new List<string>();


            var set = new HashSet<int>();
            var nums = new List<int>();
            Random random = new Random();
            
            while (returnOperatorList.Count < count)
            {
                int num = random.Next(1, count);
                returnOperatorList.Add(operatorList[num]);
                
            }



            return returnOperatorList;


        }

        public static int GetRandomNumberOfOperator()
        {
           
            Random random = new Random();
            var numberOfOperator = random.Next(1, 10);
            return numberOfOperator;

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
