using System.Threading.Tasks;

namespace Project_Hippocrates_AvaloniaUI.Services;

public interface INativeNotificator
{
    Task SendMessageAsync(string message);
}