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
    [Migration("20231115193832_second")]
    partial class second
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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime>("ReplyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReplyImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ReplyUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Replies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("75a90278-e52b-4d4f-9ca7-9c4def081f85"),
                            Content = "Hmmm naprawdę ciekawy temat",
                            ReplyDate = new DateTime(2023, 11, 15, 20, 50, 32, 641, DateTimeKind.Local).AddTicks(1040),
                            ReplyUserId = new Guid("0a12578d-74ab-4001-8787-72a38c9f9022"),
                            SubjectId = new Guid("25204c1b-b742-4f1f-9ea3-79264f6d4920"),
                            UserId = new Guid("877a24a0-e670-4a08-8045-48f85307a951")
                        },
                        new
                        {
                            Id = new Guid("bf9ce504-a564-4229-a03c-5a313c65aa02"),
                            Content = "Rzeczywiście daje wiele do myślenia",
                            ReplyDate = new DateTime(2023, 11, 15, 21, 1, 32, 641, DateTimeKind.Local).AddTicks(1046),
                            ReplyUserId = new Guid("877a24a0-e670-4a08-8045-48f85307a951"),
                            SubjectId = new Guid("25204c1b-b742-4f1f-9ea3-79264f6d4920"),
                            UserId = new Guid("e23330c3-318f-4d23-a38e-8a21532f8ec3")
                        });
                });

            modelBuilder.Entity("SlavChanAPP.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("dee357fe-8df4-4f9c-a1a9-8c769122b6b7"),
                            BoardId = 1,
                            Content = "Treść pierwszego wątku",
                            Name = "Pierwszy wątek",
                            PostDate = new DateTime(2023, 11, 15, 20, 38, 32, 641, DateTimeKind.Local).AddTicks(902),
                            TimeSinceLastPost = 20f,
                            UserId = new Guid("0a12578d-74ab-4001-8787-72a38c9f9022"),
                            UserName = "User1"
                        },
                        new
                        {
                            Id = new Guid("25204c1b-b742-4f1f-9ea3-79264f6d4920"),
                            BoardId = 2,
                            Content = "Dokąd nocą tupta jeż ??",
                            Name = "Drugi wątek",
                            PostDate = new DateTime(2023, 11, 15, 20, 38, 32, 641, DateTimeKind.Local).AddTicks(942),
                            TimeSinceLastPost = 20f,
                            UserId = new Guid("46202b9d-d7a9-4883-be6b-7c42e81d795b"),
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