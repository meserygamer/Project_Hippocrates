namespace Project_Hippocrates.Core.Entities;
    
public class MedicalDrug
{
    /// <summary>
    /// Drug Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Drug name
    /// </summary>
    public string Name { get; set; } = null!;
}
