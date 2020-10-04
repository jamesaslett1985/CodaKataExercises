using CodeKata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOneToOneHundredProcessor<int> _oneToOneHundred;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FizzBuzzNumbersOnlyOutput()
        {
            return OneToOneHundredProcessorResults(new NumberOnlyOutput());
        }

        public IActionResult FizzBuzzOutput()
        {
            return OneToOneHundredProcessorResults(new FizzBuzzOutput());
        }

        private IActionResult OneToOneHundredProcessorResults<T>(IReturnOutput<T> getNumbers)
        {
            var processNumbers = _oneToOneHundred(getNumbers);
            //var processNumbers = new OneToOneHundredProcessor<T>(getNumbers);
            var results = processNumbers.ReturnNumbers().Select(item => item.ToString());
            var model = new FizzBuzzResults(results.ToArray());
            return View("FizzBuzzOutput", model);
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
