
using CESDE.MatriculasProyecto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CESDE.MatriculasProyecto.Infrastructure.Persistence.Configurations
{
    internal class DocenteConfiguration : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> builder)
        {
            builder.ToTable("docente");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.ApellidoDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_docente");

            builder.Property(e => e.CiudadResidenciaDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudad_residencia_docente");

            builder.Property(e => e.CorreoElectronicoDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_electronico_docente");

            builder.Property(e => e.EscalafonExtensionDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("escalafon_extension_docente");

            builder.Property(e => e.EscalafonTecnicoDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("escalafon_tecnico_docente");

            builder.Property(e => e.IdentificacionDocente).HasColumnName("identificacion_docente");

            builder.Property(e => e.NombreDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_docente");

            builder.Property(e => e.NumeroContratoDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_contrato_docente");

            builder.Property(e => e.TelefonoCelularDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono_celular_docente");

            builder.Property(e => e.TipoIdentificacionDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_identificacion_docente");
        }
     }

  }

