using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET8API.Data;
using NET8API.Models.Domain;
using NET8API.Models.DTO;

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
            //Get data fron Database - Domain models
            var tasks = dbContext.Tasks.ToList();

            //Map domain models to DTOs
            var tasksDto = new List<TaskDto>();

            foreach (var task in tasks)
            {
                tasksDto.Add(new TaskDto
                {
                    Id = task.Id,
                    TaskName = task.TaskName,
                    EstimatedHours = task.EstimatedHours,
                    ActualHours = task.ActualHours,
                    Status = task.Status
                });
            }

            //Return DTOs


            return Ok(tasks);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetTaskById([FromRoute] Guid id)
        {
            //var task = dbContext.Tasks.Find(id); // Only filter by Primary Key
            // Fetching model data from the database
            var taskDomain = dbContext.Tasks.FirstOrDefault(x => x.Id == id); // For any field

            if(taskDomain == null)
            {
                return NotFound();
            }

            //Map domain model to DTO
            var task = new TaskDto
            {
                Id = taskDomain.Id,
                TaskName = taskDomain.TaskName,
                EstimatedHours = taskDomain.EstimatedHours,
                ActualHours = taskDomain.ActualHours,
                Status = taskDomain.Status
            };

            //Return DTO
            return Ok(task);
        }

        //POST to create a new task
        [HttpPost]
        public IActionResult CreateATask([FromBody] AddTaskDto addTaskDto)
        {
            //Map or convert DTO to Domain model
            var taskDomainModel = new NET8API.Models.Domain.Task
            {
                TaskName = addTaskDto.TaskName,
                EstimatedHours = addTaskDto.EstimatedHours,
                ActualHours = addTaskDto.ActualHours,
                Status = addTaskDto.Status
            };

            //Use domain model to create a region
            dbContext.Tasks.Add(taskDomainModel);
            //Save changes to the database
            dbContext.SaveChanges();

            //Map domain model to DTO
            var taskDto = new TaskDto
            {
                Id = taskDomainModel.Id,
                TaskName = taskDomainModel.TaskName,
                EstimatedHours = taskDomainModel.EstimatedHours,
                ActualHours = taskDomainModel.ActualHours,
                Status = taskDomainModel.Status
            };

            return CreatedAtAction(nameof(GetTaskById), new { id = taskDto.Id }, taskDto);

        }




    }
}
