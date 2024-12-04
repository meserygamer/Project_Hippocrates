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
    public string Label { get; set; } = String.Empty;

    /// <summary>
    /// Time to take medication
    /// </summary>
    public TimeSpan Time { get; set; } = TimeSpan.Zero;

    /// <summary>
    /// Medications taken at this time
    /// </summary>
    public IEnumerable<DrugDosage> MedicationsTaken { get; set; } = null!;

    /// <summary>
    /// NotificationId
    /// </summary>
    public int NotificationId { get; set; }
}
