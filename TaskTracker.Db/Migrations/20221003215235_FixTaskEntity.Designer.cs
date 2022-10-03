﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskTracker.Db;

#nullable disable

namespace TaskTracker.Db.Migrations
{
    [DbContext(typeof(TaskTrackerDbContext))]
    [Migration("20221003215235_FixTaskEntity")]
    partial class FixTaskEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaskTracker.Db.Increment", b =>
                {
                    b.Property<long>("IncrementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IncrementId"), 1L, 1);

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<long>("TaskId")
                        .HasColumnType("bigint");

                    b.HasKey("IncrementId");

                    b.HasIndex("TaskId");

                    b.ToTable("Increments");
                });

            modelBuilder.Entity("TaskTracker.Db.Project", b =>
                {
                    b.Property<long>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProjectId"), 1L, 1);

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TaskTracker.Db.Sprint", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("TeamId")
                        .HasColumnType("bigint");

                    b.HasKey("Name");

                    b.HasIndex("TeamId");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("TaskTracker.Db.StoryPoints", b =>
                {
                    b.Property<int>("Value")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Value"), 1L, 1);

                    b.HasKey("Value");

                    b.ToTable("StoryPoints");

                    b.HasData(
                        new
                        {
                            Value = 1
                        },
                        new
                        {
                            Value = 2
                        },
                        new
                        {
                            Value = 3
                        },
                        new
                        {
                            Value = 4
                        },
                        new
                        {
                            Value = 8
                        },
                        new
                        {
                            Value = 13
                        },
                        new
                        {
                            Value = 21
                        });
                });

            modelBuilder.Entity("TaskTracker.Db.Task", b =>
                {
                    b.Property<long>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TaskId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SprintName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int?>("StoryPointsValue")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("TaskId");

                    b.HasIndex("SprintName");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");

                    b.HasCheckConstraint("ck_task_can_be_assigned_to_sprint", "[dbo].[FnTaskBelongToSprint](TaskId, SprintName) = 1");

                    b.HasCheckConstraint("ck_task_no_in_Progress_if_data_missing", "SprintName IS NOT NULL AND UserId IS NOT NULL AND StoryPointsValue IS NOT NULLOR State = 0");
                });

            modelBuilder.Entity("TaskTracker.Db.Team", b =>
                {
                    b.Property<long>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TeamId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("TeamKeyPrefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TaskTracker.Db.User", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserID"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TeamId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskTracker.Db.Increment", b =>
                {
                    b.HasOne("TaskTracker.Db.Task", "Task")
                        .WithMany("Increments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("TaskTracker.Db.Sprint", b =>
                {
                    b.HasOne("TaskTracker.Db.Team", "Team")
                        .WithMany("Sprints")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TaskTracker.Db.Task", b =>
                {
                    b.HasOne("TaskTracker.Db.Sprint", "Sprint")
                        .WithMany("Tasks")
                        .HasForeignKey("SprintName");

                    b.HasOne("TaskTracker.Db.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId");

                    b.Navigation("Sprint");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskTracker.Db.Team", b =>
                {
                    b.HasOne("TaskTracker.Db.Project", "Project")
                        .WithMany("Teams")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TaskTracker.Db.User", b =>
                {
                    b.HasOne("TaskTracker.Db.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TaskTracker.Db.Project", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("TaskTracker.Db.Sprint", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskTracker.Db.Task", b =>
                {
                    b.Navigation("Increments");
                });

            modelBuilder.Entity("TaskTracker.Db.Team", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Sprints");
                });

            modelBuilder.Entity("TaskTracker.Db.User", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
