using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Escuela.Models;

public partial class EscuelaContext : DbContext
{
    public EscuelaContext()
    {
    }

    public EscuelaContext(DbContextOptions<EscuelaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Maestro> Maestros { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("server=localhost; database=Escuela; integrated security=true; Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__Alumnos__460B4740E2E3B54F");

            entity.HasIndex(e => e.NumControl, "UQ__Alumnos__8699667FF5D5C4E7").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreMateria1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreMateria2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreMateria3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreMateria4)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreMateria5)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumControl)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.PromedioGrals).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.NombreMateria1Navigation).WithMany(p => p.AlumnoNombreMateria1Navigations)
                .HasPrincipalKey(p => p.NombreMateria)
                .HasForeignKey(d => d.NombreMateria1)
                .HasConstraintName("FK_Materia1_Alumno");

            entity.HasOne(d => d.NombreMateria2Navigation).WithMany(p => p.AlumnoNombreMateria2Navigations)
                .HasPrincipalKey(p => p.NombreMateria)
                .HasForeignKey(d => d.NombreMateria2)
                .HasConstraintName("FK_Materia2_Alumno");

            entity.HasOne(d => d.NombreMateria3Navigation).WithMany(p => p.AlumnoNombreMateria3Navigations)
                .HasPrincipalKey(p => p.NombreMateria)
                .HasForeignKey(d => d.NombreMateria3)
                .HasConstraintName("FK_Materia3_Alumno");

            entity.HasOne(d => d.NombreMateria4Navigation).WithMany(p => p.AlumnoNombreMateria4Navigations)
                .HasPrincipalKey(p => p.NombreMateria)
                .HasForeignKey(d => d.NombreMateria4)
                .HasConstraintName("FK_Materia4_Alumno");

            entity.HasOne(d => d.NombreMateria5Navigation).WithMany(p => p.AlumnoNombreMateria5Navigations)
                .HasPrincipalKey(p => p.NombreMateria)
                .HasForeignKey(d => d.NombreMateria5)
                .HasConstraintName("FK_Materia5_Alumno");
        });

        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.IdCalificacion).HasName("PK__Califica__40E4A751C272E5D0");

            entity.Property(e => e.CaliFinal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NombreMateria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumControl)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Unidad1).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Unidad2).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Unidad3).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.NombreMateriaNavigation).WithMany(p => p.Calificaciones)
                .HasPrincipalKey(p => p.NombreMateria)
                .HasForeignKey(d => d.NombreMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_materias_calificaciones");

            entity.HasOne(d => d.NumControlNavigation).WithMany(p => p.Calificaciones)
                .HasPrincipalKey(p => p.NumControl)
                .HasForeignKey(d => d.NumControl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_alumnos_calificaciones");
        });

        modelBuilder.Entity<Maestro>(entity =>
        {
            entity.HasKey(e => e.IdMaestro).HasName("PK__Maestros__66B8F1897B805BFB");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreMateria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumTelefono)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.NombreMateriaNavigation).WithMany(p => p.Maestros)
                .HasPrincipalKey(p => p.NombreMateria)
                .HasForeignKey(d => d.NombreMateria)
                .HasConstraintName("FK_Materia_Maestro");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.IdMateria).HasName("PK__Materias__EC174670523DB2F7");

            entity.HasIndex(e => e.NombreMateria, "UQ__Materias__5A6D7C03D231DE54").IsUnique();

            entity.Property(e => e.NombreMateria)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
