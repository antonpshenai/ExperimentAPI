﻿// <auto-generated />
using System;
using ExperementsAPI.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExperementsAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240218172536_UpdateRename")]
    partial class UpdateRename
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExperementsAPI.Model.DeviceExperiments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("ExperimentId")
                        .HasColumnType("int");

                    b.Property<int>("ExperimentValueId")
                        .HasColumnType("int");

                    b.Property<int?>("ExperimentValuesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("ExperimentId");

                    b.HasIndex("ExperimentValuesId");

                    b.ToTable("DeviceExperiments");
                });

            modelBuilder.Entity("ExperementsAPI.Model.Devices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeviceToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ExperementsAPI.Model.ExperimentValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExperimentId")
                        .HasColumnType("int");

                    b.Property<double?>("ProcentValue")
                        .HasColumnType("float");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExperimentId");

                    b.ToTable("ExperimentValues");
                });

            modelBuilder.Entity("ExperementsAPI.Model.Experiments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExperimentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Experiments");
                });

            modelBuilder.Entity("ExperementsAPI.Model.DeviceExperiments", b =>
                {
                    b.HasOne("ExperementsAPI.Model.Devices", "Device")
                        .WithMany("DeviceExperiments")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExperementsAPI.Model.Experiments", "Experiment")
                        .WithMany("DeviceExperiments")
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExperementsAPI.Model.ExperimentValues", "ExperimentValues")
                        .WithMany("DeviceExperiments")
                        .HasForeignKey("ExperimentValuesId");

                    b.Navigation("Device");

                    b.Navigation("Experiment");

                    b.Navigation("ExperimentValues");
                });

            modelBuilder.Entity("ExperementsAPI.Model.ExperimentValues", b =>
                {
                    b.HasOne("ExperementsAPI.Model.Experiments", "Experiments")
                        .WithMany("ExperimentValues")
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experiments");
                });

            modelBuilder.Entity("ExperementsAPI.Model.Devices", b =>
                {
                    b.Navigation("DeviceExperiments");
                });

            modelBuilder.Entity("ExperementsAPI.Model.ExperimentValues", b =>
                {
                    b.Navigation("DeviceExperiments");
                });

            modelBuilder.Entity("ExperementsAPI.Model.Experiments", b =>
                {
                    b.Navigation("DeviceExperiments");

                    b.Navigation("ExperimentValues");
                });
#pragma warning restore 612, 618
        }
    }
}