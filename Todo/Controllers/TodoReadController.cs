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
    public class TodoReadController : ControllerBase
    {
        private readonly TodoDbContext _context;
        private readonly ILogger<TodoReadController> _logger;

        public TodoReadController(TodoDbContext context, ILogger<TodoReadController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all TodoItems.
        /// </summary>
        /// <returns>A list of TodoItems.</returns>

        [HttpGet]
        public async Task<IActionResult> GetAllTodoItems()
        {
            try
            {
                var todoItems = await _context.TodoItems.ToListAsync();
                return Ok(todoItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving TodoItems.");
                return StatusCode(500, "Internal server error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Retrieves a TodoItem with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the TodoItem to retrieve.</param>
        /// <returns>A IActionResult containing the retrieved TodoItem.</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItemById(int id)
        {
            try
            {
                var todoItem = await _context.TodoItems.FindAsync(id);
                if (todoItem == null)
                {
                    return NotFound();
                }
                return Ok(todoItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving TodoItem with ID: {id}.");
                return StatusCode(500, "Internal server error occurred while processing your request.");
            }
        }
    }
}
