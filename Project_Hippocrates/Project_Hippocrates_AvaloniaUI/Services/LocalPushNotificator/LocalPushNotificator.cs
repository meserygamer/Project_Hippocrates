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

    public async Task<int> AddPushNotificationInScheduleAsync(string description, string title, DateTime dateTime)
    {
        var notificationRequest = new NotificationRequest()
        {
            BadgeNumber = 1,
            CategoryType = NotificationCategoryType.Alarm,
            Description = description,
            Title = title,
            NotificationId = await GenerateNotificationIdAsync(),
            Schedule = new NotificationRequestSchedule()
            {
                NotifyAutoCancelTime = null,
                RepeatType = NotificationRepeat.Daily,
                NotifyTime = dateTime
            }
        };
        _ = notificationRequest.Show();
        _busyNotificationIds!.Add(notificationRequest.NotificationId);
        return notificationRequest.NotificationId;
    }

    public async Task<int> ShowPushNotificationByTimeSpan(string description, string title, TimeSpan time)
    {
        var notificationRequest = new NotificationRequest()
        {
            BadgeNumber = 1,
            CategoryType = NotificationCategoryType.Alarm,
            Description = description,
            Title = title,
            NotificationId = await GenerateNotificationIdAsync(),
            Schedule = new NotificationRequestSchedule()
            {
                NotifyTime = DateTime.Now + time,
                RepeatType = NotificationRepeat.No
            }
        };
        var req = notificationRequest.Show();
        _busyNotificationIds!.Add(notificationRequest.NotificationId);
        return notificationRequest.NotificationId;
    }

    public bool CancelNotificationById(int notificationId) 
        => LocalNotificationCenter.Current.Cancel(notificationId);
    
    private async Task<int> GenerateNotificationIdAsync()
    {
        _busyNotificationIds ??= new HashSet<int>(await _medicationTimeService.GetAllBusyNotificationIdAsync() ?? []);
        for (int i = 0; i < int.MaxValue; i++)
        {
            if(_busyNotificationIds.Contains(i))
                continue;
            return i;
        }
        throw new ApplicationException("Available notification id's have run out!");
    }

    #endregion
    
}