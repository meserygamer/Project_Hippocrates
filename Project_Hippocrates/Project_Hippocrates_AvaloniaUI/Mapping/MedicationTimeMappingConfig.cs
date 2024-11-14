using Mapster;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates_AvaloniaUI.Mapping;

public class MedicationTimeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MedicationTimePresenter, MedicationTime>()
            .Map(dest => dest.Id, src => src.DrugId)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Time, src => src.Time)
            .Map(dest => dest.MedicationsTaken, src => src.MedicationsTaken);
    }
}