﻿// <auto-generated />
using System;
using EFCore1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SQL.Migrations
{
    [DbContext(typeof(EFCoreContext))]
    partial class EFCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ListOfServices")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clinic");
                });

            modelBuilder.Entity("ClinicOwner", b =>
                {
                    b.Property<int>("ClinicSubscriptionsId")
                        .HasColumnType("int");

                    b.Property<int>("Patient")
                        .HasColumnType("int");

                    b.Property<int?>("PatientsId")
                        .HasColumnType("int");

                    b.HasKey("ClinicSubscriptionsId", "Patient");

                    b.HasIndex("Patient");

                    b.HasIndex("PatientsId");

                    b.ToTable("ClinicOwner");
                });

            modelBuilder.Entity("EFCore1.Models.OwnerSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("OwnerSettings");
                });

            modelBuilder.Entity("MedicalRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("MedicalRecord");
                });

            modelBuilder.Entity("MedicalRecordOwner", b =>
                {
                    b.Property<int>("MedicalOwnersId")
                        .HasColumnType("int");

                    b.Property<int>("MedicalRecordsId")
                        .HasColumnType("int");

                    b.HasKey("MedicalOwnersId", "MedicalRecordsId");

                    b.HasIndex("MedicalRecordsId");

                    b.ToTable("MedicalRecordOwner");
                });

            modelBuilder.Entity("SQL.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("ClinicOwner", b =>
                {
                    b.HasOne("Clinic", null)
                        .WithMany()
                        .HasForeignKey("ClinicSubscriptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SQL.Models.Owner", null)
                        .WithMany()
                        .HasForeignKey("Patient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SQL.Models.Owner", null)
                        .WithMany()
                        .HasForeignKey("PatientsId");
                });

            modelBuilder.Entity("EFCore1.Models.OwnerSettings", b =>
                {
                    b.HasOne("SQL.Models.Owner", "Owner")
                        .WithOne("OwnerSettings")
                        .HasForeignKey("EFCore1.Models.OwnerSettings", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MedicalRecord", b =>
                {
                    b.HasOne("Clinic", "Clinic")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");
                });

            modelBuilder.Entity("MedicalRecordOwner", b =>
                {
                    b.HasOne("SQL.Models.Owner", null)
                        .WithMany()
                        .HasForeignKey("MedicalOwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalRecord", null)
                        .WithMany()
                        .HasForeignKey("MedicalRecordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clinic", b =>
                {
                    b.Navigation("MedicalRecords");
                });

            modelBuilder.Entity("SQL.Models.Owner", b =>
                {
                    b.Navigation("OwnerSettings");
                });
#pragma warning restore 612, 618
        }
    }
}
