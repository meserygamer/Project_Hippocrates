﻿using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates.TestEntityRepositories.Repositories;

public class DrugDosageRepository : IDomainEntityRepository<DrugDosage>
{
    public IEnumerable<DrugDosage> GetAll()
        => TestStorage.DrugDosages;
    public DrugDosage? GetById(Guid id)
        => TestStorage.DrugDosages.Find(d => d.Id == id);
    public bool Add(DrugDosage entity)
    {
        try
        {
            TestStorage.DrugDosages.Add(entity);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    public bool ChangeEntityById(Guid guid, DrugDosage newValue)
    {
        try
        {
            DrugDosage? drugDosage = GetById(guid);
            if (drugDosage is null)
                return false;
            newValue.Id = guid;
            TestStorage.DrugDosages.Remove(drugDosage);
            TestStorage.DrugDosages.Add(newValue);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<IEnumerable<DrugDosage>> GetAllAsync()
        => await Task.Run(GetAll);
    public async Task<DrugDosage?> GetByIdAsync(Guid id)
        => await Task.Run(() => GetById(id));
    public async Task<bool> AddAsync(DrugDosage entity)
        => await Task.Run(() => Add(entity));
    public async Task<bool> ChangeEntityByIdAsync(Guid guid, DrugDosage newValue)
        => await Task.Run(() => ChangeEntityById(guid, newValue));
}