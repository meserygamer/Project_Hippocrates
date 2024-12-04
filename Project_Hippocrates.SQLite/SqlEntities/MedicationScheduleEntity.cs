namespace Project_Hippocrates.SQLite.SqlEntities;

public class MedicationScheduleEntity
{
    /// <summary>
    /// Medication schedule id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Medication schedule name
    /// </summary>
    public string Name { get; set; } = null!;

    #region Navigation properties

    /// <summary>
    /// Medication times
    /// </summary>
    public ICollection<MedicationTimeEntity> MedicationTimes { get; set; } = null!;

    #endregion
}