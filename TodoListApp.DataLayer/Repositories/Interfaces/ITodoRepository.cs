using TodoListApp.Entities.DbSet;
using TaskStatus = TodoListApp.Entities.DbSet.TaskStatus;

namespace TodoListApp.DataLayer.Repositories.Interfaces;

public interface ITodoRepository:IGenericRepository<Todo>
{
    Task<IEnumerable<Todo>> GetTodoByStatus(TaskStatus status);
}