namespace TodoListApp.Entities.DbSet;

public class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedDate  { get; private set; }

    protected BaseEntity()
    {
        CreatedDate = DateTime.UtcNow;
    }
}