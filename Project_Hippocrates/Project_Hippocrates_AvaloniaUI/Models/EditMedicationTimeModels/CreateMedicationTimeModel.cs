using System;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;
using Project_Hippocrates_AvaloniaUI.ViewModels.EditMedicationTimeViewModels;

namespace Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;

public class CreateMedicationTimeModel : ModelBase<CreateMedicationTimeViewModel>
{
    public CreateMedicationTimeModel() : base() { }
    public CreateMedicationTimeModel(CreateMedicationTimeViewModel vm) : base(vm) { }

    public async Task<bool> TryCreateMedicationTimeModel(MedicationTimePresenter medicationTimePresenter)
    {
        //TODO Create Method
        throw new NotImplementedException();
    }
}