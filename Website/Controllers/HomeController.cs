using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CodeKata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FizzBuzzNumbersOnly()
        {
            var getNumbers = new NumberOnlyOutput();
            var processNumbers = new OneToOneHundredProcessor<int>(getNumbers);
            var results = processNumbers.ReturnNumbers().Select(item => item.ToString());
            var model = new FizzBuzzResults(results.ToArray());
            return View(model);
        }

        public IActionResult FizzBuzz()
        {
            var getNumbers = new FizzBuzzOutput();
            var processNumbers = new OneToOneHundredProcessor<string>(getNumbers);
            var results = processNumbers.ReturnNumbers().Select(item => item.ToString());
            var model = new FizzBuzzResults(results.ToArray());
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
