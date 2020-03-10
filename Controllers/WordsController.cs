using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web;
using System.Text.Json;


using System.IO;
using System.Text;

namespace WordsControl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordsController : ControllerBase
    {
        private  string[] s = new string[400000];
        private readonly ILogger<WordsController> _logger;

        public WordsController(ILogger<WordsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Words> Get()
        {
            var rng = new Random();

            
                string[] lines = new string[400000];
                lines = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory  + "dictionary.txt");
            
          

    /*if (Context.Request.Query.TryGetValue("yourKey", out queryVal) &&
        queryVal.FirstOrDefault() == "yourValue")
    {
    }
            */
            //Console.Write(Request.QueryString);
            Uri myUri = new Uri("http://localhost:5000/words"+ Request.QueryString);
            string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("from");
            string param2 = HttpUtility.ParseQueryString(myUri.Query).Get("to");

            int j1 = 0;
            int j2 = 0;
            string[] lines_result = new string[800000];
            for (int i = 0; i <= lines.Length; i++ )
            {
                if (lines[i] == param1)
                {
                    j1 = i;
                }
                if (lines[i] == param2)
                {
                    j2 = i;
                    break;
                }
            }
            for (int k = 0; j1+k <=j2; k++)

            {   
                    lines_result[k] = lines[j1+k];
                    
                  //Console.WriteLine(lines_result[k]);
            }
       
      var res_list = Enumerable.Range(0, j2-j1+1).Select(index => new Words
            {   
               
                 s=lines_result[index]
               
            })
            .ToList();
            
           
           return res_list;
            
            
        }
    }
}
