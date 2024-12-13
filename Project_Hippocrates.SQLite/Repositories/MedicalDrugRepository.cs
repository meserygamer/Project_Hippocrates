using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Repositories;

public class MedicalDrugRepository : IDomainEntityRepository<MedicalDrug>
{
    private readonly SqLiteDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public MedicalDrugRepository(SqLiteDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<MedicalDrug> GetAll() => 
        _dbContext.MedicalDrugs
            .ProjectToType<MedicalDrug>(_mapper.Config);

    public MedicalDrug? GetById(Guid id) =>
        _dbContext.MedicalDrugs
            .ProjectToType<MedicalDrug>(_mapper.Config)
            .FirstOrDefault(d => d.Id == id);

    public bool Add(MedicalDrug entity)
    {
        try
        {
            var dbEntity = _mapper.Map<MedicalDrugEntity>(entity);
            _dbContext.MedicalDrugs.Add(dbEntity);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool Update(MedicalDrug newValue)
    {
        try
        {
            var newDbValue = _mapper.Map<MedicalDrugEntity>(newValue);
            _dbContext.MedicalDrugs.Update(newDbValue);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<IEnumerable<MedicalDrug>> GetAllAsync() => 
        await Task.Run(() => _dbContext.MedicalDrugs
            .ProjectToType<MedicalDrug>(_mapper.Config));

    public async Task<MedicalDrug?> GetByIdAsync(Guid id) => 
        await _dbContext.MedicalDrugs
            .ProjectToType<MedicalDrug>(_mapper.Config)
            .FirstOrDefaultAsync(d => d.Id == id);

    public async Task<bool> AddAsync(MedicalDrug entity)
    {
        try
        {
            var dbEntity = _mapper.Map<MedicalDrugEntity>(entity);
            _dbContext.MedicalDrugs.Add(dbEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> UpdateAsync(MedicalDrug newValue)
    {
        try
        {
            var newDbValue = _mapper.Map<MedicalDrugEntity>(newValue);
            _dbContext.MedicalDrugs.Update(newDbValue);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}