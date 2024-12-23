using System;

namespace Project_Hippocrates_AvaloniaUI.Services.LocalPushNotificator;

public record PushSettings(
    string Title,
    string Description,
    DateTime? ResponseTime,
    TimeSpan? TimeToActuation);