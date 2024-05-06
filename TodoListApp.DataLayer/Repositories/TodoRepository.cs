using Microsoft.EntityFrameworkCore;
using TodoListApp.DataLayer.DataAccess;
using TodoListApp.DataLayer.Repositories.Interfaces;
using TodoListApp.Entities.DbSet;
using TaskStatus = TodoListApp.Entities.DbSet.TaskStatus;

namespace TodoListApp.DataLayer.Repositories;

public class TodoRepository:GenericRepository<Todo>,ITodoRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Todo> _dbSet;
    
    public TodoRepository(AppDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<Todo>();
    }

    public async Task<IEnumerable<Todo>> GetTodoByStatus(TaskStatus status)
    {
        var items = await _dbSet.Where(item => item.Status == status).ToListAsync();
        return items;
    }
}