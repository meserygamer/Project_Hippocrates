using System;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;
using Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;
using Project_Hippocrates_AvaloniaUI.Services;
using Project_Hippocrates_AvaloniaUI.Services.LocalPushNotificator;

namespace Project_Hippocrates_AvaloniaUI.ViewModels;

public class CreateMedicationTimeViewModel : EditMedicationTimeViewModelBase
{
    #region Fields

    private readonly CreateMedicationTimeModel _model;
    private readonly INativeNotificator _nativeNotificator;
    private readonly LocalPushNotificator _localPushNotificator;

    private Guid _currentMedicationScheduleId;

    #endregion

    #region Constructors

    public CreateMedicationTimeViewModel(CreateMedicationTimeModel model,
        INativeNotificator nativeNotificator,
        IViewShower viewShower,
        LocalPushNotificator localPushNotificator) 
        : base(new (), viewShower) 
    {
        _model = model;
        _model.ViewModel = this;
        _nativeNotificator = nativeNotificator;
        _localPushNotificator = localPushNotificator;
    }

    /// <summary>
    /// Only for design mode
    /// </summary>
    public CreateMedicationTimeViewModel(LocalPushNotificator localPushNotificator) : base(new (), null!)
    {
        _localPushNotificator = localPushNotificator;
    }

    #endregion

    #region Implementation ViewModelBase

    public override Task InitializeForShowAsync(Bundle? bundle)
    {
        if (bundle is null)
            throw new ArgumentNullException(nameof(bundle), $"{nameof(CreateMedicationTimeViewModel)} requires external data to initialize!");
        _currentMedicationScheduleId = bundle.GetData<Guid>("CurrentMedicationSchedule");
        return Task.CompletedTask;
    }

    public override string ViewLabel => "Создание";

    #endregion

    #region Implementation EditMedicationTimeViewModelBase

    public override async Task OnSubmitAsync()
    {
        try
        {
            if (!await _model.TryCreateMedicationTimeForSchedule(_currentMedicationScheduleId,
                    base.DisplayedMedicationTime))
            {
                await _nativeNotificator.SendMessageAsync("Время приёма лекарств успешно создано!");
            }
            await _nativeNotificator.SendMessageAsync("Создание не удалось!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await _nativeNotificator.SendMessageAsync("Что-то пошло не так!");
        }
    }

    #endregion
}