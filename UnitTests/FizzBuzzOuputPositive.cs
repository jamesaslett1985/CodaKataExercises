using NUnit.Framework;
using System.Linq;
using Moq;

namespace CodeKata.UnitTests
{
    [TestFixture]
    public class FizzBuzzOutputPositive
    {
        private OneToOneHundredProcessor<int> _oneToOneHundredProcessor;

        [TestCase]
        public void FizzBuzzOutput()
        {
            var getNumbers = new NumberOnlyOutput();
            var processNumbers = new OneToOneHundredProcessor<int>(getNumbers);
            var results = processNumbers.LoopThroughNumbers().Select(item => item.ToString());
        }
    }
}