using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Plugin.LocalNotification;
using Project_Hippocrates_AvaloniaUI.Services;
using Project_Hippocrates_AvaloniaUI.Services.LocalPushNotificator;
using Project_Hippocrates_AvaloniaUI.ViewModels;
using Project_Hippocrates_AvaloniaUI.Views;
using Project_Hippocrates.SQLite;

namespace Project_Hippocrates_AvaloniaUI
{
    public partial class App : Application
    {
        private IServiceCollection _serviceCollection = new ServiceCollection();

        public App() { }
        public App(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<Application>(this);
            _serviceCollection = serviceCollection;
        }
        
        public ServiceProvider Services => _serviceCollection.BuildServiceProvider();

        public new static App? Current => (App?)Application.Current;

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
                    DataContext = Services.GetService<MainWindowViewModel>()
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new UsersMedicationSchedulesListView()
                {
                    DataContext = Services.GetService<UsersMedicationSchedulesListViewModel>()
                };
            }
            var viewShower = Services.GetService<IViewShower>();
            viewShower?.ShowViewAsync(typeof(UsersMedicationSchedulesListViewModel), new Bundle());
            _ = Services.GetService<LocalPushNotificator>()!
                .ShowPushNotificationByTimeSpan("description", "title", TimeSpan.FromSeconds(8));
            base.OnFrameworkInitializationCompleted();
        }
    }
}