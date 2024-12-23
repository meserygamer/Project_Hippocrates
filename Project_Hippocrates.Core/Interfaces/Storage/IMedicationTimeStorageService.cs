using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates.Core.Interfaces.Storage;

public interface IMedicationTimeStorageService
{
    Task<bool> CreateAndJoinToScheduleAsync(Guid scheduleId, MedicationTime medicationTime);
}