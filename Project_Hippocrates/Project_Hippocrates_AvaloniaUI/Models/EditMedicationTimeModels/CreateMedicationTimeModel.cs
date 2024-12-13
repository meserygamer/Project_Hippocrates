using System;
using System.Threading.Tasks;
using MapsterMapper;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;
using Project_Hippocrates_AvaloniaUI.Services.LocalPushNotificator;
using Project_Hippocrates_AvaloniaUI.ViewModels;
using Project_Hippocrates.Application.Services;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;

public class CreateMedicationTimeModel : ModelBase<CreateMedicationTimeViewModel>
{
    private IMapper _mapper;
    private MedicationTimeService _medicationTimeService;
    private readonly LocalPushNotificator _localPushNotificator;
    
    public CreateMedicationTimeModel(IMapper mapper,
        MedicationTimeService medicationTimeService, 
        LocalPushNotificator localPushNotificator) 
        : base()
    {
        _mapper = mapper;
        _medicationTimeService = medicationTimeService;
        _localPushNotificator = localPushNotificator;
    }

    public async Task<bool> TryCreateMedicationTimeForSchedule(Guid scheduleId,
        MedicationTimeDTO dto)
    {
        MedicationTime medicationTime = _mapper.Map<MedicationTime>(dto);
        return await _medicationTimeService.CreateMedicationTimeAndJoinToScheduleAsync(scheduleId, medicationTime);
    }
    
    private async Task SetPushForMedicationTime(MedicationTimeDTO dto)
    {
        int notificationId = await _localPushNotificator.AddPushNotificationInScheduleAsync(
            new PushSettings("Пора пить таблетки!",
                dto.MedicationTakenList,
                DateTime.Today + dto.Time,
                null)
        );
        dto.NotificationId = notificationId;
        await _medicationTimeService.ChangeEntityByIdAsync(dto.Id, _mapper.Map<MedicationTime>(dto));
    }
}