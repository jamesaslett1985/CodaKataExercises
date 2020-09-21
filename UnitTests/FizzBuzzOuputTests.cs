using NUnit.Framework;
using System.Linq;
using Moq;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

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
                var expectedValue = CalculateExpectedReturnOutputForNumbersOneToOneHundred(i);
                Assert.AreEqual(expectedValue, returnValue);
            }          
        }


        //--------------------------------------------------------------------------------------

        [TestCase(3, 5)]
        [TestCase(5, 3)]

        public void ReturnOutputForNumber_ShouldReturn_ExpectedResultsNumbersDivisibleBy(int numberDivisibleBy, int numberIsNotDivisibleBy)
        {
            var fizzBuzz = new FizzBuzzOutput();
            var numbersExpectedToMapToFizzor = Enumerable.Range(1, 100).Where(x => IsNumberDivisibleBy(x, numberDivisibleBy) && NumberIsNotDivisibleBy(x, numberIsNotDivisibleBy));

            foreach (int i in numbersExpectedToMapToFizzor)
            {
                var returnValue = fizzBuzz.ReturnOutputForNumber(i);
                var expectedValue = CalculateExpectedReturnOutputForNumbersDivisibleBy(i);
                Assert.AreEqual(expectedValue, returnValue);
            }
        }

        [Test]
        public void ReturnOutputForNumber_ShouldReturn_ExpectedResultsNumbersDivisibleByThreeAndFive()
        {
            var fizzBuzz = new FizzBuzzOutput();
            var numbersExpectedToMapToFizzor = Enumerable.Range(1, 100).Where(x => x % 5 == 0 && x % 3 == 0);

            foreach (int i in numbersExpectedToMapToFizzor)
            {
                var returnValue = fizzBuzz.ReturnOutputForNumber(i);
                var expectedValue = CalculateExpectedReturnOutputForNumbersDivisibleByThreeAndFive(i);
                Assert.AreEqual(expectedValue, returnValue);
            }
        }

        //------------------------------------------------------------------------

        [TestCase(-5, "Number is less than 0!")]
        [TestCase(0, "0")]
        [TestCase(101, "Number is greater than 100!")]

        public void ReturnOutputForNumber_ShouldReturn_ExpectedResultsForEdgeCases(int input, string expectedOutput)
        {
            var fizzBuzz = new FizzBuzzOutput();
            Assert.AreEqual(expectedOutput, fizzBuzz.ReturnOutputForNumber(input));
        }
   
        private string CalculateExpectedReturnOutputForNumbersOneToOneHundred(int number)
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

        //METHODS------------------------------------------------------------------------

        private bool IsNumberDivisibleBy(int x, int divisor)
        {
            return x % divisor == 0;
        }

        private bool NumberIsNotDivisibleBy(int x, int divisor)
        {
            return !IsNumberDivisibleBy(x, divisor);
        }

        private string CalculateExpectedReturnOutputForNumbersDivisibleBy(int number)
        {
            if (number % 3 == 0 & number % 5 == 0)
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

        private string CalculateExpectedReturnOutputForNumbersDivisibleByThreeAndFive(int number)
        {
            if (number % 3 == 0 & number % 5 == 0)
            {
                return "FizzBuzz";
            }
            else
            {
                return number.ToString();
            }
        }
    }
}