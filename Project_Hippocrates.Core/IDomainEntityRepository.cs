namespace Project_Hippocrates.Core;

public interface IDomainEntityRepository<TEntity>
{
    IEnumerable<TEntity> GetAll();
    TEntity GetById(Guid id);
    TEntity Save(TEntity newValue);
}