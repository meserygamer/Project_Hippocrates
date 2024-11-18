using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates.Application.Services;

public class MedicationScheduleService
{
    private IDomainEntityRepository<MedicationSchedule> _repository;
    
    public MedicationScheduleService(IDomainEntityRepository<MedicationSchedule> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MedicationSchedule>> GetAllMedicationSchedules()
        => await _repository.GetAllAsync();
}