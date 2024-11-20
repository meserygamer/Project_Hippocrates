using System;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using Project_Hippocrates_AvaloniaUI.ViewModels;

namespace Project_Hippocrates_AvaloniaUI.Desktop;

public class DesktopViewShower : IViewShower
{
    private IServiceProvider _serviceProvider;
    private IClassicDesktopStyleApplicationLifetime _applicationLifetime;
    private ViewLocator _viewLocator;
    private IWindowViewModel _windowViewModel;
    
    public DesktopViewShower(IServiceProvider serviceProvider,
        IClassicDesktopStyleApplicationLifetime applicationLifetime,
        ViewLocator viewLocator)
    {
        _serviceProvider = serviceProvider;
        _applicationLifetime = applicationLifetime;
        _viewLocator = viewLocator;
        _windowViewModel = (IWindowViewModel?)_applicationLifetime.MainWindow?.DataContext 
                           ?? throw new NullReferenceException("MainView or DataContext is null");
    }
    
    public async Task ChangeShowingViewAsync(Type viewModelType, Bundle? data)
    {
        ViewModelBase vm = (ViewModelBase?)_serviceProvider.GetService(viewModelType)
                           ?? throw new ArgumentOutOfRangeException(nameof(viewModelType), "not compatible viewModel type");
        await vm.InitializeForShowAsync(data);
        _windowViewModel.ShowingView = _viewLocator.BuildViewWithDataContext(vm);
    }
}