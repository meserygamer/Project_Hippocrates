namespace Project_Hippocrates.SQLite.SqlEntities;

public class DrugDosageEntity
{
    /// <summary>
    /// Dosage id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Drug that's taking id
    /// </summary>
    public Guid DrugId { get; set; }
    /// <summary>
    /// Drug dosage value
    /// </summary>
    public uint Value { get; set; }
    /// <summary>
    /// Unit of drug dosage value
    /// </summary>
    public string Unit { get; set; } = null!;

    #region Navigation properies

    /// <summary>
    /// Drug that's taking
    /// </summary>
    public MedicalDrugEntity Drug { get; set; } = null!;

    #endregion
}