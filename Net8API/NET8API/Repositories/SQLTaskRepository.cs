using Microsoft.EntityFrameworkCore;
using NET8API.Data;
using System.Runtime.CompilerServices;

namespace NET8API.Repositories
{
    public class SQLTaskRepository : ITaskRepository
    {
        private readonly Net8ApiDbContext dbContext;
        public SQLTaskRepository(Net8ApiDbContext net8ApiDbContext)
        {
            this.dbContext = net8ApiDbContext;    
        }

        public async Task<List<NET8API.Models.Domain.Task>> GetAllTasksAsync()
        {
            return await dbContext.Tasks.ToListAsync();
        }
    }
}
