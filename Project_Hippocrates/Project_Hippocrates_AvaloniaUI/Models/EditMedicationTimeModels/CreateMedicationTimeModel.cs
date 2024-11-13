using System.Threading.Tasks;
using MapsterMapper;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;
using Project_Hippocrates_AvaloniaUI.ViewModels.EditMedicationTimeViewModels;
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
    public CreateMedicationTimeModel(CreateMedicationTimeViewModel vm,
        IMapper mapper,
        MedicationTimeService medicationTimeService) 
        : base(vm)
    {
        _mapper = mapper;
        _medicationTimeService = medicationTimeService;
    }

    public async Task<bool> TryCreateMedicationTimeModel(MedicationTimePresenter presenter)
    {
        MedicationTime medicationTime = _mapper.Map<MedicationTime>(presenter);
        return await _medicationTimeService.CreateMedicationTimeAsync(medicationTime);
    }
}