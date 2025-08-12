using Microsoft.EntityFrameworkCore;
using NET8API.Models.Domain;

namespace NET8API.Data
{
    public class Net8ApiDbContext : DbContext
    {
        public Net8ApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Models.Domain.Task> Tasks{ get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}
