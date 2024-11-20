using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Threading;
using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;

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
        //var medicationTimeRepo = (IDomainEntityRepository<MedicationTime>)_serviceProvider.GetService(typeof(IDomainEntityRepository<MedicationTime>))!;
        //var medicationTime = medicationTimeRepo.GetAll().First();
        //SetShowingViewAsync(typeof(EditExistingMedicationTimeViewModel), new Bundle(new Dictionary<string, object?> { { "ChangingMedicationTimeId", medicationTime.Id } }));
    }

    public Control? ShowingView
    {
        get => _showingView;
        set => SetProperty(ref _showingView, value, nameof(ShowingView));
    }
}