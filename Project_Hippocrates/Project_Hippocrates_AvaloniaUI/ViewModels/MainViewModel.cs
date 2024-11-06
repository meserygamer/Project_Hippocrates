using CommunityToolkit.Mvvm.ComponentModel;
using Project_Hippocrates.Core.Entities;
using System.Collections.ObjectModel;

namespace Project_Hippocrates_AvaloniaUI.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<MedicationTime> _testCollection = [
            
            new MedicationTime { Label = "Label1", Time = new System.TimeOnly(12, 0), MedicationsTaken = _testCollection2 },
            new MedicationTime { Label = "Label2", Time = new System.TimeOnly(14, 0), MedicationsTaken = _testCollection2 },
            new MedicationTime { Label = "Label3", Time = new System.TimeOnly(16, 0), MedicationsTaken = _testCollection2 },
            ];

        private static ObservableCollection<DrugDosage> _testCollection2 = [

            new DrugDosage() { Drug = new MedicalDrug() { Name = "Test Drug 1" }, DosageValue=1, DosageUnit="т." },
            new DrugDosage() { Drug = new MedicalDrug() { Name = "Test Drug 2" }, DosageValue=12, DosageUnit="кап." },
            new DrugDosage() { Drug = new MedicalDrug() { Name = "Test Drug 3" }, DosageValue=25, DosageUnit="мл." },
            ];
    }
}
