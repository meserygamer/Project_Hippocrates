using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Project_Hippocrates_AvaloniaUI.ViewModels;
using Project_Hippocrates_AvaloniaUI.Views;

namespace Project_Hippocrates_AvaloniaUI
{
    public partial class App : Application
    {
        private static IServiceCollection _serviceCollection = new ServiceCollection();

        public App() { }
        public App(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }
        
        public static ServiceProvider Services => _serviceCollection.BuildServiceProvider();

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel()
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = new MainViewModel()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}