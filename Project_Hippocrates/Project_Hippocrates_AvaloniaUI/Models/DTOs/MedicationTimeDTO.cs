using System;
using System.Collections.ObjectModel;

namespace Project_Hippocrates_AvaloniaUI.Models.DTOs;

public class MedicationTimeDTO
{
    public Guid Id { get; set; }
    public string Label { get; set; } = String.Empty;
    public TimeSpan Time { get; set; } = new TimeSpan(12, 0, 0);
    public ObservableCollection<DrugDosageDTO> MedicationsTaken { get; set; } = [];
}