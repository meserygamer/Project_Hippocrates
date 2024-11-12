using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Project_Hippocrates.Core.Entities;
using System.Collections.ObjectModel;

namespace Project_Hippocrates_AvaloniaUI.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        [ObservableProperty] private ObservableCollection<MedicationSchedule> _medicationSchedules;
        [ObservableProperty] private ObservableCollection<MedicationTime>? _medicationTimes;
        
        private MedicationSchedule? _selectedMedicationSchedule;
        
        public MainViewModel()
        {
            ObservableCollection<DrugDosage> drugDosages = [
                new DrugDosage { Drug = new MedicalDrug() { Name = "Test Drug 1" }, DosageValue=1, DosageUnit="т." },
                new DrugDosage { Drug = new MedicalDrug() { Name = "Test Drug 2" }, DosageValue=12, DosageUnit="кап." },
                new DrugDosage { Drug = new MedicalDrug() { Name = "Test Drug 3" }, DosageValue=25, DosageUnit="мл." },
            ];
            
            ObservableCollection<MedicationTime> medicationTimes = [
                new MedicationTime { Label = "Label1", Time = new System.TimeOnly(12, 0), MedicationsTaken = drugDosages },
                new MedicationTime { Label = "Label2", Time = new System.TimeOnly(14, 0), MedicationsTaken = drugDosages },
                new MedicationTime { Label = "Label3", Time = new System.TimeOnly(16, 0), MedicationsTaken = drugDosages },
            ];
            
            _medicationSchedules = [
                new MedicationSchedule {Id = Guid.NewGuid(), MedicationTimes = [medicationTimes[0], medicationTimes[1]], Name = "TestSchedule_1"},
                new MedicationSchedule {Id = Guid.NewGuid(), MedicationTimes = [medicationTimes[2]], Name = "TestSchedule_2"}
            ];

            SelectedMedicationSchedule = _medicationSchedules[0];
        }

        public MedicationSchedule? SelectedMedicationSchedule
        {
            get => _selectedMedicationSchedule;
            set
            {
                SetProperty(ref _selectedMedicationSchedule, value);
                OnSelectedMedicationScheduleChanged();
            }
        }

        private void OnSelectedMedicationScheduleChanged()
        {
            MedicationTimes = new ObservableCollection<MedicationTime>(SelectedMedicationSchedule?.MedicationTimes ?? []);
        }
    }
}
