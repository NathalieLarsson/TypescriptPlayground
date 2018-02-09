using System.Linq;
using TypeScript.Dev.Models;

namespace TypeScript.Dev.Data
{
    public static class DbInitializer
	{
	    public static void Initialize(EfContext context)
	    {
		    context.Database.EnsureCreated();

			if (context.TodoLists.Any())
			{
				return;   // DB has been seeded
			}

			var todoLists = new TodoList[]
			{
				new TodoList {Name = "Shopping list"}, 
				new TodoList {Name = "Todo - Cleaning"}, 
				new TodoList {Name = "Training list"}
			};

			context.TodoLists.AddRange(todoLists);
		    context.SaveChanges();
	    }
	}
}
