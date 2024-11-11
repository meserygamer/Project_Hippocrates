using System;
using System.Collections.ObjectModel;
using Project_Hippocrates_AvaloniaUI.Models;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;

namespace Project_Hippocrates_AvaloniaUI.ViewModels.EditMedicationTimeViewModels;

public abstract class EditMedicationTimeViewModelBase : ViewModelBase
{
    #region Properties

    public virtual string ViewLabel { get; protected set; } = "Заголовок";
    public abstract string? MedicationTimeLabel { get; set; }
    public abstract TimeSpan? MedicationTimeAppointmentTime { get; set; }
    public abstract ObservableCollection<DrugDosagePresenter> MedicationTimeDrugDosages { get; set; }
    public abstract DrugDosagePresenter? SelectedDrugDosage { get; set; }

    #endregion

    #region Methods

    public virtual void RemoveSelectedDrugDosage()
        => MedicationTimeDrugDosages.Remove(SelectedDrugDosage!);
    
    public virtual void AddEmptyDrugDosage()
        => MedicationTimeDrugDosages.Add(new DrugDosagePresenter());

    #endregion
}