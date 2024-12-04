using Mapster;
using Project_Hippocrates.Core.Entities;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Mapping;

public class DrugDosageEntityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DrugDosageEntity, DrugDosage>()
            .Map(dest => dest.Id, source => source.Id)
            .Map(dest => dest.DrugDoseValue, source => source.Value)
            .Map(dest => dest.DoseUnit, source => source.Unit)
            .Map(dest => dest.Drug, source => source.Drug.Adapt<MedicalDrug>(config));
        
        config.NewConfig<DrugDosage, DrugDosageEntity>()
            .Map(dest => dest.Id, source => source.Id)
            .Map(dest => dest.Value, source => source.DrugDoseValue)
            .Map(dest => dest.Unit, source => source.DoseUnit)
            .Map(dest => dest.Drug, source => source.Drug.Adapt<MedicalDrugEntity>(config));
    }
}