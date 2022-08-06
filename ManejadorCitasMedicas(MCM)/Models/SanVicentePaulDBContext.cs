using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class SanVicentePaulDBContext : DbContext
    {
        public SanVicentePaulDBContext()
        {
        }

        public SanVicentePaulDBContext(DbContextOptions<SanVicentePaulDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citas> Citas { get; set; } = null!;
        public virtual DbSet<Ciudades> Ciudades { get; set; } = null!;
        public virtual DbSet<DistritosMunicipales> DistritosMunicipales { get; set; } = null!;
        public virtual DbSet<Especialidades> Especialidades { get; set; } = null!;
        public virtual DbSet<Pacientes> Pacientes { get; set; } = null!;
        public virtual DbSet<Medicos> Medicos { get; set; } = null!;
        public virtual DbSet<Provincias> Provincias { get; set; } = null!;
        public virtual DbSet<Sectores> Sectores { get; set; } = null!;
        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-VMMK09U9\\SQLEXPRESS; Initial Catalog=SanVicentePaulDB; Persist security info=true; user ID=johan; Password=732398");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas>(entity =>
            {
                entity.HasKey(e => e.CitaId);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Cita')");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1999)-(1))-(1))");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1999)-(1))-(1))");

                entity.Property(e => e.Inicia)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1999)-(1))-(1))");

                entity.Property(e => e.Termina)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1999)-(1))-(1))");
            });

            modelBuilder.Entity<Ciudades>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CiudadId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DistritosMunicipales>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DistritoId).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Especialidades>(entity =>
            {
                entity.HasKey(e => e.EspecialidadId);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.HasKey(e => e.PacienteId)
                    .HasName("PK_Pacientes");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ApellidoMadre)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ApellidoPadre)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ars)
                    .HasColumnName("ARS")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EstadoCivil).HasDefaultValueSql("((-1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1)/(1))/(1999))");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1)/(1))/(1999))");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasDefaultValueSql("('01-01-1999')");

                entity.Property(e => e.Mail).IsUnicode(false);

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreMadre)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombrePadre)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nota)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nss)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NSS");

                entity.Property(e => e.NumeroExpendiente)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0000-000000')");

                entity.Property(e => e.Plan).HasDefaultValueSql("((-1))");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SegundoApellido)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Medicos>(entity =>
            {

                entity.HasKey(e => e.MedicoId);
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oficio)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Nombre).HasMaxLength(200);

                entity.Property(e => e.ProvinciaId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Sectores>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.SectorId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);
                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1999)-(1))-(1))");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1999)-(1))-(1))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
