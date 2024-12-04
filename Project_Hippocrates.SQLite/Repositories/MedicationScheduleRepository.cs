using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Repositories;

public class MedicationScheduleRepository : IDomainEntityRepository<MedicationSchedule>
{
    private readonly SqLiteDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public MedicationScheduleRepository(SqLiteDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<MedicationSchedule> GetAll() =>
        _dbContext.MedicationSchedules
            .ProjectToType<MedicationSchedule>(_mapper.Config);

    public MedicationSchedule? GetById(Guid id) => _dbContext.MedicationSchedules
        .ProjectToType<MedicationSchedule>(_mapper.Config)
        .FirstOrDefault(ms => ms.Id == id);

    public bool Add(MedicationSchedule entity)
    {
        try
        {
            var dbEntity = _mapper.Map<MedicationScheduleEntity>(entity);
            _dbContext.MedicationSchedules.Add(dbEntity);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool ChangeEntityById(Guid guid, MedicationSchedule newValue)
    {
        try
        {
            MedicationScheduleEntity dbEntity = _dbContext.MedicationSchedules.Find(guid) 
                                                ?? throw new Exception($"MedicationSchedule with id:{guid} was not found!");
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

    public async Task<IEnumerable<MedicationSchedule>> GetAllAsync() => 
        await Task.Run(() => _dbContext.MedicationSchedules
            .ProjectToType<MedicationSchedule>(_mapper.Config));
    
    public async Task<MedicationSchedule?> GetByIdAsync(Guid id) => 
        await _dbContext.MedicationSchedules
            .ProjectToType<MedicationSchedule>(_mapper.Config)
            .FirstOrDefaultAsync(ms => ms.Id == id);

    public async Task<bool> AddAsync(MedicationSchedule entity)
    {
        try
        {
            var dbEntity = _mapper.Map<MedicationScheduleEntity>(entity);
            _dbContext.MedicationSchedules.Add(dbEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> ChangeEntityByIdAsync(Guid guid, MedicationSchedule newValue)
    {
        try
        {
            MedicationScheduleEntity dbEntity = await _dbContext.MedicationSchedules.FindAsync(guid) 
                                                ?? throw new Exception($"MedicationSchedule with id:{guid} was not found!");
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

    private void CopyEntityFromCore(MedicationScheduleEntity dest, MedicationSchedule source)
    {
        dest.Id = source.Id;
        dest.Name = source.Name;
        dest.MedicationTimes = source.MedicationTimes
            .AsQueryable()
            .ProjectToType<MedicationTimeEntity>(_mapper.Config)
            .ToList();
    }
}