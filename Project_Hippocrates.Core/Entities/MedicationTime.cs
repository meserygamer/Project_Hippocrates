namespace Project_Hippocrates.Core.Entities;

public class MedicationTime
{
    /// <summary>
    /// Medication time id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Medication time label
    /// </summary>
    public string Label { get; set; } = null!;

    /// <summary>
    /// Time to take medication
    /// </summary>
    public TimeOnly Time { get; set; }

    /// <summary>
    /// Medications taken at this time
    /// </summary>
    public IEnumerable<DrugDosage> MedicationsTaken { get; set; } = null!;
}
