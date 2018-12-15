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
    [Migration("20181202165425_ChangeSourceToStringv2")]
    partial class ChangeSourceToStringv2
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

            modelBuilder.Entity("HealthDataRepository.Models.ActivityMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActivityTypeId");

                    b.Property<string>("MappingKey")
                        .IsRequired();

                    b.Property<string>("Source")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeId");

                    b.ToTable("ActivityMapping");
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

            modelBuilder.Entity("HealthDataRepository.Models.Activity", b =>
                {
                    b.HasOne("HealthDataRepository.Models.ActivityType", "ActivityType")
                        .WithMany()
                        .HasForeignKey("ActivityTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthDataRepository.Models.ActivityMapping", b =>
                {
                    b.HasOne("HealthDataRepository.Models.ActivityType")
                        .WithMany("Mappings")
                        .HasForeignKey("ActivityTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
