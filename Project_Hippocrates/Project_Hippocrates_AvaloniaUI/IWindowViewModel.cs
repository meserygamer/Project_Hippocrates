using System;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace Project_Hippocrates_AvaloniaUI;

public interface IWindowViewModel
{
    public Control? ShowingView { get; set; }
}