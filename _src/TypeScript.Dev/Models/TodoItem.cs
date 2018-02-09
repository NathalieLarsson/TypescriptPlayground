using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TypeScript.Dev.Models
{
	public class TodoList
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<TodoItem> TodoItems { get; set; }
	}

	public class TodoItem
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public int TodoListId { get; set; }
		public TodoList TodoList { get; set; }
    }
}
