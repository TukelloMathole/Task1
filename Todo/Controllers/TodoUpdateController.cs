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
    public class TodoUpdateController : ControllerBase
    {
        private readonly TodoDbContext _context;
        private readonly ILogger<TodoUpdateController> _logger;

        public TodoUpdateController(TodoDbContext context, ILogger<TodoUpdateController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Updates a TodoItem with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the TodoItem to update.</param>
        /// <param name="updatedTodo">The updated TodoItem.</param>
        /// <returns>A IActionResult indicating the result of the update operation.</returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, [FromBody] TodoItem todoItem)
        {
            try
            {
                if (id != todoItem.Id)
                {
                    return BadRequest();
                }

                _context.Entry(todoItem).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoItemExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok("Successfully Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating TodoItem with ID: {id}.");
                return StatusCode(500, "Internal server error occurred while processing your request.");
            }
        }

        private bool TodoItemExists(int id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
