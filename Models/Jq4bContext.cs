using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

public partial class Jq4bContext : DbContext
{
    public Jq4bContext()
    {
    }

    public Jq4bContext(DbContextOptions<Jq4bContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detalleventa> Detalleventas { get; set; }

    public virtual DbSet<Encargadotiendum> Encargadotienda { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Productostiendum> Productostienda { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tienda> Tiendas { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;user=root;password=12345;database=jq4b;port=3306");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Categoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Usuario, "Usuario").IsUnique();

            entity.Property(e => e.Apemat).HasMaxLength(100);
            entity.Property(e => e.Apepat).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(15);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Pwd).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.Usuario).HasMaxLength(50);
        });

        modelBuilder.Entity<Detalleventa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detalleventas");

            entity.HasIndex(e => e.IdProducto, "fk_dv_p");

            entity.HasIndex(e => e.IdVenta, "fk_dv_v");

            entity.Property(e => e.Cantidad).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dv_p");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dv_v");
        });

        modelBuilder.Entity<Encargadotiendum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("encargadotienda");

            entity.HasIndex(e => e.Usuario, "Usuario").IsUnique();

            entity.HasIndex(e => e.IdRol, "fk_encargado_rol");

            entity.Property(e => e.Apemat).HasMaxLength(100);
            entity.Property(e => e.Apepat).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(15);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Pwd).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.Usuario).HasMaxLength(50);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Encargadotienda)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_encargado_rol");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.IdCategoria, "fk_productos_categorias");

            entity.Property(e => e.Imagen).HasMaxLength(255);
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Producto");
            entity.Property(e => e.Precio).HasPrecision(10);
            entity.Property(e => e.Stock).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_productos_categorias");
        });

        modelBuilder.Entity<Productostiendum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productostienda");

            entity.HasIndex(e => e.IdProducto, "fk_pt_prod");

            entity.HasIndex(e => e.IdTienda, "fk_pt_tienda");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Productostienda)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pt_prod");

            entity.HasOne(d => d.IdTiendaNavigation).WithMany(p => p.Productostienda)
                .HasForeignKey(d => d.IdTienda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pt_tienda");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Rol, "Rol").IsUnique();

            entity.Property(e => e.Rol).HasMaxLength(100);
        });

        modelBuilder.Entity<Tienda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tiendas");

            entity.HasIndex(e => e.IdEncargado, "fk_tiendas_encargados");

            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.NombreTienda)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Tienda");
            entity.Property(e => e.Telefono).HasMaxLength(15);

            entity.HasOne(d => d.IdEncargadoNavigation).WithMany(p => p.Tienda)
                .HasForeignKey(d => d.IdEncargado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tiendas_encargados");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ventas");

            entity.HasIndex(e => e.IdCliente, "fk_ventas_cliente");

            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Hora).HasColumnType("time");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ventas_cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
