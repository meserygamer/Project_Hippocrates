using System;
using System.Collections.ObjectModel;

namespace Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;

public class MedicationTimePresenter
{
    public Guid DrugId { get; set; }
    public string Label { get; set; } = String.Empty;
    public TimeSpan Time { get; set; } = new TimeSpan(12, 0, 0);
    public ObservableCollection<DrugDosagePresenter> MedicationsTaken { get; set; } = [];
}