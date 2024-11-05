using CommunityToolkit.Mvvm.ComponentModel;
using Project_Hippocrates.Core.Entities;
using System.Collections.ObjectModel;

namespace Project_Hippocrates_AvaloniaUI.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<MedicationTime> _testCollection = [
            
            new MedicationTime { Label = "Label1", Time = new System.TimeOnly(12, 0) },
            new MedicationTime { Label = "Label2", Time = new System.TimeOnly(14, 0) },
            new MedicationTime { Label = "Label3", Time = new System.TimeOnly(16, 0) },
            ];
    }
}
