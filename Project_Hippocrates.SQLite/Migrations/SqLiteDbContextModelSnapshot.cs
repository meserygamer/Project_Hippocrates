﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Hippocrates.SQLite;

#nullable disable

namespace Project_Hippocrates.SQLite.Migrations
{
    [DbContext(typeof(SqLiteDbContext))]
    partial class SqLiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Project_Hippocrates.SQLite.SqlEntities.DrugDosageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DrugId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("MedicationTimeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<uint>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DrugId")
                        .IsUnique();

                    b.HasIndex("MedicationTimeId");

                    b.ToTable("DrugDosages", (string)null);
                });

            modelBuilder.Entity("Project_Hippocrates.SQLite.SqlEntities.MedicalDrugEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MedicalDrugs", (string)null);
                });

            modelBuilder.Entity("Project_Hippocrates.SQLite.SqlEntities.MedicationScheduleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MedicationSchedules", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5fd4ea2-9bd4-456f-b704-af8f4c9b82e6"),
                            Name = "Главное расписание"
                        });
                });

            modelBuilder.Entity("Project_Hippocrates.SQLite.SqlEntities.MedicationTimeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("MedicationScheduleId")
                        .HasColumnType("TEXT");

                    b.Property<int>("PushNotificationId")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MedicationScheduleId");

                    b.ToTable("MedicationTimes", (string)null);
                });

            modelBuilder.Entity("Project_Hippocrates.SQLite.SqlEntities.DrugDosageEntity", b =>
                {
                    b.HasOne("Project_Hippocrates.SQLite.SqlEntities.MedicalDrugEntity", "Drug")
                        .WithOne("DrugDosage")
                        .HasForeignKey("Project_Hippocrates.SQLite.SqlEntities.DrugDosageEntity", "DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Hippocrates.SQLite.SqlEntities.MedicationTimeEntity", "MedicationTime")
                        .WithMany("MedicationsTaken")
                        .HasForeignKey("MedicationTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drug");

                    b.Navigation("MedicationTime");
                });

            modelBuilder.Entity("Project_Hippocrates.SQLite.SqlEntities.MedicationTimeEntity", b =>
                {
                    b.HasOne("Project_Hippocrates.SQLite.SqlEntities.MedicationScheduleEntity", "MedicationSchedule")
                        .WithMany("MedicationTimes")
                        .HasForeignKey("MedicationScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicationSchedule");
                });

            modelBuilder.Entity("Project_Hippocrates.SQLite.SqlEntities.MedicalDrugEntity", b =>
                {
                    b.Navigation("DrugDosage");
                });

            modelBuilder.Entity("Project_Hippocrates.SQLite.SqlEntities.MedicationScheduleEntity", b =>
                {
                    b.Navigation("MedicationTimes");
                });

            modelBuilder.Entity("Project_Hippocrates.SQLite.SqlEntities.MedicationTimeEntity", b =>
                {
                    b.Navigation("MedicationsTaken");
                });
#pragma warning restore 612, 618
        }
    }
}
