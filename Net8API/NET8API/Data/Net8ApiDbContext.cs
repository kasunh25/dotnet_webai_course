using Microsoft.EntityFrameworkCore;
using NET8API.Models.Domain;

namespace NET8API.Data
{
    public class Net8ApiDbContext : DbContext
    {
        public Net8ApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Models.Domain.Task> Tasks { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for tasks
            //Creating a list of tasks to seed into the database
            var tasks = new List<NET8API.Models.Domain.Task>()
            {
                new Models.Domain.Task()
                {   
                    Id = Guid.Parse("65472640-b37b-45c1-8f0b-7bbbb9ece3f3"),
                    TaskName = "Water the plants",
                    EstimatedHours = 0.5,
                    ActualHours = 0.75,
                    Status ="In Progress"

                },

                 new Models.Domain.Task()
                {
                    Id = Guid.Parse("de47cc9d-e09e-425a-98b9-8a44698b399b"),
                    TaskName = "wash Dishes",
                    EstimatedHours = 1,
                    ActualHours = 0.75,
                    Status ="Done"

                },

                 new Models.Domain.Task()
                {
                    Id = Guid.Parse("d822a934-263b-41b6-815a-adaedc5ee91e"),
                    TaskName = "Do laundry",
                    EstimatedHours = 1.5,
                    ActualHours = 1.5,
                    Status ="Paused"

                },

            };

            //Seed tasks to the database
            modelBuilder.Entity<Models.Domain.Task>().HasData(tasks);

        }
    }
}
