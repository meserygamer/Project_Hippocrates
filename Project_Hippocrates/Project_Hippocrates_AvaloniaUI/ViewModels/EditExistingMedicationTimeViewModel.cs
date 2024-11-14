using System;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;

namespace Project_Hippocrates_AvaloniaUI.ViewModels;

public class EditExistingMedicationTimeViewModel : EditMedicationTimeViewModelBase
{
    private EditExistingMedicationTimeModel _model;
    private INativeNotificator _nativeNotificator;
    
    public EditExistingMedicationTimeViewModel(EditExistingMedicationTimeModel model,
        INativeNotificator nativeNotificator) 
        : base()
    {
        _model = model;
        _model.ViewModel = this;
        _nativeNotificator = nativeNotificator;
    }

    public override string ViewLabel => "Редактирование";

    public override async Task OnSubmitAsync()
    {
        try
        {
            if (!await _model.TrySaveMedicationTimeChanges(base.DisplayedMedicationTime))
            {
                //TODO True branch
            }
            //TODO False branch
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        await _nativeNotificator.SendMessageAsync("Проверка связи");
    }

    public void SetChangingMedicationTime(MedicationTimePresenter value)
        => base.DisplayedMedicationTime = value;
}