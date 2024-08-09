using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBackend.Models;
using TaskBackend.TaskDBContext;
using static TaskBackend.response.TaskResponse;

namespace TaskBackend.Repo
{
    public class TaskRepo : ITaskRepo
    {

        public readonly TaskDbContext _taskDBContext;

        public TaskRepo(TaskDbContext taskDbContext)
        {
            _taskDBContext = taskDbContext;
        }
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetTask()
        {
            try
            {
                return await _taskDBContext.task.ToListAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TaskItemResponse> GetTask(int id)
        {
            try
            {
                var Task = await _taskDBContext.task.FindAsync(id);

                if (Task == null)
                {
                    return new TaskItemResponse(false, Task, "Task Not Found");
                }

                return new TaskItemResponse(true, Task, "Task Created");
            }
            catch (Exception ex)
            {
                return new TaskItemResponse(true, null, "Error at Get Task By Email");

            }

        }


        public async Task<TaskItemResponse> UpdateTask(TaskModel task)
        {

            _taskDBContext.task.Update(task);


            try
            {
                await _taskDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return new TaskItemResponse(false, null, "Update Failed ");

            }

            var result = _taskDBContext.task.Find(task.Id);

            return new TaskItemResponse(true, result, "Success");
        }


        public async Task<TaskItemResponse> AddTask(TaskModel task)
        {
            try
            {

                _taskDBContext.task.Add(task);
                await _taskDBContext.SaveChangesAsync();

                return new TaskItemResponse(true, task, "Task Added");
            }
            catch (Exception ex)
            {
                return new TaskItemResponse(false, null, "Create Task Failed");
            }


        }


        public async Task<TaskItemResponse> DeleteTask(int id)
        {
            try
            {
                var Task = await _taskDBContext.task.FindAsync(id);
                if (Task == null)
                {
                    return new TaskItemResponse(false, null, "Task Not Found");
                }

                _taskDBContext.task.Remove(Task);
                await _taskDBContext.SaveChangesAsync();

                return new TaskItemResponse(true, null, "Task Deleted");
            }
            catch (Exception ex)
            {
                return new TaskItemResponse(false, null, "Delete Task Failed");

            }

        }


    }
}
