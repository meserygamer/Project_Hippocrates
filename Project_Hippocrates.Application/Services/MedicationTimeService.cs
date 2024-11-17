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
    public bool ChangeEntityById(Guid guid, MedicationTime medicationTime)
        => _repository.ChangeEntityById(guid, medicationTime);
    
    public async Task<bool> CreateMedicationTimeAsync(MedicationTime medicationTime)
        => await _repository.AddAsync(medicationTime);
    public async Task<bool> ChangeEntityByIdAsync(Guid guid, MedicationTime medicationTime)
        => await _repository.ChangeEntityByIdAsync(guid, medicationTime);
    public async Task<MedicationTime?> FindMedicationTimeByIdAsync(Guid id)
        => await _repository.GetByIdAsync(id);
}