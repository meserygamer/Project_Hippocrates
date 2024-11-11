using System;
using System.Collections.ObjectModel;
using Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;

namespace Project_Hippocrates_AvaloniaUI.ViewModels.EditMedicationTimeViewModels;

public class CreateMedicationTimeViewModel : EditMedicationTimeViewModelBase
{
    private CreateMedicationTimeModel _model;
    private DrugDosagePresenter? _selectedDrugDosage;
    private MedicationTimePresenter _drugDosagePresenter;

    public CreateMedicationTimeViewModel()
    {
        _drugDosagePresenter = new MedicationTimePresenter();
        _model = new CreateMedicationTimeModel(this);
    }

    public override string? MedicationTimeLabel
    {
        get => _drugDosagePresenter.Label;
        set => SetProperty(_drugDosagePresenter.Label, value, _drugDosagePresenter, (d, v) => d.Label = v ?? string.Empty);
    }
    public override TimeSpan? MedicationTimeAppointmentTime
    {
        get => _drugDosagePresenter.Time;
        set => SetProperty(_drugDosagePresenter.Time, value, _drugDosagePresenter, (d, v) => 
        {
            if(v is null)
                return;
            d.Time = (TimeSpan)v;
        });
    }
    public override ObservableCollection<DrugDosagePresenter> MedicationTimeDrugDosages
    {
        get => _drugDosagePresenter.MedicationsTaken;
        set => SetProperty(_drugDosagePresenter.MedicationsTaken, value, _drugDosagePresenter,
(d, v) => d.MedicationsTaken = v);
    }
    public override DrugDosagePresenter? SelectedDrugDosage
    {
        get => _selectedDrugDosage;
        set => SetProperty(ref _selectedDrugDosage, value);
    }
}