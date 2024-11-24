namespace Project_Hippocrates.SQLite.SqlEntities;

public class MedicalDrugEntity
{
    /// <summary>
    /// Drug Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Drug name
    /// </summary>
    public string Name { get; set; } = null!;

    #region Navigation properties

    public DrugDosageEntity? DrugDosage { get; set; }

    #endregion
}