using System;
using System.Collections.ObjectModel;

namespace Project_Hippocrates_AvaloniaUI.Models.DTOs;

public class MedicationScheduleDTO
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public ObservableCollection<MedicationTimeDTO> MedicationTimes { get; set; } = null!;
}