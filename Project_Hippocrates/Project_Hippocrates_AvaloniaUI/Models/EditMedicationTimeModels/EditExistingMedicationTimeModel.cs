using System;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;
using Project_Hippocrates_AvaloniaUI.ViewModels.EditMedicationTimeViewModels;

namespace Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;

public class EditExistingMedicationTimeModel : ModelBase<EditExistingMedicationTimeViewModel>
{
    public EditExistingMedicationTimeModel() : base() { }
    public EditExistingMedicationTimeModel(EditExistingMedicationTimeViewModel vm) : base(vm) { }

    public async Task<bool> TrySaveMedicationTimeChanges(MedicationTimePresenter presenter)
    {
        //TODO Create Method
        throw new NotImplementedException();
    }
}