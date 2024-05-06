using TodoListApp.Entities.DbSet;
using TodoListApp.Entities.Dtos;
using TaskStatus = TodoListApp.Entities.DbSet.TaskStatus;

namespace TodoListApp.Business.Interfaces;

public interface ITodoService:IGenericService<Todo>
{
    Task<IEnumerable<TodoDto>> GetAll();
    Task<IEnumerable<TodoDto>> GetAllByStatus(TaskStatus status);
}