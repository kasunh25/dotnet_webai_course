using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET8API.Data;
using NET8API.Models.Domain;

namespace NET8API.Controllers
{
    //http://localhost:portnumber/api/Tasks
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly Net8ApiDbContext dbContext;
        public TasksController(Net8ApiDbContext dbContext)
        {
                this.dbContext = dbContext;
        }
        // GET: api/tasks
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            //var tasks = new List<NET8API.Models.Domain.Task>
            //{
            //    new Models.Domain.Task
            //    {
            //        Id = Guid.NewGuid(),
            //        TaskName = "Task 1",
            //        EstimatedHours = 2.5,
            //        ActualHours = 1.5,
            //        Status = "In Progress"
            //    },

            //    new Models.Domain.Task
            //    {
            //        Id = Guid.NewGuid(),
            //        TaskName = "Task 2",
            //        EstimatedHours = 3.0,
            //        ActualHours = 2.0,
            //        Status = "Completed"
            //    },

            //    new Models.Domain.Task
            //    {
            //        Id = Guid.NewGuid(),
            //        TaskName = "Task 3",
            //        EstimatedHours = 1.0,
            //        ActualHours = 0.5,
            //        Status = "Not Started"
            //    }
            //};

            //return Ok(tasks);

           
            var tasks = dbContext.Tasks.ToList();
            return Ok(tasks);

        }




     
    }
}
