using System;
using System.IO;
using System.Linq;

namespace CodeKata

{
    class Program
    {
        static void Main(string[] args)
        {
            //Write method to replace LoopThroughNumbers. Iterating through numbers should be done through recursive method calls, not looping
            var getNumbers = new NumberOnlyOutput();
            var processNumbers = new OneToOneHundredProcessor<int>(getNumbers);
            //var results = processNumbers.LoopThroughNumbers().Select(item => item.ToString());
            var results = processNumbers.ReturnNumbers().Select(item => item.ToString());
            var file = BuildFile.CreateFile(@"C:\Test Output\", "output.txt");
            File.WriteAllLines(file, results);         
        }


    }
}