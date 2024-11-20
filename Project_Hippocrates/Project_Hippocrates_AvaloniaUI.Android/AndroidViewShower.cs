using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Project_Hippocrates_AvaloniaUI.ViewModels;

namespace Project_Hippocrates_AvaloniaUI.Android;

public class AndroidViewShower : IViewShower
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ISingleViewApplicationLifetime? _applicationLifetime;
    private readonly ViewLocator _viewLocator;

    private readonly Stack<(Type, Bundle?)> _viewModelTypeHistory = new ();
    
    public AndroidViewShower(IServiceProvider serviceProvider,
        Application application,
        ViewLocator viewLocator)
    {
        _serviceProvider = serviceProvider;
        _applicationLifetime = application.ApplicationLifetime as ISingleViewApplicationLifetime;
        _viewLocator = viewLocator;
    }

    public async Task ShowViewAsync(Type viewModelType, Bundle? data)
    {
        if (_applicationLifetime is null)
            throw new NullReferenceException("ApplicationLifetime is null");
            
        ViewModelBase vm = (ViewModelBase?)_serviceProvider.GetService(viewModelType)
                           ?? throw new ArgumentOutOfRangeException(nameof(viewModelType), "not compatible viewModel type");
        await vm.InitializeForShowAsync(data);
        Control view =  _viewLocator.BuildViewWithDataContext(vm);
        _viewModelTypeHistory.Push((viewModelType, data));
        _applicationLifetime!.MainView = view;
    }

    public async Task ShowPreviousViewAsync()
    {
        if(_viewModelTypeHistory.Count <= 1) //No previous views in history
            return;

        _ = _viewModelTypeHistory.Pop();
        (Type, Bundle?) previousView = _viewModelTypeHistory.Peek();
        await ShowViewAsync(previousView.Item1, previousView.Item2);
    }
}