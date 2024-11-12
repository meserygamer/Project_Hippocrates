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

    public override void OnSubmit()
    {
        
    }
}