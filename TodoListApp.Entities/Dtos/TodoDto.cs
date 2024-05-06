namespace TodoListApp.Entities.Dtos;

public class TodoDto
{
    public Guid id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
}