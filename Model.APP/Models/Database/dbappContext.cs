using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Model.APP.Models.Database
{
    public partial class dbappContext : DbContext
    {
        public dbappContext()
        {
        }

        public dbappContext(DbContextOptions<dbappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Direccione> Direcciones { get; set; }
        public virtual DbSet<Registrado> Registrados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("User= sa; Password= Ctek2314;Persist Security Info=False;Initial Catalog=dbapp;Data Source=(local)\\A19");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AI");

            modelBuilder.Entity<Direccione>(entity =>
            {
                entity.HasKey(e => e.IdDirecciones)
                    .HasName("PK__Direccio__71EDDA8C39595900");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Registrado>(entity =>
            {
                entity.HasKey(e => e.IdRegistrado)
                    .HasName("PK__Registra__0601106F6AA486EF");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombresCompletos)
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
