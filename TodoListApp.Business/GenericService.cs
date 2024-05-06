using TodoListApp.Business.Interfaces;
using TodoListApp.DataLayer.Repositories.Interfaces;

namespace TodoListApp.Business;

public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
{
    private readonly IGenericRepository<TEntity> _repository;

    public GenericService(IGenericRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    { 
        await _repository.DeleteAsync(id);
        
    }
}