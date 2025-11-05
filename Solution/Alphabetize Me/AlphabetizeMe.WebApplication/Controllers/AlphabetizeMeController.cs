using AlphabetizeMe.ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AlphabetizeMe.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlphabetizeMeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AlphabetizeMeController> _logger;

        public AlphabetizeMeController(ILogger<AlphabetizeMeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetList")]
        public IEnumerable<ListData> Get()
        {
            return Enumerable.Range(1, Summaries.Length).Select(index => new ListData
            {
                Name = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "PostSpeechSynthesis")]
        public IEnumerable<string> Post(string input)
        {
            AlphabetizeMeApp myApp = new AlphabetizeMeApp();
            bool inputAlright = myApp.CheckUserInput(input);
            List<string> myList = new List<string>();
            myList = myApp.ConvertStreamToList(input, "\r\n");
            return myList = myApp.AlphabetizeMe(myList);
        }
    }
}
