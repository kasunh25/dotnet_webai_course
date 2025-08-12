using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NET8API.Controllers
{
    //http://localhost:portnumber/api/tasks
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // GET: api/tasks
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            string[] tasks = new string[]
            {
                "Task 1",
                "Task 2",
                "Task 3"
            };

            return Ok(tasks);
        }
    }
}
