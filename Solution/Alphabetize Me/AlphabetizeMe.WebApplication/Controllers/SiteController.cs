using System.Diagnostics;
using AlphabetizeMe.ClassLibrary;
using AlphabetizeMe.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlphabetizeMe.WebApplication.Controllers
{
    public class SiteController : Controller
    {
        private readonly ILogger<SiteController> _logger;

        public SiteController(ILogger<SiteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string formProcessed = Request.Query["btnSubmit"];

            if (formProcessed != null && formProcessed.ToLower() == "alphabetize")
            {
                string inputText = Request.Query["txtInput"]; inputText.Trim();

                ViewBag.InputText = inputText;

                AlphabetizeMeApp myApp = new AlphabetizeMeApp();
                if (myApp.CheckUserInput(inputText))
                {
                    List<string> myList = new List<string>();
                    myList = myApp.ConvertStreamToList(inputText);
                    myList = myApp.AlphabetizeMe(myList);
                    ViewBag.InputText = myList.ToArray();
                }
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
