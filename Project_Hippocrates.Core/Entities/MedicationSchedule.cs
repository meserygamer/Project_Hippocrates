namespace Project_Hippocrates.Core.Entities;

public class MedicationSchedule
{
    /// <summary>
    /// Medication schedule id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Medication schedule name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Medication times
    /// </summary>
    public IEnumerable<MedicationTime> MedicationTimes { get; set; } = null!;
}
