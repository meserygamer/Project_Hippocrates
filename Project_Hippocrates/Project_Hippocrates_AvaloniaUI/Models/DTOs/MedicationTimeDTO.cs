using System;
using System.Collections.ObjectModel;
using System.Text;

namespace Project_Hippocrates_AvaloniaUI.Models.DTOs;

public class MedicationTimeDTO
{
    public Guid Id { get; set; }
    public string Label { get; set; } = String.Empty;
    public TimeSpan Time { get; set; } = new TimeSpan(12, 0, 0);
    public ObservableCollection<DrugDosageDTO> MedicationsTaken { get; set; } = [];

    public string MedicationTakenList
    {
        get
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var drugDosage in MedicationsTaken) 
                stringBuilder.Append($"{drugDosage.DrugName} - {drugDosage.DrugDoseValue}{drugDosage.DoseUnit}\n");
            return stringBuilder.ToString();
        }
    }
}