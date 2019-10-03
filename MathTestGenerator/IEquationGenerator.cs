using System;
using System.Collections.Generic;
using System.Text;

namespace MathTestGenerator
{
    public interface IEquationGenerator
    {
        bool IsValidEquation(string mathString);
        IList<string> GetRandomOperatorList(int v);
        string GenerateMathTest();
    }
}
