using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_Hippocrates.SQLite.SqlEntities;

namespace Project_Hippocrates.SQLite.Configurations;

public class MedicationTimeConfiguration : IEntityTypeConfiguration<MedicationTimeEntity>
{
    public void Configure(EntityTypeBuilder<MedicationTimeEntity> builder)
    {
        builder.ToTable("MedicationTimes")
            .HasKey(ms => ms.Id);

        builder.Property(ms => ms.Id)
            .IsRequired();

        builder.Property(ms => ms.Label)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(ms => ms.Time)
            .IsRequired();

        builder.Property(ms => ms.MedicationScheduleId)
            .IsRequired(false);

        builder.Property(ms => ms.PushNotificationId)
            .IsRequired(true);

        builder.HasMany(ms => ms.MedicationsTaken)
            .WithOne(mt => mt.MedicationTime)
            .HasForeignKey(mt => mt.MedicationTimeId)
            .IsRequired(true);
    }
}