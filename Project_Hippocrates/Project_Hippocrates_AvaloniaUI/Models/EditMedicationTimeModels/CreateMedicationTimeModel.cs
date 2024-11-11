using Project_Hippocrates_AvaloniaUI.ViewModels.EditMedicationTimeViewModels;

namespace Project_Hippocrates_AvaloniaUI.Models.EditMedicationTimeModels;

public class CreateMedicationTimeModel
{
    public CreateMedicationTimeModel(CreateMedicationTimeViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    public CreateMedicationTimeViewModel ViewModel { get; set; }
}