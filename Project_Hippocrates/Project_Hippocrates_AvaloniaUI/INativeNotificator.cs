using System.Threading.Tasks;

namespace Project_Hippocrates_AvaloniaUI;

public interface INativeNotificator
{
    Task SendMessageAsync(string message);
}