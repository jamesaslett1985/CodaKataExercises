using System.Collections.Generic;
using System.Linq;


namespace CodeKata
{
    public class OneToOneHundredProcessor<TConvertNumberTo>
    {
        private readonly IReturnOutput<TConvertNumberTo> _returnOutput;

        public OneToOneHundredProcessor(IReturnOutput<TConvertNumberTo> returnOutput)
        {
            _returnOutput = returnOutput;
        }

        public IEnumerable<TConvertNumberTo> LoopThroughNumbers()
        {
            return Enumerable.Range(1, 100).Select(_returnOutput.ReturnOutputForNumber);
        }
    }
}
