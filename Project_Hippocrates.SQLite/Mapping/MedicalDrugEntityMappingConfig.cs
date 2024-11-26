using Mapster;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Mapping;

public class MedicalDrugEntityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MedicalDrugEntity, MedicalDrug>()
            .Map(dest => dest.Id, source => source.Id)
            .Map(dest => dest.Name, source => source.Name);
        
        config.NewConfig<MedicalDrug, MedicalDrugEntity>()
            .Map(dest => dest.Id, source => source.Id)
            .Map(dest => dest.Name, source => source.Name);
    }
}