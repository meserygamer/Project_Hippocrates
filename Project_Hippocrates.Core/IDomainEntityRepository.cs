namespace Project_Hippocrates.Core;

public interface IDomainEntityRepository<TEntity>
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(Guid id);
    bool Add(TEntity entity);
    bool ChangeEntityById(Guid guid, TEntity newValue);
    
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<bool> AddAsync(TEntity entity);
    Task<bool> ChangeEntityByIdAsync(Guid guid, TEntity newValue);
}