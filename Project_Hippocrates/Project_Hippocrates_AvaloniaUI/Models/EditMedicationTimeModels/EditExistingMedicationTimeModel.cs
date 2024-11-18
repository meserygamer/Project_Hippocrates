using System;
using System.Threading.Tasks;
using MapsterMapper;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;
using Project_Hippocrates_AvaloniaUI.ViewModels;
using Project_Hippocrates.Application.Services;
using Project_Hippocrates.Core.Entities;

namespace Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;

public class EditExistingMedicationTimeModel : ModelBase<EditExistingMedicationTimeViewModel>
{
    private IMapper _mapper;
    private MedicationTimeService _medicationTimeService;
    
    public EditExistingMedicationTimeModel(IMapper mapper,
        MedicationTimeService medicationTimeService) 
        : base()
    {
        _mapper = mapper;
        _medicationTimeService = medicationTimeService;
    }

    public async Task<bool> TrySaveMedicationTimeChangesAsync(MedicationTimeDTO dto)
    {
        MedicationTime medicationTime = _mapper.Map<MedicationTime>(dto);
        return await _medicationTimeService.ChangeEntityByIdAsync(medicationTime.Id, medicationTime);
    }

    public async Task<MedicationTimeDTO> FindMedicationTimeByIdAsync(Guid id)
    {
        MedicationTime findingResult = await _medicationTimeService.FindMedicationTimeByIdAsync(id) 
                                       ?? throw new NullReferenceException($"Medication with id - {id} not find!");
        return _mapper.Map<MedicationTimeDTO>(findingResult);
    }
}