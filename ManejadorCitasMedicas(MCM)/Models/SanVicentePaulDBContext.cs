using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class SanVicentePaulDBContext : DbContext
    {


        public SanVicentePaulDBContext(DbContextOptions<SanVicentePaulDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Citas { get; set; } = null!;
        public virtual DbSet<Ciudad> Ciudades { get; set; } = null!;
        public virtual DbSet<DistritoMunicipal> DistritoMunicipals { get; set; } = null!;
        public virtual DbSet<Especialidade> Especialidades { get; set; } = null!;
        public virtual DbSet<Expediente> Expedientes { get; set; } = null!;
        public virtual DbSet<Medico> Medicos { get; set; } = null!;
        public virtual DbSet<Provincia> Provincias { get; set; } = null!;
        public virtual DbSet<Sectore> Sectores { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SanVicentePaulDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.Property(e => e.CitaId).ValueGeneratedNever();

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

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ciudad");

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdOrigen).HasColumnName("Id_origen");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<DistritoMunicipal>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DistritoMunicipal");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdCuidadOrigen).HasColumnName("id_cuidadOrigen");

                entity.Property(e => e.IdOrigen).HasColumnName("id_origen");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.EspecialidadId);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Expediente>(entity =>
            {
                entity.HasKey(e => e.PacienteId)
                    .HasName("PK_Pacientes");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1)/(1))/(1999))");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1)/(1))/(1999))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nota)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumeroExpendiente)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0000-000000')");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.Property(e => e.MedicoId).ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Codigo).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

            modelBuilder.Entity<Sectore>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Ciudad).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("codigo_postal");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdCiudadOrigen).HasColumnName("id_ciudadOrigen");

                entity.Property(e => e.IdOrigen).HasColumnName("id_origen");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
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
