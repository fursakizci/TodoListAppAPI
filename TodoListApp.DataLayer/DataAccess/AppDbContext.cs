using Microsoft.EntityFrameworkCore;
using TodoListApp.Entities.DbSet;

namespace TodoListApp.DataLayer.DataAccess;

public class AppDbContext(DbContextOptions<AppDbContext>options):DbContext(options)
{
    public DbSet<Todo> Tasks { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("TodoList");
    }
}