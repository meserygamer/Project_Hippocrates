using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;

namespace Project_Hippocrates_AvaloniaUI.Controls;

public class ContentControlWithSideMenu : ContentControl
{
    public static readonly StyledProperty<SideMenuFragment?> MenuContentProperty =
        AvaloniaProperty.Register<ContentControlWithSideMenu, SideMenuFragment?>(nameof(MenuContent));

    public static readonly StyledProperty<bool> IsMenuOpenProperty =
        AvaloniaProperty.Register<ContentControlWithSideMenu, bool>(nameof(IsMenuOpen), defaultValue: false);

    private IDisposable? _closeMenuButtonPressedDispose;

    static ContentControlWithSideMenu() { }

    public SideMenuFragment? MenuContent
    {
        get => GetValue(MenuContentProperty);
        set => SetValue(MenuContentProperty, value);
    }

    public bool IsMenuOpen
    {
        get => GetValue(IsMenuOpenProperty);
        set => SetValue(IsMenuOpenProperty, value);
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
        
        _closeMenuButtonPressedDispose?.Dispose();
        _closeMenuButtonPressedDispose = (e.NewValue as SideMenuFragment)?
            .AddDisposableHandler(SideMenuFragment.CloseMenuButtonPressedEvent, OnCloseMenuButtonPressed);
    }

    private void OnCloseMenuButtonPressed(object? sender, RoutedEventArgs e)
        => IsMenuOpen = false;
}
