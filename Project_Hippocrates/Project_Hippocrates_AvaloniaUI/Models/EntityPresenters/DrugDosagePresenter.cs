namespace Project_Hippocrates_AvaloniaUI.Models.EntityPresenters;

public class DrugDosagePresenter
{
    public string DrugName { get; set; } = null!;
    public uint DrugDose { get; set; }
    public string DoseUnit { get; set; } = null!;
}