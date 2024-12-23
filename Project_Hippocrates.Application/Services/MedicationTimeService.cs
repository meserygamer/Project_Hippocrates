using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.Core.Interfaces.Storage;

namespace Project_Hippocrates.Application.Services;

public class MedicationTimeService
{
    private readonly IDomainEntityRepository<MedicationTime> _medicationTimeRepository;
    private readonly IMedicationTimeStorageService _medicationTimeStorageService;

    public MedicationTimeService(IDomainEntityRepository<MedicationTime> medicationTimeRepository,
        IMedicationTimeStorageService medicationTimeStorageService)
    {
        _medicationTimeRepository = medicationTimeRepository;
        _medicationTimeStorageService = medicationTimeStorageService;
    }

    public async Task<bool> CreateAndJoinToScheduleAsync(Guid scheduleId, MedicationTime medicationTime)
    {
        medicationTime.Id = Guid.NewGuid();
        medicationTime.MedicationsTaken = new List<DrugDosage>(medicationTime.MedicationsTaken);
        foreach (var drugDose in medicationTime.MedicationsTaken)
        {
            drugDose.Id = Guid.NewGuid();
            if (drugDose.Drug.Id == Guid.Empty)
                drugDose.Drug.Id = Guid.NewGuid();
        }
            
        return await _medicationTimeStorageService.CreateAndJoinToScheduleAsync(scheduleId, medicationTime);
    }
    public async Task<bool> CreateMedicationTimeAsync(MedicationTime medicationTime)
        => await _medicationTimeRepository.AddAsync(medicationTime);
    public async Task<bool> UpdateMedicationTimeAsync(MedicationTime medicationTime)
        => await _medicationTimeRepository.UpdateAsync(medicationTime);
    public async Task<MedicationTime?> FindMedicationTimeByIdAsync(Guid id)
        => await _medicationTimeRepository.GetByIdAsync(id);
    public async Task<IEnumerable<int>> GetAllBusyNotificationIdAsync()
        => (await _medicationTimeRepository.GetAllAsync()).Select((mt, id) => mt.NotificationId);
}