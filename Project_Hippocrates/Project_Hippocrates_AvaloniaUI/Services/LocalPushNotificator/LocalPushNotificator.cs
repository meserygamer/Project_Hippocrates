using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using Project_Hippocrates.Application.Services;

namespace Project_Hippocrates_AvaloniaUI.Services.LocalPushNotificator;

public class LocalPushNotificator
{
    #region Fields

    private readonly MedicationTimeService _medicationTimeService;
    
    private HashSet<int>? _busyNotificationIds = null;

    #endregion
    
    public LocalPushNotificator(MedicationTimeService medicationTimeService)
    {
        _medicationTimeService = medicationTimeService;
    }

    #region Methods

    public async ValueTask<int> AddPushNotificationInScheduleAsync(PushSettings settings)
    {
        await UpdateIfNullBusyNotificationIdsAsync();
        NotificationRequest request = settings.ResponseTime is null? 
            GenerateNoRepeatNotification(settings) 
            : GenerateDailyRepeatNotification(settings);
        _busyNotificationIds!.Add(request.NotificationId);
        _ = request.Show();
        return request.NotificationId;
    }

    public bool CancelNotificationById(int notificationId) 
        => LocalNotificationCenter.Current.Cancel(notificationId);

    private async Task UpdateIfNullBusyNotificationIdsAsync()
        => _busyNotificationIds ??= new HashSet<int>(await _medicationTimeService.GetAllBusyNotificationIdAsync() ?? []);

    private NotificationRequest GenerateDailyRepeatNotification(PushSettings settings)
    {
        return new NotificationRequest()
        {
            BadgeNumber = 1,
            CategoryType = NotificationCategoryType.Alarm,
            Description = settings.Description,
            Title = settings.Title,
            NotificationId = GenerateNotificationId(),
            Schedule = new NotificationRequestSchedule()
            {
                NotifyAutoCancelTime = null,
                RepeatType = NotificationRepeat.Daily,
                NotifyTime = settings.ResponseTime
            }
        };
    }
    private NotificationRequest GenerateNoRepeatNotification(PushSettings settings)
    {
        return new NotificationRequest()
        {
            BadgeNumber = 1,
            CategoryType = NotificationCategoryType.Alarm,
            Description = settings.Description,
            Title = settings.Title,
            NotificationId = GenerateNotificationId(),
            Schedule = new NotificationRequestSchedule()
            {
                NotifyTime = DateTime.Now + settings.TimeToActuation,
                RepeatType = NotificationRepeat.No
            }
        };
    }
    
    private int GenerateNotificationId()
    {
        if (_busyNotificationIds is null)
            throw new NullReferenceException($"{nameof(_busyNotificationIds)} is null");
        
        for (int i = 1; i < int.MaxValue; i++)
        {
            if(_busyNotificationIds.Contains(i))
                continue;
            return i;
        }
        throw new ApplicationException("Available notification id's have run out!");
    }

    #endregion
    
}