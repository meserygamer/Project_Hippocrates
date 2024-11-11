using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Project_Hippocrates_AvaloniaUI.Models;
using Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;

namespace Project_Hippocrates_AvaloniaUI.ViewModels;

public partial class EditMedicationTimeViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<string> _allowableDosageUnits =
    [
        "т.",
        "мг.",
        "мл.",
        "кап."
    ];
    
    [ObservableProperty]
    private ObservableCollection<DrugDosagePresenter> _dosagePresenters = 
    [
        new (){DrugName = "Drug 1", DrugDose = 10, DoseUnit = "т."},
        new (){DrugName = "Drug 2", DrugDose = 30, DoseUnit = "т."},
        new (){DrugName = "Drug 1", DrugDose = 10, DoseUnit = "т."},
        new (){DrugName = "Drug 2", DrugDose = 30, DoseUnit = "т."}
    ];

    [ObservableProperty]
    private DrugDosagePresenter? _editingDrugDosagePresenter;

    public void RemoveDrugDosagePresenter()
    {
        if(EditingDrugDosagePresenter is null)
            return;

        DosagePresenters.Remove(EditingDrugDosagePresenter);
    }

    public void AddDrugDosagePresenter()
    {
        DosagePresenters.Add(new DrugDosagePresenter());
    }
}