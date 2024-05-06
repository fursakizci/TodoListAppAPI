namespace TodoListApp.Entities.Dtos;

public class UpdateTaskRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime UpdateDate { get; set; }
}