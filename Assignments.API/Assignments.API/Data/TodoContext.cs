using Assignments.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignments.API.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>()
                .HasOne(t => t.TaskType)
                .WithMany()
                .HasForeignKey(t => t.TaskTypeId);
        }
    }
}
