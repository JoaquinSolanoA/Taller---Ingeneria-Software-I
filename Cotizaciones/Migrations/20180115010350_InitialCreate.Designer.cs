﻿// <auto-generated />
using Cotizaciones.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Cotizaciones.Migrations
{
    [DbContext(typeof(CotizacionesContext))]
    [Migration("20180115010350_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Cotizaciones.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Correo");

                    b.Property<string>("Direccion");

                    b.Property<string>("Materno");

                    b.Property<string>("Nombre");

                    b.Property<string>("Paterno");

                    b.Property<string>("Rut");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Cotizaciones.Models.Cotizacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("FechaEmision");

                    b.Property<DateTime>("FechaVencimiento");

                    b.Property<double>("Impuesto");

                    b.Property<int>("NReferencia");

                    b.Property<double>("TotalNeto");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cotizaciones");
                });

            modelBuilder.Entity("Cotizaciones.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cantidad");

                    b.Property<int?>("CotizacionId");

                    b.Property<string>("Descripcion");

                    b.Property<double>("TotalValor");

                    b.Property<double>("ValorUnitario");

                    b.HasKey("Id");

                    b.HasIndex("CotizacionId");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Cotizaciones.Models.Cotizacion", b =>
                {
                    b.HasOne("Cotizaciones.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cotizaciones.Models.Servicio", b =>
                {
                    b.HasOne("Cotizaciones.Models.Cotizacion")
                        .WithMany("Servicios")
                        .HasForeignKey("CotizacionId");
                });
#pragma warning restore 612, 618
        }
    }
}
