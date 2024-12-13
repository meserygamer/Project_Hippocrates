using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates.TestEntityRepositories.Repositories;

public class MedicationTimeRepository : IDomainEntityRepository<MedicationTime>
{
    public IEnumerable<MedicationTime> GetAll()
        => TestStorage.MedicationTimes;
    public MedicationTime? GetById(Guid id)
        => TestStorage.MedicationTimes.Find(m => m.Id == id);
    public bool Add(MedicationTime entity)
    {
        try
        {
            TestStorage.MedicationTimes.Add(entity);
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
            MedicationTime? medicationTime = GetById(newValue.Id);
            if (medicationTime is null)
                return false;
            TestStorage.MedicationTimes.Remove(medicationTime);
            TestStorage.MedicationTimes.Add(newValue);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<IEnumerable<MedicationTime>> GetAllAsync()
        => await Task.Run(GetAll);
    public async Task<MedicationTime?> GetByIdAsync(Guid id)
        => await Task.Run(() => GetById(id));
    public async Task<bool> AddAsync(MedicationTime entity)
        => await Task.Run(() => Add(entity));
    public async Task<bool> UpdateAsync(MedicationTime newValue)
        => await Task.Run(() => Update(newValue));
}