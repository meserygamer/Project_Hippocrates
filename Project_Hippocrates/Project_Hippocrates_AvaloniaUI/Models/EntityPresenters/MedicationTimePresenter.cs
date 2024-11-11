using System;
using System.Collections.ObjectModel;

namespace Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;

public class MedicationTimePresenter
{
    public string Label { get; set; } = String.Empty;
    public TimeSpan Time { get; set; } = TimeSpan.Zero;
    public ObservableCollection<DrugDosagePresenter> MedicationsTaken { get; set; } = [];
}