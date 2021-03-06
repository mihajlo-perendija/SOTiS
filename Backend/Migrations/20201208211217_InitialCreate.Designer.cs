﻿// <auto-generated />
using System;
using Backend.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201208211217_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Backend.Entities.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Correct")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Backend.Entities.Edge", b =>
                {
                    b.Property<int>("EdgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("KnowledgeSpaceId")
                        .HasColumnType("int");

                    b.Property<int?>("ProblemSourceId")
                        .HasColumnType("int");

                    b.Property<int?>("ProblemTargetId")
                        .HasColumnType("int");

                    b.HasKey("EdgeId");

                    b.HasIndex("KnowledgeSpaceId");

                    b.HasIndex("ProblemSourceId");

                    b.HasIndex("ProblemTargetId");

                    b.ToTable("Edges");
                });

            modelBuilder.Entity("Backend.Entities.Enrolement", b =>
                {
                    b.Property<int>("EnrolementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("EnrolementId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TestId");

                    b.ToTable("Enrolements");
                });

            modelBuilder.Entity("Backend.Entities.EnrolementAnswer", b =>
                {
                    b.Property<int>("EnrolementAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("EnrolementId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("Skipped")
                        .HasColumnType("bit");

                    b.HasKey("EnrolementAnswerId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("EnrolementId");

                    b.HasIndex("QuestionId");

                    b.ToTable("EnrolementAnswers");
                });

            modelBuilder.Entity("Backend.Entities.KnowledgeSpace", b =>
                {
                    b.Property<int>("KnowledgeSpaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KnowledgeSpaceId");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("TestId")
                        .IsUnique()
                        .HasFilter("[TestId] IS NOT NULL");

                    b.ToTable("KnowledgeSpaces");
                });

            modelBuilder.Entity("Backend.Entities.Problem", b =>
                {
                    b.Property<int>("ProblemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("KnowledgeSpaceId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("ProblemId");

                    b.HasIndex("KnowledgeSpaceId");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("Backend.Entities.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("Backend.Entities.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsMultipleChoice")
                        .HasColumnType("bit");

                    b.Property<int>("ProblemId")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Backend.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Backend.Entities.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KnowledgeSpaceId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Backend.Entities.Answer", b =>
                {
                    b.HasOne("Backend.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Backend.Entities.Edge", b =>
                {
                    b.HasOne("Backend.Entities.KnowledgeSpace", null)
                        .WithMany("Edges")
                        .HasForeignKey("KnowledgeSpaceId");

                    b.HasOne("Backend.Entities.Problem", "ProblemSource")
                        .WithMany()
                        .HasForeignKey("ProblemSourceId");

                    b.HasOne("Backend.Entities.Problem", "ProblemTarget")
                        .WithMany()
                        .HasForeignKey("ProblemTargetId");

                    b.Navigation("ProblemSource");

                    b.Navigation("ProblemTarget");
                });

            modelBuilder.Entity("Backend.Entities.Enrolement", b =>
                {
                    b.HasOne("Backend.Entities.Student", "Student")
                        .WithMany("Enrolements")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Entities.Test", "Test")
                        .WithMany("Enrolements")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Backend.Entities.EnrolementAnswer", b =>
                {
                    b.HasOne("Backend.Entities.Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId");

                    b.HasOne("Backend.Entities.Enrolement", "Enrolement")
                        .WithMany("EnrolementAnswers")
                        .HasForeignKey("EnrolementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.Navigation("Answer");

                    b.Navigation("Enrolement");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Backend.Entities.KnowledgeSpace", b =>
                {
                    b.HasOne("Backend.Entities.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.HasOne("Backend.Entities.Test", "Test")
                        .WithOne("KnowledgeSpace")
                        .HasForeignKey("Backend.Entities.KnowledgeSpace", "TestId");

                    b.Navigation("Professor");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Backend.Entities.Problem", b =>
                {
                    b.HasOne("Backend.Entities.KnowledgeSpace", null)
                        .WithMany("Problems")
                        .HasForeignKey("KnowledgeSpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Entities.Question", b =>
                {
                    b.HasOne("Backend.Entities.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Backend.Entities.Test", b =>
                {
                    b.HasOne("Backend.Entities.Professor", "Professor")
                        .WithMany("Tests")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Backend.Entities.Enrolement", b =>
                {
                    b.Navigation("EnrolementAnswers");
                });

            modelBuilder.Entity("Backend.Entities.KnowledgeSpace", b =>
                {
                    b.Navigation("Edges");

                    b.Navigation("Problems");
                });

            modelBuilder.Entity("Backend.Entities.Professor", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Backend.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Backend.Entities.Student", b =>
                {
                    b.Navigation("Enrolements");
                });

            modelBuilder.Entity("Backend.Entities.Test", b =>
                {
                    b.Navigation("Enrolements");

                    b.Navigation("KnowledgeSpace");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
