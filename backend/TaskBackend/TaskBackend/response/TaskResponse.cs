using TaskBackend.Models;

namespace TaskBackend.response
{
    public class TaskResponse
    {
        public record class TaskItemResponse( bool result , TaskModel? task , string message);
    }
}
