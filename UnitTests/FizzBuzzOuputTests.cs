using NUnit.Framework;
using System.Linq;
using Moq;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

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

        [TestCase(3, 5, "Fizz")]
        [TestCase(5, 3, "Buzz")]

        public void ReturnOutputForNumber_ShouldReturn_ExpectedResultsNumbersDivisibleBy(int numberDivisibleBy, int numberIsNotDivisibleBy, string expectedOutput)
        {
            var fizzBuzz = new FizzBuzzOutput();
            var numbersExpectedToMapToFizzor = Enumerable.Range(1, 100).Where(x => IsNumberDivisibleBy(x, numberDivisibleBy) && NumberIsNotDivisibleBy(x, numberIsNotDivisibleBy));

            AssertSequenceHasExpectedValue(fizzBuzz, numbersExpectedToMapToFizzor, expectedOutput);
        }

        [Test]
        public void ReturnOutputForNumber_ShouldReturn_ExpectedResultsNumbersDivisibleByThreeAndFive()
        {
            var fizzBuzz = new FizzBuzzOutput();
            var numbersExpectedToMapToFizzor = Enumerable.Range(1, 100).Where(x => IsNumberDivisibleBy(x, 5) && IsNumberDivisibleBy(x, 3));
            AssertSequenceHasExpectedValue(fizzBuzz, numbersExpectedToMapToFizzor, "FizzBuzz");
        }

        private static void AssertSequenceHasExpectedValue(FizzBuzzOutput fizzBuzz, IEnumerable<int> collectionToVerify, string expectedOutput)
        {

            foreach (var i in collectionToVerify)
            {
                var returnValue = fizzBuzz.ReturnOutputForNumber(i);
                Assert.AreEqual(expectedOutput, returnValue);
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
    }
}