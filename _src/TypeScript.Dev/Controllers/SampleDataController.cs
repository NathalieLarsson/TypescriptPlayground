using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TypeScript.Dev.Models;

namespace TypeScript.Dev.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
		public EfContext dbCtx = new EfContext(new DbContextOptions<EfContext>());

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

	    [HttpGet("[action]")]
	    public string GetData()
	    {
			return "TEST";
	    }

	    [HttpPost("[action]")]
	    public string PostData(TodoItem item)
	    {
		    dbCtx.TodoItems.Add(item);

		    return item.Title;
	    }

		[HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
