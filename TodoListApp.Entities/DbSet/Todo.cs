namespace TodoListApp.Entities.DbSet;

public class Todo:BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
    public DateTime UpdatedDate { get; set; }
}