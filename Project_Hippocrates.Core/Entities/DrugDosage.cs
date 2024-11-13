namespace Project_Hippocrates.Core.Entities;

public class DrugDosage
{
    /// <summary>
    /// Dosage id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Drug that's taking
    /// </summary>
    public MedicalDrug Drug { get; set; } = null!;

    /// <summary>
    /// Drug dosage value
    /// </summary>
    public uint DrugDoseValue { get; set; }

    /// <summary>
    /// Unit of drug dosage value
    /// </summary>
    public string DoseUnit { get; set; } = null!;
}
