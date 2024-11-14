using System;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace Project_Hippocrates_AvaloniaUI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private Control? _showingView;
    private ServiceProvider _serviceProvider;

    public MainWindowViewModel()
    {
        _serviceProvider = App.Services;
        CreateMedicationTimeViewModel? vm = _serviceProvider.GetService<CreateMedicationTimeViewModel>();
        if (vm is null)
            throw new ArgumentNullException();
        ShowingView = new ViewLocator().Build(vm.ViewModelName);
        ShowingView!.DataContext = vm;
    }
}