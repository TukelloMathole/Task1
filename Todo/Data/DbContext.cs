using Microsoft.EntityFrameworkCore;
using Todo.Model;

namespace Todo.Data
{
    public class TodoDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TodoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
