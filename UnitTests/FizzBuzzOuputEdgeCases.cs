using NUnit.Framework;
using System.Linq;
using Moq;

namespace CodeKata.UnitTests
{
    [TestFixture]
    public class FizzBuzzOutput_Edge_Cases
    {
        [TestCase(-5, "Number is less than 0!", TestName ="Negative value")]
        [TestCase(0, "0", TestName = "Zero")]
        [TestCase(101, "Number is greater than 100!", TestName = "Greater than 100")]

        public void FizzBuzzOutput(int input, string expectedOutput)
        {
            var fizzBuzz = new FizzBuzzOutput();
            Assert.AreEqual(expectedOutput, fizzBuzz.ReturnOutputForNumber(input));
        }
    }
}