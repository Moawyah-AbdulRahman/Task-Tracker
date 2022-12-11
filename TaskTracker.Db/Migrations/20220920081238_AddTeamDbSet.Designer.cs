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
    [Migration("20220920081238_AddTeamDbSet")]
    partial class AddTeamDbSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<long>("AccessableProjectsProjectId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersUserID")
                        .HasColumnType("bigint");

                    b.HasKey("AccessableProjectsProjectId", "UsersUserID");

                    b.HasIndex("UsersUserID");

                    b.ToTable("ProjectUser");
                });

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

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Projects");
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

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("TaskId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");

                    b.HasCheckConstraint("CK_user_can_access_project", "[dbo].[FnUserCanAccessProject](UserId, OwnerId, ProjectName) = 1");
                });

            modelBuilder.Entity("TaskTracker.Db.Team", b =>
                {
                    b.Property<long>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TeamId"), 1L, 1);

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("TeamKeyPrefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
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

                    b.Property<long>("TeamId")
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

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("TaskTracker.Db.Project", null)
                        .WithMany()
                        .HasForeignKey("AccessableProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskTracker.Db.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("TaskTracker.Db.Project", b =>
                {
                    b.HasOne("TaskTracker.Db.User", "Owner")
                        .WithMany("OwnedProjects")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TaskTracker.Db.Task", b =>
                {
                    b.HasOne("TaskTracker.Db.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskTracker.Db.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

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
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TaskTracker.Db.Project", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("TaskTracker.Db.Task", b =>
                {
                    b.Navigation("Increments");
                });

            modelBuilder.Entity("TaskTracker.Db.Team", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("TaskTracker.Db.User", b =>
                {
                    b.Navigation("OwnedProjects");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
