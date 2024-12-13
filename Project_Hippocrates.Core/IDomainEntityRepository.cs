namespace Project_Hippocrates.Core;

public interface IDomainEntityRepository<TEntity>
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(Guid id);
    bool Add(TEntity entity);
    bool Update(TEntity newValue);
    
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<bool> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity newValue);
}