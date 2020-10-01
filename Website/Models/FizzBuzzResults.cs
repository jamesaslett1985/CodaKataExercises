using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class FizzBuzzResults
    {
        public FizzBuzzResults(string[] results)
        {
            Results = results;
        }

        public string[] Results { get; }
    }
}
