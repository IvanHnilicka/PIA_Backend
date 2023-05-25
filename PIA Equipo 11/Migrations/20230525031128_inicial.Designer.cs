﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PIA_Equipo_11;

#nullable disable

namespace PIA_Equipo_11.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230525031128_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PIA_Equipo_11.Entidades.Codigo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoPromocional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Descuento")
                        .HasColumnType("real");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<bool>("Valido")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Codigos");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.ComentariosUsuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId", "EventoId");

                    b.HasIndex("EventoId");

                    b.ToTable("ComentariosUsuarios");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.EventosFavoritos", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "EventoId");

                    b.HasIndex("EventoId");

                    b.ToTable("EventosFavoritos");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.RegistroEventos", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<bool>("Asistencia")
                        .HasColumnType("bit");

                    b.Property<float>("Costo")
                        .HasColumnType("real");

                    b.Property<bool>("Pagado")
                        .HasColumnType("bit");

                    b.HasKey("UsuarioId", "EventoId");

                    b.HasIndex("EventoId");

                    b.ToTable("RegistroEventos");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.Codigo", b =>
                {
                    b.HasOne("PIA_Equipo_11.Entidades.Evento", "Evento")
                        .WithMany("Codigo")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.ComentariosUsuario", b =>
                {
                    b.HasOne("PIA_Equipo_11.Entidades.Evento", "Evento")
                        .WithMany("ComentariosUsuario")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PIA_Equipo_11.Entidades.Usuario", "Usuario")
                        .WithMany("ComentariosUsuario")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.Evento", b =>
                {
                    b.HasOne("PIA_Equipo_11.Entidades.Usuario", "Organizador")
                        .WithMany("EventosCreados")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizador");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.EventosFavoritos", b =>
                {
                    b.HasOne("PIA_Equipo_11.Entidades.Evento", "Evento")
                        .WithMany("EventosFavoritos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PIA_Equipo_11.Entidades.Usuario", "Usuario")
                        .WithMany("EventosFavoritos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.RegistroEventos", b =>
                {
                    b.HasOne("PIA_Equipo_11.Entidades.Evento", "Evento")
                        .WithMany("RegistroEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PIA_Equipo_11.Entidades.Usuario", "Usuario")
                        .WithMany("RegistroEventos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.Evento", b =>
                {
                    b.Navigation("Codigo");

                    b.Navigation("ComentariosUsuario");

                    b.Navigation("EventosFavoritos");

                    b.Navigation("RegistroEventos");
                });

            modelBuilder.Entity("PIA_Equipo_11.Entidades.Usuario", b =>
                {
                    b.Navigation("ComentariosUsuario");

                    b.Navigation("EventosCreados");

                    b.Navigation("EventosFavoritos");

                    b.Navigation("RegistroEventos");
                });
#pragma warning restore 612, 618
        }
    }
}
