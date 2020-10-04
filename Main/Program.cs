using System;
using System.IO;
using System.Linq;

namespace CodeKata

{
   class Program
    {
        static void Main(string[] args)
        {
            var getNumbers = new NumberOnlyOutput();
            var processNumbers = new OneToOneHundredProcessor<int>(getNumbers);
            var results = processNumbers.ReturnNumbers().Select(item => item.ToString());
            var file = BuildFile.CreateFile(@"C:\Test Output\", "output.txt");
            File.WriteAllLines(file, results);         
        }
    }
}