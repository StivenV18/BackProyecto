using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CESDE.MatriculasProyecto.Infrastructure.Models
{
    public partial class DBCESDEV3Context : DbContext
    {
        public DBCESDEV3Context()
        {
        }

        public DBCESDEV3Context(DbContextOptions<DBCESDEV3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Docente> Docentes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;DataBase=DBCESDEV3;Integrated Security=True;TrustServerCertificate=true; Trusted_Connection= True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Docente>(entity =>
            {
                entity.ToTable("docente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApellidoDocente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido_docente");

                entity.Property(e => e.CiudadResidenciaDocente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ciudad_residencia_docente");

                entity.Property(e => e.CorreoElectronicoDocente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo_electronico_docente");

                entity.Property(e => e.EscalafonExtensionDocente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("escalafon_extension_docente");

                entity.Property(e => e.EscalafonTecnicoDocente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("escalafon_tecnico_docente");

                entity.Property(e => e.IdentificacionDocente).HasColumnName("identificacion_docente");

                entity.Property(e => e.NombreDocente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_docente");

                entity.Property(e => e.NumeroContratoDocente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_contrato_docente");

                entity.Property(e => e.TelefonoCelularDocente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono_celular_docente");

                entity.Property(e => e.TipoIdentificacionDocente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_identificacion_docente");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Usuario1);

                entity.ToTable("Usuario");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
