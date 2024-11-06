using Avalonia;
using Avalonia.Controls;
using Avalonia.LogicalTree;

namespace Project_Hippocrates_AvaloniaUI.Controls;

public class SideMenu : ContentControl
{
    public static readonly StyledProperty<object?> MenuContentProperty =
        AvaloniaProperty.Register<SideMenu, object?>(nameof(MenuContent));

    public SideMenu() : base(){}

    public object? MenuContent
    {
        get => GetValue(MenuContentProperty);
        set => SetValue(MenuContentProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if(change.Property == MenuContentProperty)
            MenuContentChanged(change);
    }

    private void MenuContentChanged(AvaloniaPropertyChangedEventArgs e)
    {
        if(e.OldValue is ILogical oldChild)
            LogicalChildren.Remove(oldChild);

        if(e.NewValue is ILogical newChild)
            LogicalChildren.Add(newChild);
    }
}
