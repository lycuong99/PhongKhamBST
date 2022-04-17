﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220417085054_a2")]
    partial class a2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Cost")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PatiendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Symptoms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TreatById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TreatByUId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("TreatmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("TreatByUId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Data.Entities.Medicine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("Data.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfBirth")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Data.Entities.Treatment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTemplate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("Data.Entities.TreatmentDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Dosage")
                        .HasColumnType("int");

                    b.Property<Guid?>("MedicineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NoDay")
                        .HasColumnType("int");

                    b.Property<int>("NoTimeToTakeMedicine")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("TreatmentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TreatmentId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("TreatmentId1");

                    b.ToTable("TreatmentDetail");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<string>("UId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UId = "AVASASSAS",
                            Email = "email1@email.com",
                            Firstname = "NGuyen Van A",
                            Role = "User"
                        },
                        new
                        {
                            UId = "AVASASSAS1",
                            Email = "email2@email.com",
                            Firstname = "NGuyen Van B",
                            Role = "User"
                        },
                        new
                        {
                            UId = "AVASASSAS2",
                            Email = "email3@email.com",
                            Firstname = "NGuyen Van C",
                            Role = "User"
                        });
                });

            modelBuilder.Entity("Data.Entities.Appointment", b =>
                {
                    b.HasOne("Data.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("Data.Entities.User", "TreatBy")
                        .WithMany()
                        .HasForeignKey("TreatByUId");

                    b.HasOne("Data.Entities.Treatment", "Treatment")
                        .WithMany()
                        .HasForeignKey("TreatmentId");
                });

            modelBuilder.Entity("Data.Entities.TreatmentDetail", b =>
                {
                    b.HasOne("Data.Entities.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId");

                    b.HasOne("Data.Entities.Treatment", "Treatment")
                        .WithMany("TreatmentDetails")
                        .HasForeignKey("TreatmentId1");
                });
#pragma warning restore 612, 618
        }
    }
}
