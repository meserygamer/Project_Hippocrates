using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        
        config.NewConfig<MedicationTime, MedicationTimePresenter>()
            .Map(dest => dest.DrugId, src => src.Id)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Time, src => src.Time)
            .Map(dest => dest.MedicationsTaken, src => ConvertMedicationTaken(src.MedicationsTaken));
    }

    private static ObservableCollection<DrugDosagePresenter> ConvertMedicationTaken(IEnumerable<DrugDosage> drugDosages)
    {
        IEnumerable<DrugDosagePresenter> presenter = drugDosages.Select((dosage, _) => dosage.Adapt<DrugDosagePresenter>());
        return new ObservableCollection<DrugDosagePresenter>(presenter);
    }
}