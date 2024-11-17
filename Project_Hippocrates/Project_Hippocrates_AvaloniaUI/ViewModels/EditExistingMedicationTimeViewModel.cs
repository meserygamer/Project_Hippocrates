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
            if (!await _model.TrySaveMedicationTimeChangesAsync(base.DisplayedMedicationTime))
            {
                await _nativeNotificator.SendMessageAsync("Информация успешно изменена!");
            }
            await _nativeNotificator.SendMessageAsync("Изменить информацию неудалось!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await _nativeNotificator.SendMessageAsync("Что-то пошло не так!");
        }
    }

    public void SetChangingMedicationTime(MedicationTimePresenter value)
        => base.DisplayedMedicationTime = value;

    public async Task SetChangingMedicationTimeByIdAsync(Guid id)
        => base.DisplayedMedicationTime = await _model.FindMedicationTimeByIdAsync(id);
}