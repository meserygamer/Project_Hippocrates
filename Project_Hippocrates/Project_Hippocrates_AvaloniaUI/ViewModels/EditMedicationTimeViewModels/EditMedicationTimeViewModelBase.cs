using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;

namespace Project_Hippocrates_AvaloniaUI.ViewModels.EditMedicationTimeViewModels;

public abstract class EditMedicationTimeViewModelBase : ViewModelBase
{
    #region Fields
    
    private DrugDosagePresenter? _selectedDrugDosage;

    #endregion

    protected EditMedicationTimeViewModelBase(MedicationTimePresenter medicationTimePresenter)
    {
        MedicationTimePresenter = medicationTimePresenter;
    }
    
    #region Properties
    
    public virtual string ViewLabel => "Заголовок";
    public virtual MedicationTimePresenter MedicationTimePresenter { get; }
    public virtual string? MedicationTimeLabel
    {
        get => MedicationTimePresenter.Label;
        set => SetProperty(MedicationTimePresenter.Label, value, MedicationTimePresenter, (d, v) => d.Label = v ?? string.Empty);
    }
    public virtual TimeSpan? MedicationTimeAppointmentTime
    {
        get => MedicationTimePresenter.Time;
        set => SetProperty(MedicationTimePresenter.Time, value, MedicationTimePresenter, (d, v) => 
        {
            if(v is null)
                return;
            d.Time = (TimeSpan)v;
        });
    }
    public virtual ObservableCollection<DrugDosagePresenter> MedicationTimeDrugDosages
    {
        get => MedicationTimePresenter.MedicationsTaken;
        set => SetProperty(MedicationTimePresenter.MedicationsTaken, value, MedicationTimePresenter,
            (d, v) => d.MedicationsTaken = v);
    }
    public virtual DrugDosagePresenter? SelectedDrugDosage
    {
        get => _selectedDrugDosage;
        set => SetProperty(ref _selectedDrugDosage, value);
    }

    #endregion

    #region Methods

    public virtual void OnRemoveSelectedDrugDosage()
        => MedicationTimeDrugDosages.Remove(SelectedDrugDosage!);
    
    public virtual void OnAddEmptyDrugDosage()
        => MedicationTimeDrugDosages.Add(new DrugDosagePresenter());

    public abstract Task OnSubmitAsync();

    #endregion
}