namespace CodeKata
{
    public class NumberOnlyOutput : IReturnOutput<int>
    {
        public int ReturnOutputForNumber(int number)
        {
            return number;
        }
    }
}
