using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MathTestGenerator
{
    public class EquationGenerator : IEquationGenerator
    {

        private IDictionary<int, string> operatorList;

        public EquationGenerator()
        {
            operatorList = new Dictionary<int, string>();
            operatorList.Add(0, "+");
            operatorList.Add(1, "-");
            operatorList.Add(2, "*");
            operatorList.Add(3, "/");

        }
        public string GenerateMathTest()
        {
            StringBuilder str = new StringBuilder();
            int numberOfOperator = 0;
            do
            {
                numberOfOperator = (int)GetRandomNumberOfOperator();
                var operatorList = GetRandomOperatorList((int)numberOfOperator);
                str = new StringBuilder();
                foreach (var mathOp in operatorList)
                {
                    str.Append(GetRandomEquationNumber());
                    str.Append(" ");
                    str.Append(mathOp);
                    str.Append(" ");
                }
                str.Append(GetRandomEquationNumber());

            } while (!IsValidEquation(str.ToString()) || numberOfOperator == 0);

            return str.ToString();
        }


        public IList<string> GetRandomOperatorList(int count)
        {

            IList<string> returnOperatorList = new List<string>();

            Random random = new Random();

            while (returnOperatorList.Count < count)
            {
                int num = random.Next(0, 4);
                returnOperatorList.Add(operatorList[num]);
            }

            return returnOperatorList;
        }

        private double GetRandomNumberOfOperator()
        {
            var numberOfOperator = GetRandomNumber(1, 11);
            return numberOfOperator;
        }

        private double GetRandomEquationNumber()
        {
            var numberOfOperator = GetRandomNumber(-1000, 1001);
            return Math.Round(numberOfOperator,1);
        }

        private double GetRandomNumber(int rangeFrom, int rangeTo)
        {
            Random random = new Random();
            var randomNumber = random.NextDouble() * random.Next(rangeFrom, rangeTo);

            return randomNumber;

        }

        public bool IsValidEquation(string mathString)
        {
            bool isValid = EvaluateExpression(mathString); ;
            return isValid;
        }

        private bool EvaluateExpression(string mathString)
        {
            DataTable dt = new DataTable();
            var answer = dt.Compute(mathString, "").ToString();
            var isValid = decimal.TryParse(answer, out decimal _);
            return isValid;
        }


    }
}
