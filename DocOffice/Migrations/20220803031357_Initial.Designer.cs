﻿// <auto-generated />
using DocOffice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DocOffice.Migrations
{
    [DbContext(typeof(DocOfficeContext))]
    [Migration("20220803031357_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DocOffice.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DocOffice.Models.Spec", b =>
                {
                    b.Property<int>("SpecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("SpecId");

                    b.ToTable("Specs");
                });

            modelBuilder.Entity("DocOffice.Models.SpecDoctor", b =>
                {
                    b.Property<int>("SpecDoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("SpecId")
                        .HasColumnType("int");

                    b.HasKey("SpecDoctorId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("SpecId");

                    b.ToTable("SpecDoctor");
                });

            modelBuilder.Entity("DocOffice.Models.SpecDoctor", b =>
                {
                    b.HasOne("DocOffice.Models.Doctor", "Doctor")
                        .WithMany("JoinEntities")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocOffice.Models.Spec", "Spec")
                        .WithMany("JoinEntities")
                        .HasForeignKey("SpecId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Spec");
                });

            modelBuilder.Entity("DocOffice.Models.Doctor", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("DocOffice.Models.Spec", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
