using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Project_Hippocrates_AvaloniaUI.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        public virtual string? ViewModelFullName => GetType().FullName;
        
        public virtual Task InitializeForShowAsync(Bundle? bundle) => Task.CompletedTask;
    }
}
