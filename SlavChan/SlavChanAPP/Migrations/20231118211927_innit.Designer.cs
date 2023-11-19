﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SlavChanAPP.DataBaseContext;

#nullable disable

namespace SlavChanAPP.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231118211927_innit")]
    partial class innit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SlavChanAPP.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shortcut")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("Boards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ogólna",
                            Shortcut = "ABC"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Technologia",
                            Shortcut = "XYZ"
                        });
                });

            modelBuilder.Entity("SlavChanAPP.Models.Reply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime>("ReplyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReplyImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReplyUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Replies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Hmmm naprawdę ciekawy temat",
                            ReplyDate = new DateTime(2023, 11, 18, 22, 31, 27, 476, DateTimeKind.Local).AddTicks(5935),
                            ReplyUserId = new Guid("3f6901b2-cbc2-40c7-ba5a-e328a11b4e1a"),
                            SubjectId = 2,
                            UserId = new Guid("c81510bb-4bd9-4157-8b28-dedc2eeb8440")
                        },
                        new
                        {
                            Id = 2,
                            Content = "Rzeczywiście daje wiele do myślenia",
                            ReplyDate = new DateTime(2023, 11, 18, 22, 42, 27, 476, DateTimeKind.Local).AddTicks(5940),
                            ReplyUserId = new Guid("c81510bb-4bd9-4157-8b28-dedc2eeb8440"),
                            SubjectId = 2,
                            UserId = new Guid("0624ced6-4927-449f-863f-8c6e526b7a2e")
                        },
                        new
                        {
                            Id = 3,
                            Content = "Rzeczywiście daje wiele do myślenia",
                            ReplyDate = new DateTime(2023, 11, 20, 9, 56, 27, 476, DateTimeKind.Local).AddTicks(5943),
                            ReplyUserId = new Guid("c81510bb-4bd9-4157-8b28-dedc2eeb8440"),
                            SubjectId = 1,
                            UserId = new Guid("0624ced6-4927-449f-863f-8c6e526b7a2e")
                        });
                });

            modelBuilder.Entity("SlavChanAPP.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TimeSinceLastPost")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BoardId = 1,
                            Content = "Treść pierwszego wątku",
                            Name = "Pierwszy wątek",
                            PostDate = new DateTime(2023, 11, 18, 22, 19, 27, 476, DateTimeKind.Local).AddTicks(5873),
                            TimeSinceLastPost = 22f,
                            UserId = new Guid("3f6901b2-cbc2-40c7-ba5a-e328a11b4e1a"),
                            UserName = "User1"
                        },
                        new
                        {
                            Id = 2,
                            BoardId = 2,
                            Content = "Dokąd nocą tupta jeż ??",
                            Name = "Drugi wątek",
                            PostDate = new DateTime(2023, 11, 18, 22, 19, 27, 476, DateTimeKind.Local).AddTicks(5917),
                            TimeSinceLastPost = 22f,
                            UserId = new Guid("25338d9d-33bf-4aa1-a6ee-4bab4872efe5"),
                            UserName = "User2"
                        });
                });

            modelBuilder.Entity("SlavChanAPP.Models.Reply", b =>
                {
                    b.HasOne("SlavChanAPP.Models.Subject", "Subject")
                        .WithMany("Replies")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SlavChanAPP.Models.Subject", b =>
                {
                    b.HasOne("SlavChanAPP.Models.Board", "Board")
                        .WithMany("Subjects")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("SlavChanAPP.Models.Board", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("SlavChanAPP.Models.Subject", b =>
                {
                    b.Navigation("Replies");
                });
#pragma warning restore 612, 618
        }
    }
}