﻿// <auto-generated />
using System;
using DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBContext.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220215062019_changeStatusType_Candidate_Apply")]
    partial class changeStatusType_Candidate_Apply
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Entities.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("CVFile")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CVFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("PresenterId")
                        .HasColumnType("int");

                    b.Property<int>("TitleID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("PresenterId");

                    b.HasIndex("TitleID");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("Models.Entities.Candidate_Apply", b =>
                {
                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("CandidateId");

                    b.ToTable("Candidate_Apply");
                });

            modelBuilder.Entity("Models.Entities.Candidate_Email", b =>
                {
                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<int>("Contactable")
                        .HasColumnType("int");

                    b.Property<string>("ContentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterviewLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InterviewTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TestPoint")
                        .HasColumnType("int");

                    b.HasKey("CandidateID");

                    b.ToTable("Candidate_Email");
                });

            modelBuilder.Entity("Models.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Models.Entities.Presenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Presenter");
                });

            modelBuilder.Entity("Models.Entities.Titles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("Models.Entities.Candidate", b =>
                {
                    b.HasOne("Models.Entities.Position", "Position")
                        .WithMany("Candidates")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Presenter", "Presenter")
                        .WithMany("Candidates")
                        .HasForeignKey("PresenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Titles", "Title")
                        .WithMany("Candidates")
                        .HasForeignKey("TitleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");

                    b.Navigation("Presenter");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Models.Entities.Candidate_Apply", b =>
                {
                    b.HasOne("Models.Entities.Candidate", "Candidate")
                        .WithOne("CandiDate_Apply")
                        .HasForeignKey("Models.Entities.Candidate_Apply", "CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("Models.Entities.Candidate_Email", b =>
                {
                    b.HasOne("Models.Entities.Candidate", "Candidate")
                        .WithOne("Candidate_Email")
                        .HasForeignKey("Models.Entities.Candidate_Email", "CandidateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("Models.Entities.Candidate", b =>
                {
                    b.Navigation("CandiDate_Apply")
                        .IsRequired();

                    b.Navigation("Candidate_Email")
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Entities.Position", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("Models.Entities.Presenter", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("Models.Entities.Titles", b =>
                {
                    b.Navigation("Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}
