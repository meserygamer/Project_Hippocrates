using System;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using Project_Hippocrates_AvaloniaUI.ViewModels;

namespace Project_Hippocrates_AvaloniaUI.Android;

public class AndroidViewShower : IViewShower
{
    private IServiceProvider _serviceProvider;
    private ISingleViewApplicationLifetime _applicationLifetime;
    private ViewLocator _viewLocator;
    
    public AndroidViewShower(IServiceProvider serviceProvider,
        ISingleViewApplicationLifetime applicationLifetime,
        ViewLocator viewLocator)
    {
        _serviceProvider = serviceProvider;
        _applicationLifetime = applicationLifetime;
        _viewLocator = viewLocator;
    }

    public async Task ChangeShowingViewAsync(Type viewModelType, Bundle? data)
    {
        ViewModelBase vm = (ViewModelBase?)_serviceProvider.GetService(viewModelType)
                           ?? throw new ArgumentOutOfRangeException(nameof(viewModelType), "not compatible viewModel type");
        await vm.InitializeForShowAsync(data);
        _applicationLifetime.MainView = _viewLocator.BuildViewWithDataContext(vm);
    }
}