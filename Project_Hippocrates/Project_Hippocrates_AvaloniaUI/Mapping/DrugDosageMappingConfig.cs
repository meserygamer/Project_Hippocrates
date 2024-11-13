using Mapster;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates_AvaloniaUI.Mapping;

public class DrugDosageMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DrugDosagePresenter, DrugDosage>()
            .BeforeMapping(dest => dest.Drug = new MedicalDrug())
            .Map(dest => dest.Drug.Name, src => src.DrugName)
            .Map(dest => dest.DrugDoseValue, src => src.DrugDoseValue)
            .Map(dest => dest.DoseUnit, src => src.DoseUnit);
    }
}