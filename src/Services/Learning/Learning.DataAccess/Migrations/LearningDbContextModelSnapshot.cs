﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Learning.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Learning.DataAccess.Migrations
{
    [DbContext(typeof(LearningDbContext))]
    partial class LearningDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("QuestionSequence");

            modelBuilder.Entity("Learning.Domain.Models.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("Learning.Domain.Models.DomainArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChapterId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("Learning.Domain.Models.Questions.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"QuestionSequence\"')");

                    NpgsqlPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("DomainId")
                        .HasColumnType("integer");

                    b.Property<string>("Explanation")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Learning.Domain.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AllowedMistakes")
                        .HasColumnType("integer");

                    b.Property<int>("DomainId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("NumberOfQuestions")
                        .HasColumnType("integer");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Learning.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Learning.Domain.Models.Questions.BuildSentanceQuestion", b =>
                {
                    b.HasBaseType("Learning.Domain.Models.Questions.Question");

                    b.Property<List<string>>("Words")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.ToTable("BuildSentanceQuestions");
                });

            modelBuilder.Entity("Learning.Domain.Models.Questions.MediaQuestion", b =>
                {
                    b.HasBaseType("Learning.Domain.Models.Questions.Question");

                    b.Property<string>("MediaFileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("MediaQuestions");
                });

            modelBuilder.Entity("Learning.Domain.Models.Questions.TranslateQuestion", b =>
                {
                    b.HasBaseType("Learning.Domain.Models.Questions.Question");

                    b.Property<string>("TextToTranslate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("TranslateQuestions");
                });

            modelBuilder.Entity("Learning.Domain.Models.DomainArea", b =>
                {
                    b.HasOne("Learning.Domain.Models.Chapter", "Chapter")
                        .WithMany("Domains")
                        .HasForeignKey("ChapterId");

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("Learning.Domain.Models.Questions.Question", b =>
                {
                    b.HasOne("Learning.Domain.Models.DomainArea", "Domain")
                        .WithMany("Questions")
                        .HasForeignKey("DomainId");

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("Learning.Domain.Models.Test", b =>
                {
                    b.HasOne("Learning.Domain.Models.DomainArea", "Domain")
                        .WithMany("Tests")
                        .HasForeignKey("DomainId");

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("Learning.Domain.Models.Chapter", b =>
                {
                    b.Navigation("Domains");
                });

            modelBuilder.Entity("Learning.Domain.Models.DomainArea", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
