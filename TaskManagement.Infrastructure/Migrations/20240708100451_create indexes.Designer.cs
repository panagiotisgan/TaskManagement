﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagement.Infrastructure.Context;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    [DbContext(typeof(TaskManagementContext))]
    [Migration("20240708100451_create indexes")]
    partial class createindexes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManagement.Domain.Models.Assignment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte[]>("Attachements")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("NeedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("SeverityLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AssignmentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CommentId")
                        .HasColumnType("bigint");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("CommentId");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AssignmentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PreviousTaskState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.TeamUser", b =>
                {
                    b.Property<long>("TeamId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("TeamId", "UserId");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("TeamUser");
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHashed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.UserTask", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("AssignmentId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "AssignmentId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserTask");
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.Assignment", b =>
                {
                    b.HasOne("TaskManagement.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.Comment", b =>
                {
                    b.HasOne("TaskManagement.Domain.Models.Assignment", "Assignment")
                        .WithMany("Comments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagement.Domain.Models.Comment", null)
                        .WithMany("Comments")
                        .HasForeignKey("CommentId");

                    b.HasOne("TaskManagement.Domain.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.Log", b =>
                {
                    b.HasOne("TaskManagement.Domain.Models.Assignment", null)
                        .WithMany("Logs")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.TeamUser", b =>
                {
                    b.HasOne("TaskManagement.Domain.Models.Team", null)
                        .WithOne("TeamUser")
                        .HasForeignKey("TaskManagement.Domain.Models.TeamUser", "TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagement.Domain.Models.User", null)
                        .WithOne("TeamUser")
                        .HasForeignKey("TaskManagement.Domain.Models.TeamUser", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.UserTask", b =>
                {
                    b.HasOne("TaskManagement.Domain.Models.User", null)
                        .WithOne("UserTask")
                        .HasForeignKey("TaskManagement.Domain.Models.UserTask", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.Assignment", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Logs");
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.Comment", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.Team", b =>
                {
                    b.Navigation("TeamUser")
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagement.Domain.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("TeamUser")
                        .IsRequired();

                    b.Navigation("UserTask")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
