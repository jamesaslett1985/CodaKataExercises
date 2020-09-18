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
            var results = processNumbers.LoopThroughNumbers().Select(item => item.ToString());
            Console.WriteLine("why is this line being reached when there's a break point at line 14?");

            var file = BuildFile.CreateFile(@"C:\Test Output\", "output.txt");
            //File.WriteAllLines(file, results);         
        }


    }
}