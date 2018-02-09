using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TypeScript.Dev.Models
{
    public class EfContext : DbContext
	{
		public EfContext(DbContextOptions<EfContext> options): base(options)
		{ }

		public DbSet<TodoItem> TodoItems { get; set; }
		public DbSet<TodoList> TodoLists { get; set; }
	}
}
