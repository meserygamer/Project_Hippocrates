using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;

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
    }
}
