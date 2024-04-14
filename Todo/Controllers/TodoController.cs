using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Todo.Data;
using Todo.Model;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _context;
        private readonly ILogger<TodoController> _logger;

        public TodoController(TodoDbContext context, ILogger<TodoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new TodoItem.
        /// </summary>
        /// <param name="todo">The TodoItem to create.</param>
        /// <returns>The created TodoItem.</returns>

        [HttpPost]
        public async Task<IActionResult> CreateTodoAsync([FromBody] TodoItem todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                todo.Title = System.Net.WebUtility.HtmlEncode(todo.Title);
                todo.Description = System.Net.WebUtility.HtmlEncode(todo.Description);

                _context.TodoItems.Add(todo);
                await _context.SaveChangesAsync();
                return Ok(todo);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occurred while creating TodoItem.");
                return StatusCode(500, "Internal server error occurred while processing your request.");
            }
        }
    }
}
