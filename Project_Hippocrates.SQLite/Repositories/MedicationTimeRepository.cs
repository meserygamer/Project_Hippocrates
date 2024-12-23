using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Repositories;

public class MedicationTimeRepository : IDomainEntityRepository<MedicationTime>
{
    private readonly SqLiteDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public MedicationTimeRepository(SqLiteDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<MedicationTime> GetAll() => 
        _dbContext.MedicationTimes
            .ProjectToType<MedicationTime>(_mapper.Config);

    public MedicationTime? GetById(Guid id) =>
        _dbContext.MedicationTimes
            .ProjectToType<MedicationTime>(_mapper.Config)
            .FirstOrDefault(ms => ms.Id == id);

    public bool Add(MedicationTime entity)
    {
        try
        {
            var dbEntity = _mapper.Map<MedicationTimeEntity>(entity);
            _dbContext.MedicationTimes.Add(dbEntity);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool Update(MedicationTime newValue)
    {
        try
        {
            var newDbValue = _mapper.Map<MedicationTimeEntity>(newValue);
            _dbContext.MedicationTimes.Update(newDbValue);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<IEnumerable<MedicationTime>> GetAllAsync() => 
        await Task.Run(() => _dbContext.MedicationTimes
            .ProjectToType<MedicationTime>(_mapper.Config));

    public async Task<MedicationTime?> GetByIdAsync(Guid id) => 
        await _dbContext.MedicationTimes
            .Include(mt => mt.MedicationsTaken)
            .ThenInclude(d => d.Drug)
            .ProjectToType<MedicationTime>(_mapper.Config)
            .FirstOrDefaultAsync(ms => ms.Id == id);

    public async Task<bool> AddAsync(MedicationTime entity)
    {
        try
        {
            var dbEntity = _mapper.Map<MedicationTimeEntity>(entity);
            _dbContext.MedicationTimes.Add(dbEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> UpdateAsync(MedicationTime newValue)
    {
        try
        {
            var newDbValue = _mapper.Map<MedicationTimeEntity>(newValue);
            _dbContext.MedicationTimes.Update(newDbValue);
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