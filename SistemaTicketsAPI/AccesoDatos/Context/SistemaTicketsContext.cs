using System;
using System.Collections.Generic;
using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Context;

public partial class SistemaTicketsContext : DbContext
{
    public SistemaTicketsContext()
    {
    }

    public SistemaTicketsContext(DbContextOptions<SistemaTicketsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FormularioHardware> FormularioHardwares { get; set; }

    public virtual DbSet<FormularioSoftware> FormularioSoftwares { get; set; }

    public virtual DbSet<Operador> Operadors { get; set; }

    public virtual DbSet<Solicitante> Solicitantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LN1HKSS;Database=SistemaTickets;Trust Server Certificate=true;User Id=sa;Password=hola;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FormularioHardware>(entity =>
        {
            entity.HasKey(e => e.IdFormularioHardware).HasName("PK__formular__976C6A833E911E54");

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
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaPost)
                .HasColumnType("date")
                .HasColumnName("fecha_post");
            entity.Property(e => e.FechaPre)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_pre");
            entity.Property(e => e.IdOperador).HasColumnName("id_operador");
            entity.Property(e => e.IdSolicitante).HasColumnName("id_solicitante");
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
                .HasConstraintName("FK__formulari__id_op__4222D4EF");

            entity.HasOne(d => d.IdSolicitanteNavigation).WithMany(p => p.FormularioHardwares)
                .HasForeignKey(d => d.IdSolicitante)
                .HasConstraintName("FK__formulari__id_so__412EB0B6");
        });

        modelBuilder.Entity<FormularioSoftware>(entity =>
        {
            entity.HasKey(e => e.IdFormularioSoftware).HasName("PK__formular__DE3810E58EE0C674");

            entity.ToTable("formulario_software");

            entity.Property(e => e.IdFormularioSoftware).HasColumnName("id_formulario_software");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaPost)
                .HasColumnType("date")
                .HasColumnName("fecha_post");
            entity.Property(e => e.FechaPre)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_pre");
            entity.Property(e => e.IdOperador).HasColumnName("id_operador");
            entity.Property(e => e.IdSolicitante).HasColumnName("id_solicitante");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen");

            entity.HasOne(d => d.IdOperadorNavigation).WithMany(p => p.FormularioSoftwares)
                .HasForeignKey(d => d.IdOperador)
                .HasConstraintName("FK__formulari__id_op__3D5E1FD2");

            entity.HasOne(d => d.IdSolicitanteNavigation).WithMany(p => p.FormularioSoftwares)
                .HasForeignKey(d => d.IdSolicitante)
                .HasConstraintName("FK__formulari__id_so__3C69FB99");
        });

        modelBuilder.Entity<Operador>(entity =>
        {
            entity.HasKey(e => e.IdOperador).HasName("PK__Operador__F46AAEF2859B85BE");

            entity.ToTable("Operador");

            entity.Property(e => e.IdOperador).HasColumnName("id_operador");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<Solicitante>(entity =>
        {
            entity.HasKey(e => e.IdSolicitante).HasName("PK__solicita__C8D3AB5C71141057");

            entity.ToTable("solicitante");

            entity.Property(e => e.IdSolicitante).HasColumnName("id_solicitante");
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("area");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.NombreSolicitante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_solicitante");
            entity.Property(e => e.TipoFallo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_fallo");
            entity.Property(e => e.TipoSolicitante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_solicitante");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
