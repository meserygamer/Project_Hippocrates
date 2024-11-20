using System;
using System.Threading.Tasks;

namespace Project_Hippocrates_AvaloniaUI;

public interface IViewShower
{
    Task ChangeShowingViewAsync(Type viewModelType, Bundle? data);
}