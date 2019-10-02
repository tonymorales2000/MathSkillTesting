using MathTestGenerator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathSkillUnitTest
{
    public class EquationGeneratorTest
    {
        [Test]
        public void EquationIsValidTest()
        {
            Assert.IsTrue( EquationGenerator.IsValidEquation("1 + 2"));
            Assert.IsFalse(EquationGenerator.IsValidEquation("1 / 0"));
            Assert.IsFalse(EquationGenerator.IsValidEquation(float.MinValue + " -" + 9.985e307));
        }
        [Test]
        public void GetRandomOperatorListTest()
        {
           Assert.IsTrue(  EquationGenerator.GetRandomOperatorList(5).Count == 5);
           Assert.IsTrue(EquationGenerator.GetRandomOperatorList(10).Count == 10);
        }
    }
}
