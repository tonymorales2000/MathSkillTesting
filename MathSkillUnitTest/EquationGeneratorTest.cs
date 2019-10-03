using MathTestGenerator;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathSkillUnitTest
{
    public class EquationGeneratorTest
    {
        public IEquationGenerator iEquationGenerator { get; set; }

        //public EquationGeneratorTest(IEquationGenerator equationGenerator)
        //{
        //    EquationGenerator = equationGenerator;
        //}
        [SetUp]
        public void Setup()
        {
            
             iEquationGenerator = new EquationGenerator();
            
        }
        [Test]
        public void EquationIsValidTest()
        {
            Assert.IsTrue( iEquationGenerator.IsValidEquation("1 + 2"));
            Assert.IsFalse(iEquationGenerator.IsValidEquation("1 / 0"));
            Assert.IsFalse(iEquationGenerator.IsValidEquation(float.MinValue + " -" + 9.985e307));
        }
        [Test]
        public void GetRandomOperatorListTest()
        {
        
           Assert.IsTrue(  iEquationGenerator.GetRandomOperatorList(5).Count == 5);
           Assert.IsTrue(iEquationGenerator.GetRandomOperatorList(10).Count == 10);

        }

        [Test]
        public void MathEquationGeneratorTest()
        {
            var str = iEquationGenerator.GenerateMathTest();
            System.Diagnostics.Debug.WriteLine(str);
            str = iEquationGenerator.GenerateMathTest();
            System.Diagnostics.Debug.WriteLine(str);
            str = iEquationGenerator.GenerateMathTest();
            System.Diagnostics.Debug.WriteLine(str);
           

        }
    }
}
