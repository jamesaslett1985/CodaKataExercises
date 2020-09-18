using NUnit.Framework;
using System.Linq;
using Moq;

namespace CodeKata.UnitTests
{
    [TestFixture]
    public class OneToOneHundredProcessor
    {
        private OneToOneHundredProcessor<int> _oneToOneHundredProcessor;

        [Test]
        public void OneToOneHundredProcessorTest()
        {
            var mock = new Mock<IReturnOutput<int>>();
            mock.Setup(x => x.ReturnOutputForNumber(It.IsAny<int>())).Returns<int>(x => x);
            _oneToOneHundredProcessor = new OneToOneHundredProcessor<int>(mock.Object);
            var actualResults = _oneToOneHundredProcessor.LoopThroughNumbers().ToArray();
            mock.Verify(x => x.ReturnOutputForNumber(It.IsAny<int>()), Times.Exactly(100));
            var expectedResults = Enumerable.Range(1, 100);
            CollectionAssert.AreEqual(actualResults, expectedResults);
        }
    }
}