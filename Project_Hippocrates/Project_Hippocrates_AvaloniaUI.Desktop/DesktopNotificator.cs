using System.Threading.Tasks;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using Project_Hippocrates_AvaloniaUI.Services;

namespace Project_Hippocrates_AvaloniaUI.Desktop;

public class DesktopNotificator : INativeNotificator
{
    public async Task SendMessageAsync(string message)
    {
        var box = MessageBoxManager
            .GetMessageBoxStandard("Внимание!", message, ButtonEnum.Ok);
        await box.ShowAsync();
    }
}