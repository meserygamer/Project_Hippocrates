using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Repositories;

public class DrugDosageRepository : IDomainEntityRepository<DrugDosage>
{
    private readonly SqLiteDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public DrugDosageRepository(SqLiteDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public IEnumerable<DrugDosage> GetAll() =>
        _dbContext.DrugDosages
            .ProjectToType<DrugDosage>(_mapper.Config);

    public DrugDosage? GetById(Guid id) =>
        _dbContext.DrugDosages
            .ProjectToType<DrugDosage>(_mapper.Config)
            .FirstOrDefault(d => d.Id == id);

    public bool Add(DrugDosage entity)
    {
        try
        {
            var dbEntity = _mapper.Map<DrugDosageEntity>(entity);
            _dbContext.DrugDosages.Add(dbEntity);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool Update(DrugDosage newValue)
    {
        try
        {
            var newDbValue = _mapper.Map<DrugDosageEntity>(newValue);
            _dbContext.DrugDosages.Update(newDbValue);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<IEnumerable<DrugDosage>> GetAllAsync() =>
        await Task.Run(() => _dbContext.DrugDosages
            .ProjectToType<DrugDosage>(_mapper.Config));

    public async Task<DrugDosage?> GetByIdAsync(Guid id) => 
        await _dbContext.DrugDosages
            .ProjectToType<DrugDosage>(_mapper.Config)
            .FirstOrDefaultAsync(d => d.Id == id); 

    public async Task<bool> AddAsync(DrugDosage entity)
    {
        try
        {
            var dbEntity = _mapper.Map<DrugDosageEntity>(entity);
            _dbContext.DrugDosages.Add(dbEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> UpdateAsync(DrugDosage newValue)
    {
        try
        {
            var newDbValue = _mapper.Map<DrugDosageEntity>(newValue);
            _dbContext.DrugDosages.Update(newDbValue);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}