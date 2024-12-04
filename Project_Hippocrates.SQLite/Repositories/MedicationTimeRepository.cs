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

    public bool ChangeEntityById(Guid guid, MedicationTime newValue)
    {
        try
        {
            MedicationTimeEntity dbEntity = _dbContext.MedicationTimes.Find(guid) 
                                                ?? throw new Exception($"MedicationTime with id:{guid} was not found!");
            CopyEntityFromCore(dbEntity, newValue);
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

    public async Task<bool> ChangeEntityByIdAsync(Guid guid, MedicationTime newValue)
    {
        try
        {
            MedicationTimeEntity dbEntity = await _dbContext.MedicationTimes.FindAsync(guid) 
                                            ?? throw new Exception($"MedicationTime with id:{guid} was not found!");
            CopyEntityFromCore(dbEntity, newValue);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    private void CopyEntityFromCore(MedicationTimeEntity dest, MedicationTime source)
    {
        dest.Id = source.Id;
        dest.Label = source.Label;
        dest.Time = source.Time;
        dest.PushNotificationId = source.NotificationId;
        dest.MedicationsTaken = source.MedicationsTaken
            .AsQueryable()
            .ProjectToType<DrugDosageEntity>(_mapper.Config)
            .ToList();
    }
}