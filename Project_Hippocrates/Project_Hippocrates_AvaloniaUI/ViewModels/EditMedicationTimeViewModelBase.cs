﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Project_Hippocrates_AvaloniaUI.Models.DTOs;
using Project_Hippocrates_AvaloniaUI.Services;

namespace Project_Hippocrates_AvaloniaUI.ViewModels;

public abstract class EditMedicationTimeViewModelBase : ViewModelBase
{
    #region Fields

    protected readonly IViewShower ViewShower; 
    
    private DrugDosageDTO? _selectedDrugDosage;
    private MedicationTimeDTO _displayedMedicationTime;

    #endregion

    #region Constructors

    protected EditMedicationTimeViewModelBase(MedicationTimeDTO displayedMedicationTime,
        IViewShower viewShower)
    {
        ViewShower = viewShower;
        _displayedMedicationTime = displayedMedicationTime;
    }

    #endregion
    
    #region Properties
    
    public virtual string ViewLabel => "Заголовок";

    public MedicationTimeDTO DisplayedMedicationTime
    {
        get => _displayedMedicationTime; 
        protected set => SetProperty(ref _displayedMedicationTime, value);
    }
    public virtual string? MedicationTimeLabel
    {
        get => DisplayedMedicationTime.Label;
        set => SetProperty(DisplayedMedicationTime.Label, value, DisplayedMedicationTime, (d, v) => d.Label = v ?? string.Empty);
    }
    public virtual TimeSpan? MedicationTimeAppointmentTime
    {
        get => DisplayedMedicationTime.Time;
        set => SetProperty(DisplayedMedicationTime.Time, value, DisplayedMedicationTime, (d, v) => 
        {
            if(v is null)
                return;
            d.Time = (TimeSpan)v;
        });
    }
    public virtual ObservableCollection<DrugDosageDTO> MedicationTimeDrugDosages
    {
        get => DisplayedMedicationTime.MedicationsTaken;
        set => SetProperty(DisplayedMedicationTime.MedicationsTaken, value, DisplayedMedicationTime,
            (d, v) => d.MedicationsTaken = v);
    }
    public virtual DrugDosageDTO? SelectedDrugDosage
    {
        get => _selectedDrugDosage;
        set => SetProperty(ref _selectedDrugDosage, value);
    }
    public override string? ViewModelFullName { get; } = typeof(EditMedicationTimeViewModelBase).FullName!
        .Replace("EditMedicationTimeViewModelBase", "EditMedicationTimeViewModel", StringComparison.Ordinal);

    public ObservableCollection<string> AllowableDosageUnits { get; } =
    [
        "т.",
        "мг.",
        "мл.",
        "кап."
    ];

    #endregion

    #region Methods

    public virtual void OnRemoveSelectedDrugDosage()
        => MedicationTimeDrugDosages.Remove(SelectedDrugDosage!);
    
    public virtual void OnAddEmptyDrugDosage()
        => MedicationTimeDrugDosages.Add(new DrugDosageDTO());

    public virtual async Task OnSubmitAsync() { }

    public virtual async Task OnBackButtonClick()
    {
        await ViewShower.ShowPreviousViewAsync();
    }

    #endregion
}