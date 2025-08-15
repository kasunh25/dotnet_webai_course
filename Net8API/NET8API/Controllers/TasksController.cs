using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET8API.Data;
using NET8API.Models.Domain;
using NET8API.Models.DTO;
using NET8API.Repositories;

namespace NET8API.Controllers
{
    //http://localhost:portnumber/api/Tasks
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly Net8ApiDbContext dbContext;
        private readonly ITaskRepository taskRepository;
        private readonly IMapper mapper;

        public TasksController(Net8ApiDbContext dbContext, ITaskRepository taskRepository, IMapper mapper)
        {
                this.dbContext = dbContext;
                this.taskRepository = taskRepository;
                this.mapper = mapper;
        }
        
        //Get all tasks
        // GET: http://localhost:portnumber/api/Tasks
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            //Get data fron Database - Domain models
            //var tasks = await dbContext.Tasks.ToListAsync();
            var tasksDomain = await taskRepository.GetAllTasksAsync();

            //Map domain models to DTOs
            var tasksDto = new List<TaskDto>();

            //foreach (var task in tasks)
            //{
            //    tasksDto.Add(new TaskDto
            //    {
            //        Id = task.Id,
            //        TaskName = task.TaskName,
            //        EstimatedHours = task.EstimatedHours,
            //        ActualHours = task.ActualHours,
            //        Status = task.Status
            //    });
            //}

            //using automapper 
            //mapper.Map<Destination Type>(Source type)
            var tasks = mapper.Map<List<TaskDto>>(tasksDomain);

            //Return DTOs
            return Ok(tasks);
        }


        //Get a task by id
        //GET: http://localhost:portnumber/api/Tasks/:id
        [HttpGet]
        [Route("{id:Guid}")]
        public async  Task<IActionResult> GetTaskById([FromRoute] Guid id)
        {
            //var task = dbContext.Tasks.Find(id); // Only filter by Primary Key
            // Fetching model data from the database
            var taskDomain = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id); // For any field

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

        //Create a new task
        //POST: http://localhost:portnumber/api/Tasks
        [HttpPost]
        public async Task<IActionResult> CreateATask([FromBody] AddTaskDto addTaskDto)
        {
            //Map or convert DTO to Domain model
            var taskDomainModel = new NET8API.Models.Domain.Task
            {
                TaskName = addTaskDto.TaskName,
                EstimatedHours = addTaskDto.EstimatedHours,
                ActualHours = addTaskDto.ActualHours,
                Status = addTaskDto.Status
            };

            //Use domain model to create a task
            await dbContext.Tasks.AddAsync(taskDomainModel);
            //Save changes to the database
            await dbContext.SaveChangesAsync();

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

        //Update a task by id
        //PUT: http://localhost:portnumber/api/Tasks/:id
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateATask([FromRoute] Guid id, [FromBody] UpdateTaskDto updateTaskDto )
        {
            var taskDomainModel = await dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (taskDomainModel ==  null)
            {
                return NotFound();
            }

            taskDomainModel.ActualHours = (double)updateTaskDto.ActualHours;
            taskDomainModel.Status = updateTaskDto.Status;

            await dbContext.SaveChangesAsync();

            var tasksDto = new TaskDto
            {
                Id = taskDomainModel.Id,
                TaskName = taskDomainModel.TaskName,
                EstimatedHours = taskDomainModel.EstimatedHours,
                ActualHours = taskDomainModel.ActualHours,
                Status = taskDomainModel.Status
            };

            return Ok(tasksDto);
        }

        //Delete a task by id
        //DELETE: http://localhost:portnumber/api/Tasks
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteATask([FromRoute] Guid id)
        {
            var taskDomainModel = await dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

             if(taskDomainModel == null)
            {
                return NotFound();
            }

            dbContext.Tasks.Remove(taskDomainModel);
            await dbContext.SaveChangesAsync();

            return Ok();
        } 

    }
}
