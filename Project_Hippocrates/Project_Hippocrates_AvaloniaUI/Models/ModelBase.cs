using Project_Hippocrates_AvaloniaUI.ViewModels;

namespace Project_Hippocrates_AvaloniaUI.Models;

public abstract class ModelBase<TViewModel> 
    where TViewModel : ViewModelBase
{
    
    protected ModelBase() { }
    protected ModelBase(TViewModel viewModel) { ViewModel = viewModel; }
    
    public TViewModel? ViewModel { get; set; }
}