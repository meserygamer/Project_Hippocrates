using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Configurations;

public class MedicalDrugConfiguration : IEntityTypeConfiguration<MedicalDrugEntity>
{
    public void Configure(EntityTypeBuilder<MedicalDrugEntity> builder)
    {
        builder.ToTable("MedicalDrugs")
            .HasKey(md => md.Id);

        builder.Property(md => md.Id)
            .IsRequired();

        builder.Property(md => md.Name)
            .IsRequired()
            .HasMaxLength(512);

        builder.HasOne(md => md.DrugDosage)
            .WithOne(d => d.Drug)
            .HasForeignKey<DrugDosageEntity>(d => d.DrugId)
            .IsRequired(false); 
    }
}