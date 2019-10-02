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
            var numberOfOperator = GetRandomNumberOfOperator();
            var operatorList = GetRandomOperatorList((int)numberOfOperator);
            StringBuilder str = new StringBuilder();
            foreach(var mathOp in operatorList){
                str.Append(GetRandomEquationNumber());
                str.Append(" ");
                str.Append(mathOp);
                str.Append(" ");
            }
            str.Append(GetRandomEquationNumber());

            return str.ToString();
        }


        public static IList<string> GetRandomOperatorList(int count)
        {
            IDictionary<int, string> operatorList = new Dictionary<int, string>();

            operatorList.Add(0, "+");
            operatorList.Add(1, "-");
            operatorList.Add(2, "*");
            operatorList.Add(3, "/");

            IList<string> returnOperatorList = new List<string>();
            
            Random random = new Random();
            
            while (returnOperatorList.Count < count)
            {
                int num = random.Next(0, 4);
                returnOperatorList.Add(operatorList[num]);
                
            }



            return returnOperatorList;


        }

        public static double GetRandomNumberOfOperator()
        {
            var numberOfOperator = GetRandomNumber(2, 11);
            return numberOfOperator;
        }

        public static double GetRandomEquationNumber()
        {
            var numberOfOperator = GetRandomNumber(-1000, 1001);
            return numberOfOperator;
        }

        public static double GetRandomNumber(int rangeFrom, int rangeTo)
        {
            Random random = new Random();
            var randomNumber = random.Next(rangeFrom, rangeTo);
            return randomNumber;

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
