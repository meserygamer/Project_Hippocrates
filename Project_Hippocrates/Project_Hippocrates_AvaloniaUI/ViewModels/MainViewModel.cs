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
                new DrugDosage { Drug = new MedicalDrug() { Name = "Test Drug 1" }, DrugDoseValue=1, DoseUnit="т." },
                new DrugDosage { Drug = new MedicalDrug() { Name = "Test Drug 2" }, DrugDoseValue=12, DoseUnit="кап." },
                new DrugDosage { Drug = new MedicalDrug() { Name = "Test Drug 3" }, DrugDoseValue=25, DoseUnit="мл." },
            ];
            
            ObservableCollection<MedicationTime> medicationTimes = [
                new MedicationTime { Label = "Label1", Time = new TimeSpan(12,0,0), MedicationsTaken = drugDosages },
                new MedicationTime { Label = "Label2", Time = new TimeSpan(14,0,0), MedicationsTaken = drugDosages },
                new MedicationTime { Label = "Label3", Time = new TimeSpan(16,0,0), MedicationsTaken = drugDosages },
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
