using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskBackend.Models;
using TaskBackend.Repo;

namespace TaskBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public readonly ITaskRepo _taskRepo;
        public TaskController(ITaskRepo taskRepo)
        {
              _taskRepo = taskRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetTask()
        {
            return Ok(await _taskRepo.GetTask());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTask(int id)
        {
            var Task = await _taskRepo.GetTask(id);

            if (Task == null)
            {
                return NotFound();
            }

            return Ok(Task);
        }

        [HttpPut()]
        public async Task<IActionResult> PutTask(TaskModel Task)
        {
            var createdTask = await _taskRepo.UpdateTask(Task);

            return Ok(createdTask);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostTask(TaskModel Task)
        {
            var createdTask = await _taskRepo.AddTask(Task);

            return Ok(createdTask);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var Task = await _taskRepo.DeleteTask(id);
            return Ok(Task);
        }


    }
}
