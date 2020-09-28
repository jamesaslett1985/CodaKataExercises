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
        private readonly FizzBuzzOutput _fizzBuzzOutput;

        public FizzBuzzOutputTests() 
        {
            _fizzBuzzOutput = new FizzBuzzOutput();
        }

        [Test]

        public void ReturnOutputForNumber_ShouldReturn_ExpectedResultsForNumbersOnly()
        {
            var numberNotDivisibleByThreeAndFive = Enumerable.Range(1, 100).Where(x => NumberIsNotDivisibleBy(x, 3) && NumberIsNotDivisibleBy(x, 5));
            AssertSequenceHasExpectedValue(numberNotDivisibleByThreeAndFive, i => i.ToString());
        }

        [TestCase(3, 5, "Fizz")]
        [TestCase(5, 3, "Buzz")]

        public void ReturnOutputForNumber_ShouldReturn_ExpectedResultsNumbersDivisibleBy(int numberDivisibleBy, int numberIsNotDivisibleBy, string expectedOutput)
        {
            var numbersExpectedToMapToFizzor = Enumerable.Range(1, 100).Where(x => IsNumberDivisibleBy(x, numberDivisibleBy) && NumberIsNotDivisibleBy(x, numberIsNotDivisibleBy));
            AssertSequenceHasExpectedValue(numbersExpectedToMapToFizzor, _ => expectedOutput);
        }

        [Test]
        public void ReturnOutputForNumber_ShouldReturn_ExpectedResultsNumbersDivisibleByThreeAndFive()
        {
            var numbersExpectedToMapToFizzor = Enumerable.Range(1, 100).Where(x => IsNumberDivisibleBy(x, 5) && IsNumberDivisibleBy(x, 3));
            AssertSequenceHasExpectedValue(numbersExpectedToMapToFizzor, _ => "FizzBuzz");
        }

        private void AssertSequenceHasExpectedValue(IEnumerable<int> collectionToVerify, Func<int, string> expectedOutput)
        {

            foreach (var i in collectionToVerify)
            {
                var returnValue = _fizzBuzzOutput.ReturnOutputForNumber(i);
                var expectedOutputValue = expectedOutput(i);
                Assert.AreEqual(expectedOutputValue, returnValue);
            }
        }

        [TestCase(-5, "Number is less than 0!")]
        [TestCase(0, "0")]
        [TestCase(101, "Number is greater than 100!")]

        public void ReturnOutputForNumber_ShouldReturn_ExpectedResultsForEdgeCases(int input, string expectedOutput)
        {
            Assert.AreEqual(expectedOutput, _fizzBuzzOutput.ReturnOutputForNumber(input));
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
    }
}