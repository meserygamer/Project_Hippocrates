using System;
using System.Threading.Tasks;
using MapsterMapper;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;
using Project_Hippocrates_AvaloniaUI.ViewModels;
using Project_Hippocrates.Application.Services;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;

public class CreateMedicationTimeModel : ModelBase<CreateMedicationTimeViewModel>
{
    private IMapper _mapper;
    private MedicationTimeService _medicationTimeService;
    
    public CreateMedicationTimeModel(IMapper mapper,
        MedicationTimeService medicationTimeService) 
        : base()
    {
        _mapper = mapper;
        _medicationTimeService = medicationTimeService;
    }

    public async Task<bool> TryCreateMedicationTimeForSchedule(Guid scheduleId,
        MedicationTimeDTO dto)
    {
        MedicationTime medicationTime = _mapper.Map<MedicationTime>(dto);
        return await _medicationTimeService.CreateMedicationTimeAndJoinToScheduleAsync(scheduleId, medicationTime);
    }
}