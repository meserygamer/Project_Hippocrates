using System;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;

namespace Project_Hippocrates_AvaloniaUI.ViewModels;

public class EditExistingMedicationTimeViewModel : EditMedicationTimeViewModelBase
{
    #region Fields

    private readonly EditExistingMedicationTimeModel _model;
    private readonly INativeNotificator _nativeNotificator;

    #endregion
    
    public EditExistingMedicationTimeViewModel(EditExistingMedicationTimeModel model,
        INativeNotificator nativeNotificator) 
        : base()
    {
        _model = model;
        _model.ViewModel = this;
        _nativeNotificator = nativeNotificator;
    }

    #region Implementation ViewModelBase

    public override async Task InitializeForShowAsync(Bundle? bundle)
    {
        try
        {
            Guid changingMedicationTimeId = bundle!.GetData<Guid>("ChangingMedicationTimeId");
            base.DisplayedMedicationTime = await _model.FindMedicationTimeByIdAsync(changingMedicationTimeId);
        }
        catch (Exception e)
        {
            throw new ArgumentException("Bundle - null или не обладает ключом ChangingMedicationTimeId с типом GUID");
        }
    }
    public override string ViewLabel => "Редактирование";

    #endregion

    #region Implementation EditMedicationTimeViewModelBase

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

    #endregion
}