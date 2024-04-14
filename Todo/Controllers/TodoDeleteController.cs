using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Todo.Data;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoDeleteController : ControllerBase
    {
        private readonly TodoDbContext _context;
        private readonly ILogger<TodoDeleteController> _logger;

        public TodoDeleteController(TodoDbContext context, ILogger<TodoDeleteController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Deletes a TodoItem with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the TodoItem to delete.</param>
        /// <returns>A IActionResult indicating the result of the delete operation.</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            try
            {
                var todoItem = await _context.TodoItems.FindAsync(id);
                if (todoItem == null)
                {
                    return NotFound();
                }

                _context.TodoItems.Remove(todoItem);
                await _context.SaveChangesAsync();

                return Ok("Successfully removed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting TodoItem with ID: {id}.");
                return StatusCode(500, "Internal server error occurred while processing your request.");
            }
        }
    }
}
