using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CodeKata
{
    public class OneToOneHundredProcessor<TConvertNumberTo> : IOneToOneHundredProcessor<T>
    {
        private readonly IReturnOutput<TConvertNumberTo> _returnOutput;
        private readonly IOneToOneHundredProcessor<TConvertNumberTo> _oneToOneHundred;


        public OneToOneHundredProcessor(IReturnOutput<TConvertNumberTo> returnOutput)
        {
            _returnOutput = returnOutput;
        }

        public IEnumerable<TConvertNumberTo> LoopThroughNumbers()
        {
            return Enumerable.Range(1, 100).Select(_returnOutput.ReturnOutputForNumber);
        }

        public IEnumerable<TConvertNumberTo> ReturnNumbers()
        {
            return RecursiveListMethod(new List<TConvertNumberTo>(), 0);
        }

        private List<TConvertNumberTo> RecursiveListMethod(List<TConvertNumberTo> items, int currentCount)
        {
            if (currentCount >= 100)
            {
                return items;
            }
            var nextCount = currentCount + 1;
            items.Add(_returnOutput.ReturnOutputForNumber(nextCount));
            return RecursiveListMethod(items, nextCount);
        }
    }
}
