using System;
using System.Collections.Generic;
using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Context;

public partial class SistemaTicketsVersionDosContext : DbContext
{
    public SistemaTicketsVersionDosContext()
    {
    }

    public SistemaTicketsVersionDosContext(DbContextOptions<SistemaTicketsVersionDosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FormularioHardware> FormularioHardwares { get; set; }

    public virtual DbSet<FormularioSoftware> FormularioSoftwares { get; set; }

    public virtual DbSet<Operador> Operadors { get; set; }

    public virtual DbSet<SolicitanteHard> SolicitanteHards { get; set; }

    public virtual DbSet<SolicitanteSoft> SolicitanteSofts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LN1HKSS;Database=SistemaTicketsVersionDos;Trust Server Certificate=true;User Id=sa;Password=hola;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FormularioHardware>(entity =>
        {
            entity.HasKey(e => e.IdFormularioHardware).HasName("PK__formular__976C6A83E4D3DEF8");

            entity.ToTable("formulario_hardware");

            entity.Property(e => e.IdFormularioHardware).HasColumnName("id_formulario_hardware");
            entity.Property(e => e.Cantidad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cantidad");
            entity.Property(e => e.Condicion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("condicion");
            entity.Property(e => e.DescripcionHard)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion_hard");
            entity.Property(e => e.EstatusHard).HasColumnName("estatus_hard");
            entity.Property(e => e.FechaPostHard)
                .HasColumnType("date")
                .HasColumnName("fecha_post_hard");
            entity.Property(e => e.FechaPreHard)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_pre_hard");
            entity.Property(e => e.IdOperador).HasColumnName("id_operador");
            entity.Property(e => e.IdSolicitanteHard).HasColumnName("id_solicitanteHard");
            entity.Property(e => e.Marca)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.NoSerie)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("no_serie");
            entity.Property(e => e.ObservacionPost)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("observacion_post");
            entity.Property(e => e.ObservacionPre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("observacion_pre");

            entity.HasOne(d => d.IdOperadorNavigation).WithMany(p => p.FormularioHardwares)
                .HasForeignKey(d => d.IdOperador)
                .HasConstraintName("FK__formulari__id_op__00200768");

            entity.HasOne(d => d.IdSolicitanteHardNavigation).WithMany(p => p.FormularioHardwares)
                .HasForeignKey(d => d.IdSolicitanteHard)
                .HasConstraintName("FK__formulari__id_so__7F2BE32F");
        });

        modelBuilder.Entity<FormularioSoftware>(entity =>
        {
            entity.HasKey(e => e.IdFormularioSoftware).HasName("PK__formular__DE3810E55772AD56");

            entity.ToTable("formulario_software");

            entity.Property(e => e.IdFormularioSoftware).HasColumnName("id_formulario_software");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estatus).HasColumnName("estatus");
            entity.Property(e => e.FechaPost)
                .HasColumnType("date")
                .HasColumnName("fecha_post");
            entity.Property(e => e.FechaPre)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_pre");
            entity.Property(e => e.IdOperador).HasColumnName("id_operador");
            entity.Property(e => e.IdSolicitanteSoft).HasColumnName("id_solicitanteSoft");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(255)
                .HasColumnName("nombre_archivo");

            entity.HasOne(d => d.IdOperadorNavigation).WithMany(p => p.FormularioSoftwares)
                .HasForeignKey(d => d.IdOperador)
                .HasConstraintName("FK__formulari__id_op__7B5B524B");

            entity.HasOne(d => d.IdSolicitanteSoftNavigation).WithMany(p => p.FormularioSoftwares)
                .HasForeignKey(d => d.IdSolicitanteSoft)
                .HasConstraintName("FK__formulari__id_so__7A672E12");
        });

        modelBuilder.Entity<Operador>(entity =>
        {
            entity.HasKey(e => e.IdOperador).HasName("PK__Operador__F46AAEF2E71C07E0");

            entity.ToTable("Operador");

            entity.Property(e => e.IdOperador).HasColumnName("id_operador");
            entity.Property(e => e.Cargo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<SolicitanteHard>(entity =>
        {
            entity.HasKey(e => e.IdSolicitanteHard).HasName("PK__solicita__90A9FD64D670CA8F");

            entity.ToTable("solicitanteHard");

            entity.Property(e => e.IdSolicitanteHard).HasColumnName("id_solicitanteHard");
            entity.Property(e => e.AreaHard)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("area_hard");
            entity.Property(e => e.CorreoHard)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo_hard");
            entity.Property(e => e.NombreSolicitanteHard)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_solicitante_hard");
            entity.Property(e => e.TipoFalloHard)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo_fallo_hard");
            entity.Property(e => e.TipoSolicitanteHard)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo_solicitante_hard");
        });

        modelBuilder.Entity<SolicitanteSoft>(entity =>
        {
            entity.HasKey(e => e.IdSolicitanteSoft).HasName("PK__solicita__D3D80FF3718554D6");

            entity.ToTable("solicitanteSoft");

            entity.Property(e => e.IdSolicitanteSoft).HasColumnName("id_solicitanteSoft");
            entity.Property(e => e.AreaSoft)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("area_soft");
            entity.Property(e => e.CorreoSoft)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo_soft");
            entity.Property(e => e.NombreSolicitanteSoft)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_solicitante_soft");
            entity.Property(e => e.TipoFalloSoft)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo_fallo_soft");
            entity.Property(e => e.TipoSolicitanteSoft)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo_solicitante_soft");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
