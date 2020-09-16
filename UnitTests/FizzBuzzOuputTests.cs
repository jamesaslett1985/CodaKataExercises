using NUnit.Framework;
using System.Linq;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace CodeKata.UnitTests
{
    [TestFixture]
    public class FizzBuzzOutputTests
    {
        [Test]
        public void ReturnOutputForNumber_ShouldReturn_ExpectedResultsForNumbersOneToOneHundred()
        {
            var fizzBuzz = new FizzBuzzOutput();

            for (var i = 0; i <= 100; i++)
            {
                var returnValue = fizzBuzz.ReturnOutputForNumber(i);
                var expectedValue = CalculateExpectedReturnOutputForNumber(i);
                Assert.AreEqual(expectedValue, returnValue);
            }          
        }

        [TestCase(-5, "Number is less than 0!")]
        [TestCase(0, "0")]
        [TestCase(101, "Number is greater than 100!")]

        public void ReturnOutputForNumber_ShouldReturn_ExpectedResultsForEdgeCases(int input, string expectedOutput)
        {
            var fizzBuzz = new FizzBuzzOutput();
            Assert.AreEqual(expectedOutput, fizzBuzz.ReturnOutputForNumber(input));
        }
   
        private string CalculateExpectedReturnOutputForNumber(int number)
        {
            if (number == 0)
            {
                return "0";
            }
            else if (number % 3 == 0 & number % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (number % 3 == 0)
            {
                return "Fizz";
            }
            else if (number % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return number.ToString();
            }
        }
    }
}