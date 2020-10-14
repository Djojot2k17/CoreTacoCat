using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreTacoCat.Models;

namespace CoreTacoCat.Controllers
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
        public IActionResult Code()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Solve()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Solve(string test)
        {
            if (string.IsNullOrWhiteSpace(test))
            {
                return View();
            }
            var result = string.Join("", test.Reverse().ToArray());
            if (test == result)
            {
                ViewData["Tacocat"] = $"The word {test} is {result} backwards and it is a palindrome";
            } else
            {
                ViewData["Tacocat"] = $"The word {test} is {result} backwards and is not a palindrome";
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
