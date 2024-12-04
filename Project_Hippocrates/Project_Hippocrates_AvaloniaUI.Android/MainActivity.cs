using Android.App;
using Android.Content;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;
using Microsoft.Extensions.DependencyInjection;
using Project_Hippocrates_AvaloniaUI.Extensions;
using Project_Hippocrates.SQLite;

namespace Project_Hippocrates_AvaloniaUI.Android
{
    [Activity(
        Label = "Project_Hippocrates_AvaloniaUI.Android",
        Theme = "@style/MyTheme.NoActionBar",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
    public class MainActivity : AvaloniaMainActivity<App>
    {
        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        {
            return base.CustomizeAppBuilder(builder)
                .WithInterFont();
        }

        protected override AppBuilder CreateAppBuilder()
        {
            return AppBuilder.Configure<App>(() =>
                new App(InitializeAndroidServiceCollection(new ServiceCollection())
                )).UseAndroid();
        }

        private IServiceCollection InitializeAndroidServiceCollection(IServiceCollection serviceCollection)
        {
            return serviceCollection.AddViews()
                .AddViewModels()
                .AddModels()
                .AddApplicationLayerServices()
                .AddSqLite()
                .AddMapper()
                .AddViewLocator()
                .AddSingleton<Context>(this.ApplicationContext!)
                .AddSingleton<IViewShower, AndroidViewShower>()
                .AddSingleton<INativeNotificator, AndroidNotificator>()
                .AddTransient<ISqLiteDbConnectionStringProvider, AndroidSqLiteDbConnectionStringProvider>(provider =>
                    new AndroidSqLiteDbConnectionStringProvider("appDb.db"));
        }
    }
}
