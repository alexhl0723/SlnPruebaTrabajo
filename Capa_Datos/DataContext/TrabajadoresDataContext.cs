﻿using System;
using System.Collections.Generic;
using Capa_Models;
using Capa_Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Capa_Datos.DataContext;

public partial class TrabajadoresDataContext : DbContext
{
    public TrabajadoresDataContext()
    {
    }

    public TrabajadoresDataContext(DbContextOptions<TrabajadoresDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Trabajadore> Trabajadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TrabajadorVM>().HasNoKey();


        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departam__3214EC077B1EC99F");

            entity.ToTable("Departamento");

            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Distrito__3214EC076ADE8713");

            entity.ToTable("Distrito");

            entity.Property(e => e.NombreDistrito)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Distritos)
                .HasForeignKey(d => d.IdProvincia)
                .HasConstraintName("FK__Distrito__IdProv__3D5E1FD2");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provinci__3214EC072162BFCF");

            entity.Property(e => e.NombreProvincia)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK__Provincia__IdDep__3E52440B");
        });

        modelBuilder.Entity<Trabajadore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trabajad__3214EC0774A700A6");

            entity.Property(e => e.Nombres)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Trabajadores)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK__Trabajado__IdDep__3F466844");

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Trabajadores)
                .HasForeignKey(d => d.IdDistrito)
                .HasConstraintName("FK__Trabajado__IdDis__403A8C7D");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Trabajadores)
                .HasForeignKey(d => d.IdProvincia)
                .HasConstraintName("FK__Trabajado__IdPro__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
