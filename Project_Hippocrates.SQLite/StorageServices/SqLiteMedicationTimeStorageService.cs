using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.Core.Interfaces.Storage;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.StorageServices;

public class SqLiteMedicationTimeStorageService : IMedicationTimeStorageService
{
    private readonly SqLiteDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public SqLiteMedicationTimeStorageService(SqLiteDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<bool> CreateAndJoinToScheduleAsync(Guid scheduleId, MedicationTime medicationTime)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            MedicationTimeEntity medicationTimeEntity = _mapper.Map<MedicationTimeEntity>(medicationTime);
            _dbContext.MedicationTimes.Add(medicationTimeEntity);
            await _dbContext.SaveChangesAsync();
            MedicationScheduleEntity medicationSchedule = await _dbContext.MedicationSchedules
                                                              .Include(ms => ms.MedicationTimes)
                                                              .FirstAsync(ms => ms.Id == scheduleId) 
                                                          ?? throw new ApplicationException("Schedule was not exist!");
            medicationSchedule.MedicationTimes
                .Add(medicationTimeEntity);
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e);
            return false;
        }
    }
}