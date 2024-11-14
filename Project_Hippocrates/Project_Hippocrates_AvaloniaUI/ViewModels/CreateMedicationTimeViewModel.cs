using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;

namespace Project_Hippocrates_AvaloniaUI.ViewModels;

public class CreateMedicationTimeViewModel : EditMedicationTimeViewModelBase
{
    private CreateMedicationTimeModel _model;
    private IServiceProvider _serviceProvider;
    private INativeNotificator _nativeNotificator;
    
    public CreateMedicationTimeViewModel(CreateMedicationTimeModel model) 
        : base(new ()) 
    {
        _model = model;
        _model.ViewModel = this;
        _serviceProvider = App.Current!.Services;
        _nativeNotificator = _serviceProvider.GetService<INativeNotificator>()!;
    }

    public override string ViewLabel => "Создание";

    public override async Task OnSubmitAsync()
    {
        try
        {
            if (!await _model.TryCreateMedicationTimeModel(base.MedicationTimePresenter))
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
}