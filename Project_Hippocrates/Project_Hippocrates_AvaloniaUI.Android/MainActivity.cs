using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;
using Microsoft.Extensions.DependencyInjection;
using Project_Hippocrates_AvaloniaUI.Extensions;

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
        private IServiceCollection _serviceCollection;
        
        public MainActivity()
        {
            _serviceCollection = new ServiceCollection();
            InitializeAndroidServiceCollection();
        }
        
        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        {
            return base.CustomizeAppBuilder(builder)
                .WithInterFont();
        }

        protected override AppBuilder CreateAppBuilder()
        {
            return AppBuilder.Configure<App>(() => new App(_serviceCollection));
        }

        private void InitializeAndroidServiceCollection()
        {
            _serviceCollection.AddViews()
                              .AddViewModels()
                              .AddModels()
                              .AddApplicationLayerServices()
                              .AddDataRepositories()
                              .AddMapper()
                              .AddSingleton<INativeNotificator, AndroidNotificator>();
        }
    }
}
