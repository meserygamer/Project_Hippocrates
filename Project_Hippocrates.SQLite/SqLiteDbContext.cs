using Microsoft.EntityFrameworkCore;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite;

public class SqLiteDbContext : DbContext
{
    private readonly ISqLiteDbConnectionStringProvider? _connectionStringProvider;

    //For creating migration
    public SqLiteDbContext() { }
    public SqLiteDbContext(ISqLiteDbConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
        Database.Migrate();
    }

    public DbSet<DrugDosageEntity> DrugDosages { get; set; }
    public DbSet<MedicalDrugEntity> MedicalDrugs { get; set; }
    public DbSet<MedicationScheduleEntity> MedicationSchedules { get; set; }
    public DbSet<MedicationTimeEntity> MedicationTimes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connectionStringProvider?.ConnectionString ?? "");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqLiteDbContext).Assembly);
    }
}