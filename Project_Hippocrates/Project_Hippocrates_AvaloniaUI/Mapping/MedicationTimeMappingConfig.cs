using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mapster;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates_AvaloniaUI.Mapping;

public class MedicationTimeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MedicationTimeDTO, MedicationTime>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Time, src => src.Time)
            .Map(dest => dest.MedicationsTaken, src => src.MedicationsTaken)
            .Map(dest => dest.NotificationId, src => src.NotificationId);
        
        config.NewConfig<MedicationTime, MedicationTimeDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Time, src => src.Time)
            .Map(dest => dest.MedicationsTaken, src => ConvertMedicationTaken(src.MedicationsTaken, config))
            .Map(dest => dest.NotificationId, src => src.NotificationId);;
    }

    private static ObservableCollection<DrugDosageDTO> ConvertMedicationTaken(IEnumerable<DrugDosage> drugDosages, TypeAdapterConfig config)
    {
        IEnumerable<DrugDosageDTO> presenter = drugDosages.Select((dosage, _) => dosage.Adapt<DrugDosageDTO>(config));
        return new ObservableCollection<DrugDosageDTO>(presenter);
    }
}