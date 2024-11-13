using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates.Application.Services;

public class MedicationTimeService
{
    private IDomainEntityRepository<MedicationTime> _repository;

    public MedicationTimeService(IDomainEntityRepository<MedicationTime> repository)
    {
        _repository = repository;
    }

    public bool CreateMedicationTime(MedicationTime medicationTime)
        => _repository.Add(medicationTime);
    public bool SaveMedicationTimeChanges(MedicationTime medicationTime)
        => _repository.Save(medicationTime);
    
    public async Task<bool> CreateMedicationTimeAsync(MedicationTime medicationTime)
        => await _repository.AddAsync(medicationTime);
    public async Task<bool> SaveMedicationTimeChangesAsync(MedicationTime medicationTime)
        => await _repository.SaveAsync(medicationTime);
}