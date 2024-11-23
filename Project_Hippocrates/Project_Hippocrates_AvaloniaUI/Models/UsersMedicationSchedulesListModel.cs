using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MapsterMapper;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;
using Project_Hippocrates_AvaloniaUI.ViewModels;
using Project_Hippocrates.Application.Services;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates_AvaloniaUI.Models;

public class UsersMedicationSchedulesListModel : ModelBase<UsersMedicationSchedulesListViewModel>
{
    private MedicationScheduleService _medicationScheduleService;
    private IMapper _mapper;
    
    public UsersMedicationSchedulesListModel(MedicationScheduleService medicationScheduleService,
        IMapper mapper)
    {
        _medicationScheduleService = medicationScheduleService;
        _mapper = mapper;
    }

    public async Task<ObservableCollection<MedicationScheduleDTO>> GetAllMedicationScheduleAsync()
    {
        IEnumerable<MedicationSchedule> medicationSchedules = await _medicationScheduleService.GetAllMedicationSchedules();
        IEnumerable<MedicationScheduleDTO> medicationSchedulesDtos =
            _mapper.Map<IEnumerable<MedicationScheduleDTO>>(medicationSchedules);
        return new ObservableCollection<MedicationScheduleDTO>(medicationSchedulesDtos);
    }

    public async Task<bool> TryRemoveMedicationTimeFromScheduleAsync(MedicationScheduleDTO medicationScheduleDto,
        MedicationTimeDTO medicationTimeDto)
    {
        return await _medicationScheduleService.TryRemoveMedicationTimeFromScheduleAsync(medicationScheduleDto.Id,
            medicationTimeDto.Id);
    }

    public async Task<IEnumerable<MedicationTimeDTO>> GetSchedulesMedicationTimesAsync(
        Guid medicationScheduleDtoId)
    {
        IEnumerable<MedicationTime> medicationTimes =
            await _medicationScheduleService.GetMedicationTimesByScheduleAsync(medicationScheduleDtoId);
        return medicationTimes.Select(mt => _mapper.Map<MedicationTimeDTO>(mt));
    }

}