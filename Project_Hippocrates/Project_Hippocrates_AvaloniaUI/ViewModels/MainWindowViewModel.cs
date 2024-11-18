using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Threading;
using Project_Hippocrates.Core;
using Project_Hippocrates.Core.Entities;

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
        var medicationTimeRepo = (IDomainEntityRepository<MedicationTime>)_serviceProvider.GetService(typeof(IDomainEntityRepository<MedicationTime>))!;
        var medicationTime = medicationTimeRepo.GetAll().First();
        SetShowingView(typeof(EditExistingMedicationTimeViewModel), new Bundle(new Dictionary<string, object?> { { "ChangingMedicationTimeId", medicationTime.Id } }));
    }

    public Control? ShowingView
    {
        get => _showingView;
        private set => SetProperty(ref _showingView, value, nameof(ShowingView));
    }

    public void SetShowingView(Type viewModelType, Bundle? bundle)
    {
        Task.Run(async () =>
        {
            ViewModelBase vm = (ViewModelBase?)_serviceProvider.GetService(viewModelType)
                               ?? throw new ArgumentOutOfRangeException(nameof(viewModelType),
                                   "not compatible viewModel type");
            await vm.InitializeForShowAsync(bundle);
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                ShowingView = _viewLocator.BuildViewWithDataContext((ViewModelBase)vm);
            });
        });
    }
    
    public async Task SetShowingViewAsync(Type viewModelType, Bundle? bundle)
    {
        ViewModelBase vm = (ViewModelBase?)_serviceProvider.GetService(viewModelType)
                           ?? throw new ArgumentOutOfRangeException(nameof(viewModelType), "not compatible viewModel type");
        await vm.InitializeForShowAsync(bundle);
        ShowingView = _viewLocator.BuildViewWithDataContext((ViewModelBase)vm);
    }
}