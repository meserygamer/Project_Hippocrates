using System.Threading.Tasks;
using Android.Content;
using Android.Widget;
using Project_Hippocrates_AvaloniaUI.Services;

namespace Project_Hippocrates_AvaloniaUI.Android;

public class AndroidNotificator : INativeNotificator
{
    private Context _context;
    
    public AndroidNotificator(Context context)
    {
        _context = context;
    }
    
    public async Task SendMessageAsync(string message) 
        => Toast.MakeText(_context, message, ToastLength.Long)!.Show();
}