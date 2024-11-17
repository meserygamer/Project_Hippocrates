using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates.TestEntityRepositories.Repositories;

public class MedicationScheduleRepository : IDomainEntityRepository<MedicationSchedule>
{
    public IEnumerable<MedicationSchedule> GetAll()
        => TestStorage.MedicationSchedules;
    public MedicationSchedule? GetById(Guid id)
        => TestStorage.MedicationSchedules.Find(m => m.Id == id);
    public bool Add(MedicationSchedule entity)
    {
        try
        {
            TestStorage.MedicationSchedules.Add(entity);
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
            MedicationSchedule? medicationSchedule = GetById(guid);
            if (medicationSchedule is null)
                return false;
            newValue.Id = guid;
            TestStorage.MedicationSchedules.Remove(medicationSchedule);
            TestStorage.MedicationSchedules.Add(newValue);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<IEnumerable<MedicationSchedule>> GetAllAsync()
        => await Task.Run(GetAll);
    public async Task<MedicationSchedule?> GetByIdAsync(Guid id)
        => await Task.Run(() => GetById(id));
    public async Task<bool> AddAsync(MedicationSchedule entity)
        => await Task.Run(() => Add(entity));
    public async Task<bool> ChangeEntityByIdAsync(Guid guid, MedicationSchedule newValue)
        => await Task.Run(() => ChangeEntityById(guid, newValue));
}