using System;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;

namespace Project_Hippocrates_AvaloniaUI.ViewModels.EditMedicationTimeViewModels;

public class CreateMedicationTimeViewModel : EditMedicationTimeViewModelBase
{
    private CreateMedicationTimeModel _model;
    
    public CreateMedicationTimeViewModel(MedicationTimePresenter medicationTimePresenter,
        CreateMedicationTimeModel model) 
        : base(medicationTimePresenter) 
    {
        _model = model;
        _model.ViewModel = this;
    }

    public override string ViewLabel => "Создание";

    public override async Task OnSubmitAsync()
    {
        if (!await _model.TryCreateMedicationTimeModel(base.MedicationTimePresenter))
        {
            //TODO Create false branch
        }
        //TODO Create true branch
        throw new NotImplementedException();
    }
}