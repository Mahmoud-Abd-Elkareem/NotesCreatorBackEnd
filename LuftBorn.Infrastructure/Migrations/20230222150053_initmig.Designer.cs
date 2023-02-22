﻿// <auto-generated />
using System;
using LuftBorn.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LuftBorn.Infrastructure.Migrations
{
    [DbContext(typeof(LuftBornContext))]
    [Migration("20230222150053_initmig")]
    partial class initmig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LuftBorn.Domain.Model.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("LuftBorn.Domain.Model.Note", b =>
                {
                    b.OwnsOne("LuftBorn.Domain.ValueObjects.DescriptionLocalized", "Description", b1 =>
                        {
                            b1.Property<Guid>("NoteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DescriptionAr");

                            b1.Property<string>("DescriptionEn")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DescriptionEn");

                            b1.HasKey("NoteId");

                            b1.ToTable("Notes");

                            b1.WithOwner()
                                .HasForeignKey("NoteId");
                        });

                    b.OwnsOne("LuftBorn.Domain.ValueObjects.DescriptionLocalized", "Name", b1 =>
                        {
                            b1.Property<Guid>("NoteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NameAr");

                            b1.Property<string>("DescriptionEn")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NameEn");

                            b1.HasKey("NoteId");

                            b1.ToTable("Notes");

                            b1.WithOwner()
                                .HasForeignKey("NoteId");
                        });

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
