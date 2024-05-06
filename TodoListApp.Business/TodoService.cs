using TodoListApp.Business.Interfaces;
using TodoListApp.DataLayer.Repositories.Interfaces;
using TodoListApp.Entities.DbSet;
using TodoListApp.Entities.Dtos;
using TaskStatus = TodoListApp.Entities.DbSet.TaskStatus;

namespace TodoListApp.Business;

public class TodoService : GenericService<Todo>, ITodoService
{
    private readonly ITodoRepository _todoRepository;
    
    public TodoService(ITodoRepository repository) : base(repository)
    {
        _todoRepository = repository;
    }

    public async Task<IEnumerable<TodoDto>> GetAll()
    {
        var todos = await _todoRepository.GetAllAsync();
        return todos.Select(todo => new TodoDto()
        {
            id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            Status = todo.Status.ToString(),
            CreatedDate = todo.CreatedDate
        }).ToList();
    }

    public async Task<IEnumerable<TodoDto>> GetAllByStatus(TaskStatus status)
    {
        var todos = await _todoRepository.GetTodoByStatus(status);
        return todos.Select(todo => new TodoDto()
        {
            id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            Status = todo.Status.ToString(),
            CreatedDate = todo.UpdatedDate
        }).ToList();
    }
}