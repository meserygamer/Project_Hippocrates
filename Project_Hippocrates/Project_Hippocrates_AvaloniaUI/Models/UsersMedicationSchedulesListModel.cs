using System.Collections.Generic;
using System.Collections.ObjectModel;
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
}