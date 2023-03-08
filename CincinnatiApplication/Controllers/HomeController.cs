using CincinnatiApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace CincinnatiApplication.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public void onGet()
        {
            using(var webClient = new WebClient()) 
            {

                string jsonString = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/wmj4-ygbf.json");
                var employee = Welcome.FromJson(jsonString);
                ViewData["Welcome"] = employee;
            }
            
                
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult CincinnatiEmployees()
        {
            return View();
        }
        public IActionResult Economy()
        {
            return View();
        }
        public IActionResult Attractions()
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