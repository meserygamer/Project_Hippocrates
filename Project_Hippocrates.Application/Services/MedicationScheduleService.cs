using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates.Application.Services;

public class MedicationScheduleService
{
    private IDomainEntityRepository<MedicationSchedule> _medicationScheduleRepository;
    
    public MedicationScheduleService(IDomainEntityRepository<MedicationSchedule> medicationScheduleRepository)
    {
        _medicationScheduleRepository = medicationScheduleRepository;
    }

    public async Task<IEnumerable<MedicationSchedule>> GetAllMedicationSchedules()
        => await _medicationScheduleRepository.GetAllAsync();

    public async Task<bool> TryRemoveMedicationTimeFromScheduleAsync(Guid medicationScheduleId,
        Guid removingMedicationTimeId)
    {
        var medicationSchedule = await _medicationScheduleRepository.GetByIdAsync(medicationScheduleId);
        
        if (medicationSchedule!.MedicationTimes.FirstOrDefault(mt => mt.Id == removingMedicationTimeId) is null)
            return false;
        IEnumerable<MedicationTime> newMedicationTimes = medicationSchedule.MedicationTimes.Where(mt => mt.Id != removingMedicationTimeId);
        medicationSchedule.MedicationTimes = newMedicationTimes;
        return await _medicationScheduleRepository.ChangeEntityByIdAsync(medicationScheduleId, medicationSchedule);
    }

    public async Task<IEnumerable<MedicationTime>> GetMedicationTimesByScheduleAsync(Guid medicationScheduleId)
        => await _medicationScheduleRepository.GetByIdAsync(medicationScheduleId)
                                              .ContinueWith(t => t.Result!.MedicationTimes);
}