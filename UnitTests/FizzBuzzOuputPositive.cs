using NUnit.Framework;
using System.Linq;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace CodeKata.UnitTests
{
    [TestFixture]
    public class FizzBuzzOutputPositive
    {
        private OneToOneHundredProcessor<int> _oneToOneHundredProcessor;

        [TestCase]
        public void FizzBuzzOutput()
        {
            //need to run through 1-00 and assert outputs. What's the best way to create the expected results? Presumably not newing up FizzBuzzOutput as that 
            //would be pointless. Mock?

            var fizzBuzz = new FizzBuzzOutput();
            var getNumbers = new NumberOnlyOutput();
            var processNumbers = new OneToOneHundredProcessor<int>(getNumbers);
            var results = processNumbers.LoopThroughNumbers().Select(item => item.ToString());
        }
    }
}