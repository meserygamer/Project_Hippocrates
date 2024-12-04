using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Configurations;

public class MedicationScheduleConfiguration : IEntityTypeConfiguration<MedicationScheduleEntity>
{
    public void Configure(EntityTypeBuilder<MedicationScheduleEntity> builder)
    {
        builder.ToTable("MedicationSchedules")
            .HasKey(ms => ms.Id);

        builder.Property(ms => ms.Id)
            .IsRequired();
        
        builder.Property(ms => ms.Name)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.HasMany(ms => ms.MedicationTimes)
            .WithOne(mt => mt.MedicationSchedule)
            .HasForeignKey(mt => mt.MedicationScheduleId)
            .IsRequired(true);

        builder.HasData(
            new MedicationScheduleEntity
            {
                Id = new Guid("f5fd4ea2-9bd4-456f-b704-af8f4c9b82e6"),
                MedicationTimes = [],
                Name = "Главное расписание"
            }
            );
    }
}