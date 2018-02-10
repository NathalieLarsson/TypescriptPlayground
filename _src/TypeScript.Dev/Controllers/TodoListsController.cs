using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TypeScript.Dev.Models;

namespace TypeScript.Dev.Controllers
{
    [Produces("application/json")]
    [Route("api/TodoLists")]
    public class TodoListsController : Controller
    {
        private readonly EfContext _context;

        public TodoListsController(EfContext context)
        {
            _context = context;
        }

        // GET: api/TodoLists
        [HttpGet]
        public IEnumerable<TodoList> GetTodoLists()
        {
	        var todoLists = new TodoList[]
	        {
		        new TodoList {Name = "Shopping list"},
		        new TodoList {Name = "Todo - Cleaning"},
		        new TodoList {Name = "Training list"}
	        };

	        _context.TodoLists.AddRange(todoLists);
	        _context.SaveChanges();

			return _context.TodoLists;
        }

        // GET: api/TodoLists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoList = await _context.TodoLists.SingleOrDefaultAsync(m => m.Id == id);

            if (todoList == null)
            {
                return NotFound();
            }

            return Ok(todoList);
        }

        // PUT: api/TodoLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList([FromRoute] int id, [FromBody] TodoList todoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoList.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoLists
        [HttpPost]
        public async Task<IActionResult> PostTodoList([FromBody] TodoList todoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TodoLists.Add(todoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoList", new { id = todoList.Id }, todoList);
        }

        // DELETE: api/TodoLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoList = await _context.TodoLists.SingleOrDefaultAsync(m => m.Id == id);
            if (todoList == null)
            {
                return NotFound();
            }

            _context.TodoLists.Remove(todoList);
            await _context.SaveChangesAsync();

            return Ok(todoList);
        }

        private bool TodoListExists(int id)
        {
            return _context.TodoLists.Any(e => e.Id == id);
        }
    }
}