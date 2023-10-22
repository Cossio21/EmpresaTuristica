﻿// <auto-generated />
using EmpresaTuristica.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmpresaTuristica.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmpresaTuristica.Shared.Entities.Actividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("EmpresaTuristica.Shared.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("EmpresaTuristica.Shared.Entities.Recorrido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Recorridos");
                });

            modelBuilder.Entity("EmpresaTuristica.Shared.Entities.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PagoFinal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PagoInicial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecorridoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecorridoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("EmpresaTuristica.Shared.Entities.SitioTuristico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActividadId")
                        .HasColumnType("int");

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ActividadId");

                    b.HasIndex("CiudadId");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("SitiosTuristicos");
                });

            modelBuilder.Entity("EmpresaTuristica.Shared.Entities.SitiosRecorrido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RecorridoId")
                        .HasColumnType("int");

                    b.Property<int>("SitioTuristicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecorridoId");

                    b.HasIndex("SitioTuristicoId");

                    b.ToTable("SitiosRecorridos");
                });

            modelBuilder.Entity("EmpresaTuristica.Shared.Entities.Reserva", b =>
                {
                    b.HasOne("EmpresaTuristica.Shared.Entities.Recorrido", "Recorrido")
                        .WithMany()
                        .HasForeignKey("RecorridoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recorrido");
                });

            modelBuilder.Entity("EmpresaTuristica.Shared.Entities.SitioTuristico", b =>
                {
                    b.HasOne("EmpresaTuristica.Shared.Entities.Actividad", "Actividad")
                        .WithMany()
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmpresaTuristica.Shared.Entities.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actividad");

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("EmpresaTuristica.Shared.Entities.SitiosRecorrido", b =>
                {
                    b.HasOne("EmpresaTuristica.Shared.Entities.Recorrido", "Recorrido")
                        .WithMany("SitiosRecorridos")
                        .HasForeignKey("RecorridoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmpresaTuristica.Shared.Entities.SitioTuristico", "SitioTuristico")
                        .WithMany("SitiosRecorridos")
                        .HasForeignKey("SitioTuristicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recorrido");

                    b.Navigation("SitioTuristico");
                });

            modelBuilder.Entity("EmpresaTuristica.Shared.Entities.Recorrido", b =>
                {
                    b.Navigation("SitiosRecorridos");
                });

            modelBuilder.Entity("EmpresaTuristica.Shared.Entities.SitioTuristico", b =>
                {
                    b.Navigation("SitiosRecorridos");
                });
#pragma warning restore 612, 618
        }
    }
}
