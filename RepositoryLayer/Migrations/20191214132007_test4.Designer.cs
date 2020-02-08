﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer.Context;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(AuthenticationContext))]
    [Migration("20191214132007_test4")]
    partial class test4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommonLayer.Model.CollaborateModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CollaboratedBy");

                    b.Property<int>("CollaboratedWith");

                    b.Property<int>("NoteId");

                    b.HasKey("Id");

                    b.ToTable("Collaborate");
                });

            modelBuilder.Entity("CommonLayer.Model.LabelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Lable")
                        .IsRequired();

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Lables");
                });

            modelBuilder.Entity("CommonLayer.Model.NoteLabelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Delete");

                    b.Property<int>("LabelId");

                    b.Property<int>("NoteId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("NoteLabel");
                });

            modelBuilder.Entity("CommonLayer.Model.NotesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddReminder");

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<bool>("IsArchive");

                    b.Property<bool>("IsNote");

                    b.Property<bool>("IsPin");

                    b.Property<bool>("IsTrash");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("CommonLayer.Model.RegistrationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MobileNumber")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("ProfilePicture");

                    b.Property<string>("ServiceType")
                        .IsRequired();

                    b.Property<string>("UserType")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Registration");
                });
#pragma warning restore 612, 618
        }
    }
}