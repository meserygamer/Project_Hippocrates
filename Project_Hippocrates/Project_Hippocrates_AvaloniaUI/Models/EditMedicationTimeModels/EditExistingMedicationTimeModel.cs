using System.Threading.Tasks;
using MapsterMapper;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;
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

    public async Task<bool> TrySaveMedicationTimeChanges(MedicationTimePresenter presenter)
    {
        MedicationTime medicationTime = _mapper.Map<MedicationTime>(presenter);
        return await _medicationTimeService.SaveMedicationTimeChangesAsync(medicationTime);
    }
}