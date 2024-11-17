using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates.TestEntityRepositories.Repositories;

public class MedicalDrugRepository : IDomainEntityRepository<MedicalDrug>
{
    public IEnumerable<MedicalDrug> GetAll()
        => TestStorage.MedicalDrugs;
    public MedicalDrug? GetById(Guid id)
        => TestStorage.MedicalDrugs.Find(m => m.Id == id);
    public bool Add(MedicalDrug entity)
    {
        try
        {
            TestStorage.MedicalDrugs.Add(entity);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    public bool ChangeEntityById(Guid guid, MedicalDrug newValue)
    {
        try
        {
            MedicalDrug? medicalDrug = GetById(guid);
            if (medicalDrug is null)
                return false;
            newValue.Id = guid;
            TestStorage.MedicalDrugs.Remove(medicalDrug);
            TestStorage.MedicalDrugs.Add(newValue);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<IEnumerable<MedicalDrug>> GetAllAsync()
        => await Task.Run(GetAll);
    public async Task<MedicalDrug?> GetByIdAsync(Guid id)
        => await Task.Run(() => GetById(id));
    public async Task<bool> AddAsync(MedicalDrug entity)
        => await Task.Run(() => Add(entity));
    public async Task<bool> ChangeEntityByIdAsync(Guid guid, MedicalDrug newValue)
        => await Task.Run(() => ChangeEntityById(guid, newValue));
}