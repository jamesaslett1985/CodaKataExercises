using NUnit.Framework;
using System.Linq;
using Moq;

namespace CodeKata.UnitTests
{
    [TestFixture]
    public class FizzBuzzOutput_Test
    {
        [Test]
        public void FizzBuzzOutputTest()
        {
            var fizzBuzz = new FizzBuzzOutput();

            //Asserts that number returns
            var test1 = fizzBuzz.ReturnOutputForNumber(1);
            Assert.AreEqual(test1, "1");
            //Asserts that Fizz returns
            var test2 = fizzBuzz.ReturnOutputForNumber(3);
            Assert.AreEqual(test2, "Fizz");
            //Asserts that FizzBuzz returns
            var test3 = fizzBuzz.ReturnOutputForNumber(15);
            Assert.AreEqual(test3, "FizzBuzz");
            //Asserts that Buzz returns
            var test4 = fizzBuzz.ReturnOutputForNumber(100);
            Assert.AreEqual(test4, "Buzz");
        }
    }
}