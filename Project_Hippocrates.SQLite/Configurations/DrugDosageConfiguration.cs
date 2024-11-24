using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Configurations;

public class DrugDosageConfiguration : IEntityTypeConfiguration<DrugDosageEntity>
{
    public void Configure(EntityTypeBuilder<DrugDosageEntity> builder)
    {
        builder.ToTable("DrugDosages")
            .HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .IsRequired();
        
        builder.Property(d => d.DrugId)
            .IsRequired();

        builder.Property(d => d.MedicationTimeId)
            .IsRequired();
        
        builder.Property(d => d.Value)
            .IsRequired();
        
        builder.Property(d => d.Unit)
            .IsRequired()
            .HasMaxLength(255);
    }
}