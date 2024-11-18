using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mapster;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates_AvaloniaUI.Mapping;

public class MedicationScheduleMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MedicationScheduleDTO, MedicationSchedule>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.MedicationTimes, src => src.MedicationTimes);

        config.NewConfig<MedicationSchedule, MedicationScheduleDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.MedicationTimes, src => ConvertMedicationTimes(src.MedicationTimes, config));
    }
    
    private ObservableCollection<MedicationTimeDTO> ConvertMedicationTimes(IEnumerable<MedicationTime> medicationTimes,
        TypeAdapterConfig config)
    {
        IEnumerable<MedicationTimeDTO> presenter = medicationTimes.Select((dosage, _) => dosage.Adapt<MedicationTimeDTO>(config));
        return new ObservableCollection<MedicationTimeDTO>(presenter);
    }
}