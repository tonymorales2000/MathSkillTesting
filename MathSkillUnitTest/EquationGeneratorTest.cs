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
        }
    }
}
