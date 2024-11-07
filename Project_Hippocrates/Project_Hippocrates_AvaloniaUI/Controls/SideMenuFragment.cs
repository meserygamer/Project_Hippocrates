using System;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Project_Hippocrates_AvaloniaUI.Controls;

[TemplatePart("PART_CloseMenuButton", typeof(Button), IsRequired = false)]
public class SideMenuFragment : ContentControl
{
    public static readonly RoutedEvent<RoutedEventArgs> CloseMenuButtonPressedEvent =
        RoutedEvent.Register<SideMenuFragment, RoutedEventArgs>(
            nameof(CloseMenuButtonPressed),
            RoutingStrategies.Bubble);

    private Button? _closeMenuButton;
    private IDisposable? _closeMenuButtonPressDispose;
    
    public event EventHandler<RoutedEventArgs> CloseMenuButtonPressed
    {
        add => AddHandler(CloseMenuButtonPressedEvent, value);
        remove => RemoveHandler(CloseMenuButtonPressedEvent, value);
    }
    
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        
        _closeMenuButtonPressDispose?.Dispose();

        _closeMenuButton = e.NameScope.Find<Button>("PART_CloseMenuButton");

        if (_closeMenuButton != null)
            _closeMenuButtonPressDispose = _closeMenuButton.AddDisposableHandler(PointerPressedEvent, OnCloseMenuButtonPressed, RoutingStrategies.Tunnel);
    }

    private void OnCloseMenuButtonPressed(object? sender, RoutedEventArgs e)
    {
        RaiseEvent(new RoutedEventArgs(CloseMenuButtonPressedEvent, this));
    }
}