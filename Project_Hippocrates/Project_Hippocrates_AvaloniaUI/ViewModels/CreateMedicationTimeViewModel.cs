using System;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;

namespace Project_Hippocrates_AvaloniaUI.ViewModels;

public class CreateMedicationTimeViewModel : EditMedicationTimeViewModelBase
{
    private CreateMedicationTimeModel _model;
    private INativeNotificator _nativeNotificator;
    
    public CreateMedicationTimeViewModel(CreateMedicationTimeModel model,
        INativeNotificator nativeNotificator) 
        : base(new ()) 
    {
        _model = model;
        _model.ViewModel = this;
        _nativeNotificator = nativeNotificator;
    }

    public override string ViewLabel => "Создание";

    public override async Task OnSubmitAsync()
    {
        try
        {
            if (!await _model.TryCreateMedicationTimeModel(base.DisplayedMedicationTime))
            {
                await _nativeNotificator.SendMessageAsync("Время приёма лекарств успешно создано");
            }
            await _nativeNotificator.SendMessageAsync("Создание не удалось");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await _nativeNotificator.SendMessageAsync("Что-то пошло не так!");
        }
    }
}