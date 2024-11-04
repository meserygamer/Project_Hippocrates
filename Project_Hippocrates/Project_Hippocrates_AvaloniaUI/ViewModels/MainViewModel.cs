using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Project_Hippocrates_AvaloniaUI.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<string> _testCollection = ["test1", "test2", "test3"];
    }
}
