using NET8API.Models.Domain;
namespace NET8API.Repositories
{
    public interface ITaskRepository
    {
        Task<List<NET8API.Models.Domain.Task>> GetAllTasksAsync();

    }
}
