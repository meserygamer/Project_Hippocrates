using System;
using Avalonia.Controls;

namespace Project_Hippocrates_AvaloniaUI.ViewModels;

public class MainWindowViewModel : ViewModelBase, IWindowViewModel
{
    private IServiceProvider _serviceProvider;
    private ViewLocator _viewLocator;
    
    private Control? _showingView;

    public MainWindowViewModel(IServiceProvider serviceProvider,
        ViewLocator viewLocator)
    {
        _serviceProvider = serviceProvider;
        _viewLocator = viewLocator;
    }

    public Control? ShowingView
    {
        get => _showingView;
        set => SetProperty(ref _showingView, value, nameof(ShowingView));
    }
}