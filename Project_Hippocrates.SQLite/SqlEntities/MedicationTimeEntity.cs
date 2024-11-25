namespace Project_Hippocrates.SQLite.SqlEntities;

public class MedicationTimeEntity
{
    /// <summary>
    /// Medication time id
    /// </summary>
    public Guid Id { get; set; }

    public Guid? MedicationScheduleId { get; set; }

    /// <summary>
    /// Medication time label
    /// </summary>
    public string Label { get; set; } = String.Empty;

    /// <summary>
    /// Time to take medication
    /// </summary>
    public TimeSpan Time { get; set; } = TimeSpan.Zero;

    #region Navigation properties

    public MedicationScheduleEntity? MedicationSchedule { get; set; }

    /// <summary>
    /// Medications taken at this time
    /// </summary>
    public ICollection<DrugDosageEntity> MedicationsTaken { get; set; } = null!;

    #endregion
}