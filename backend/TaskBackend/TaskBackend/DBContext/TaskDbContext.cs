using Microsoft.EntityFrameworkCore;
using TaskBackend.Models;


namespace TaskBackend.TaskDBContext
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions options) : base(options)
        {
        }
         
        public DbSet<TaskModel>  task { get; set; }
    }
}
