using Microsoft.AspNetCore.Mvc;
using TaskBackend.Models;
using TaskBackend.response;

namespace TaskBackend.Repo
{
    public interface ITaskRepo
    {
        Task<TaskResponse.TaskItemResponse> AddTask(TaskModel task);
        Task<TaskResponse.TaskItemResponse> DeleteTask(int id);
        Task<ActionResult<IEnumerable<TaskModel>>> GetTask();
        Task<TaskResponse.TaskItemResponse> GetTask(int id);
        Task<TaskResponse.TaskItemResponse> UpdateTask(TaskModel task);
    }
}