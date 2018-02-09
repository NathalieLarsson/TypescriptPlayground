using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TypeScript.Dev.Models;

namespace TypeScript.Dev.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
    public class SampleDataController : Controller
    {
	    private readonly EfContext _context;

	    public SampleDataController(EfContext context)
	    {
		    _context = context;
		}

	    [HttpGet]
	    public IEnumerable<TodoList> GetLists()
	    {
		    var lists = _context.TodoLists;
			return lists;
	    }

	    [HttpPost("[action]")]
	    public string PostData(TodoItem item)
	    {
		    _context.TodoItems.Add(item);

		    return item.Title;
	    }
    }
}
