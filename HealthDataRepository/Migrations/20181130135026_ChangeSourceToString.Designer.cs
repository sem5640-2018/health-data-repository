﻿// <auto-generated />
using System;
using HealthDataRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthDataRepository.Migrations
{
    [DbContext(typeof(HealthDataRepositoryContext))]
    [Migration("20181130135026_ChangeSourceToString")]
    partial class ChangeSourceToString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HealthDataRepository.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityTypeId");

                    b.Property<int>("AverageHeartRate");

                    b.Property<int>("CaloriesBurnt");

                    b.Property<DateTime>("EndTimestamp");

                    b.Property<double>("MetresElevationGained");

                    b.Property<double>("MetresTravelled");

                    b.Property<string>("Source")
                        .IsRequired();

                    b.Property<DateTime>("StartTimestamp");

                    b.Property<int>("StepsTaken");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("HealthDataRepository.Models.ActivityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ActivityType");
                });

            modelBuilder.Entity("HealthDataRepository.Models.ActivityTypeSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActivityTypeId");

                    b.Property<int>("Source");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeId");

                    b.ToTable("ActivityTypeSource");
                });

            modelBuilder.Entity("HealthDataRepository.Models.SourceActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActivityTypeSourceId");

                    b.Property<string>("ServiceActivityId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeSourceId");

                    b.ToTable("SourceActivity");
                });

            modelBuilder.Entity("HealthDataRepository.Models.Activity", b =>
                {
                    b.HasOne("HealthDataRepository.Models.ActivityType", "ActivityType")
                        .WithMany()
                        .HasForeignKey("ActivityTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthDataRepository.Models.ActivityTypeSource", b =>
                {
                    b.HasOne("HealthDataRepository.Models.ActivityType")
                        .WithMany("Sources")
                        .HasForeignKey("ActivityTypeId");
                });

            modelBuilder.Entity("HealthDataRepository.Models.SourceActivity", b =>
                {
                    b.HasOne("HealthDataRepository.Models.ActivityTypeSource")
                        .WithMany("SourceActivities")
                        .HasForeignKey("ActivityTypeSourceId");
                });
#pragma warning restore 612, 618
        }
    }
}
