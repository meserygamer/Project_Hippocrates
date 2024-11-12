using System;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;

namespace Project_Hippocrates_AvaloniaUI.ViewModels.EditMedicationTimeViewModels;

public class EditExistingMedicationTimeViewModel : EditMedicationTimeViewModelBase
{
    private EditExistingMedicationTimeModel _model;
    
    public EditExistingMedicationTimeViewModel(MedicationTimePresenter medicationTimePresenter,
        EditExistingMedicationTimeModel model) 
        : base(medicationTimePresenter)
    {
        _model = model;
        _model.ViewModel = this;
    }

    public override string ViewLabel => "Редактирование";

    public override async Task OnSubmitAsync()
    {
        if (!await _model.TrySaveMedicationTimeChanges(base.MedicationTimePresenter))
        {
            //TODO Create false branch
        }
        //TODO Create true branch
        throw new NotImplementedException();
    }
}