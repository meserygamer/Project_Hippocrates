using Mapster;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates_AvaloniaUI.Mapping;

public class DrugDosageMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DrugDosageDTO, DrugDosage>()
            .BeforeMapping(dest => dest.Drug = new MedicalDrug())
            .Map(dest => dest.Id, src => src.DrugId)
            .Map(dest => dest.Drug.Name, src => src.DrugName)
            .Map(dest => dest.DrugDoseValue, src => src.DrugDoseValue)
            .Map(dest => dest.DoseUnit, src => src.DoseUnit);
        
        config.NewConfig<DrugDosage, DrugDosageDTO>()
            .Map(dest => dest.DrugId, src => src.Id)
            .Map(dest => dest.DrugName, src => src.Drug.Name)
            .Map(dest => dest.DrugDoseValue, src => src.DrugDoseValue)
            .Map(dest => dest.DoseUnit, src => src.DoseUnit);
    }
}