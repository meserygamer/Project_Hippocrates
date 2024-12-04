using Avalonia;
using System;
using Microsoft.Extensions.DependencyInjection;
using Project_Hippocrates_AvaloniaUI.Extensions;
using Project_Hippocrates.SQLite;

namespace Project_Hippocrates_AvaloniaUI.Desktop
{
    internal sealed class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>(() => new App(InitializeDesktopServiceCollection(new ServiceCollection())))
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();

        public static IServiceCollection InitializeDesktopServiceCollection(IServiceCollection serviceCollection)
        {
            return serviceCollection.AddViews()
                                    .AddViewModels()
                                    .AddModels()
                                    .AddApplicationLayerServices()
                                    .AddSqLite()
                                    .AddViewLocator()
                                    .AddMapper()
                                    .AddSingleton<IViewShower, DesktopViewShower>()
                                    .AddSingleton<INativeNotificator, DesktopNotificator>()
                                    .AddTransient<ISqLiteDbConnectionStringProvider, DesktopSqLiteDbConnectionStringProvider>(provider => new DesktopSqLiteDbConnectionStringProvider("appDb.db"));
        }
    }
}
