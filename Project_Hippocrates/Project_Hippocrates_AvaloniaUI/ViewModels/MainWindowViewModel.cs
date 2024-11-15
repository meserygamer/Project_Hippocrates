using System;
using Avalonia.Controls;

namespace Project_Hippocrates_AvaloniaUI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private IServiceProvider _serviceProvider;
    private ViewLocator _viewLocator;
    
    private Control? _showingView;

    public MainWindowViewModel(IServiceProvider serviceProvider,
        ViewLocator viewLocator)
    {
        _serviceProvider = serviceProvider;
        _viewLocator = viewLocator;
        SetShowingView(typeof(CreateMedicationTimeViewModel));
    }

    public Control? ShowingView
    {
        get => _showingView;
        private set => SetProperty(ref _showingView, value, nameof(ShowingView));
    }

    public void SetShowingView(Type viewModelType)
    {
        var vm = _serviceProvider.GetService(viewModelType) 
                                 ?? throw new ArgumentOutOfRangeException(nameof(viewModelType), "not compatible viewModel type");
        ShowingView = _viewLocator.BuildViewWithDataContext((ViewModelBase)vm);
    }
}