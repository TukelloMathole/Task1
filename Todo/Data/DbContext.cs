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

        // Define DbSet for each entity (table) in your database
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get the connection string from appsettings.json
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
