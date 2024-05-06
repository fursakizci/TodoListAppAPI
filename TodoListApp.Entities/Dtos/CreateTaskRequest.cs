using TaskStatus = TodoListApp.Entities.DbSet.TaskStatus;

namespace TodoListApp.Entities.Dtos;

public class CreateTaskRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreateDate { get; set; }
}