namespace Project_Hippocrates.Core;

public interface IDomainEntityRepository<TEntity>
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(Guid id);
    bool Add(TEntity entity);
    bool Save(TEntity newValue);
    
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<bool> AddAsync(TEntity entity);
    Task<bool> SaveAsync(TEntity newValue);
}