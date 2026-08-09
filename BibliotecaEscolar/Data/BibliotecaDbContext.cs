using BibliotecaEscolar.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;

namespace BibliotecaEscolar.Data;

public class BibliotecaDbContext : DbContext
{
    private const string ConnectionString =
        "User Id=BIBLIOTECA;Password=Biblioteca123;Data Source=localhost:1521/XEPDB1;";

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Bibliotecario> Bibliotecarios => Set<Bibliotecario>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Libro> Libros => Set<Libro>();
    public DbSet<Prestamo> Prestamos => Set<Prestamo>();

    public BibliotecaDbContext()
    {
    }

    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseOracle(
                ConnectionString,
                oracleOptions => oracleOptions.UseOracleSQLCompatibility(
                    OracleSQLCompatibility.DatabaseVersion21));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Cada clase derivada se mapea como una entidad raíz para conservar
        // las claves IdUsuario e IdBibliotecario solicitadas.
        modelBuilder.Entity<Usuario>().HasBaseType((Type?)null);
        modelBuilder.Entity<Bibliotecario>().HasBaseType((Type?)null);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("USUARIOS");
            entity.HasKey(usuario => usuario.IdUsuario);
            entity.Property(usuario => usuario.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(usuario => usuario.Nombre).HasMaxLength(100).IsRequired();
            entity.Property(usuario => usuario.Apellidos).HasMaxLength(100).IsRequired();
            entity.Property(usuario => usuario.Telefono).HasMaxLength(30);
            entity.Property(usuario => usuario.Matricula).HasMaxLength(30).IsRequired();
            entity.HasIndex(usuario => usuario.Matricula)
                .IsUnique()
                .HasDatabaseName("UX_USUARIOS_MATRICULA");
        });

        modelBuilder.Entity<Bibliotecario>(entity =>
        {
            entity.ToTable("BIBLIOTECARIOS");
            entity.HasKey(bibliotecario => bibliotecario.IdBibliotecario);
            entity.Property(bibliotecario => bibliotecario.IdBibliotecario).HasColumnName("ID_BIBLIOTECARIO");
            entity.Property(bibliotecario => bibliotecario.Nombre).HasMaxLength(100).IsRequired();
            entity.Property(bibliotecario => bibliotecario.Apellidos).HasMaxLength(100).IsRequired();
            entity.Property(bibliotecario => bibliotecario.Telefono).HasMaxLength(30);
            entity.Property(bibliotecario => bibliotecario.CodigoEmpleado).HasMaxLength(30).IsRequired();
            entity.HasIndex(bibliotecario => bibliotecario.CodigoEmpleado)
                .IsUnique()
                .HasDatabaseName("UX_BIBLIOTECARIOS_CODIGO");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("CATEGORIAS");
            entity.HasKey(categoria => categoria.IdCategoria);
            entity.Property(categoria => categoria.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(categoria => categoria.Nombre).HasMaxLength(100).IsRequired();
            entity.Property(categoria => categoria.Descripcion).HasMaxLength(300);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.ToTable("LIBROS");
            entity.HasKey(libro => libro.IdLibro);
            entity.Property(libro => libro.IdLibro).HasColumnName("ID_LIBRO");
            entity.Property(libro => libro.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(libro => libro.Titulo).HasMaxLength(200).IsRequired();
            entity.Property(libro => libro.Autor).HasMaxLength(150).IsRequired();
            entity.Property(libro => libro.ISBN).HasMaxLength(20).IsRequired();
            entity.HasIndex(libro => libro.ISBN)
                .IsUnique()
                .HasDatabaseName("UX_LIBROS_ISBN");
            entity.HasOne(libro => libro.Categoria)
                .WithMany(categoria => categoria.Libros)
                .HasForeignKey(libro => libro.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.ToTable("PRESTAMOS");
            entity.HasKey(prestamo => prestamo.IdPrestamo);
            entity.Property(prestamo => prestamo.IdPrestamo).HasColumnName("ID_PRESTAMO");
            entity.Property(prestamo => prestamo.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(prestamo => prestamo.IdBibliotecario).HasColumnName("ID_BIBLIOTECARIO");
            entity.Property(prestamo => prestamo.IdLibro).HasColumnName("ID_LIBRO");

            entity.HasOne(prestamo => prestamo.Usuario)
                .WithMany(usuario => usuario.Prestamos)
                .HasForeignKey(prestamo => prestamo.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(prestamo => prestamo.Bibliotecario)
                .WithMany(bibliotecario => bibliotecario.Prestamos)
                .HasForeignKey(prestamo => prestamo.IdBibliotecario)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(prestamo => prestamo.Libro)
                .WithMany(libro => libro.Prestamos)
                .HasForeignKey(prestamo => prestamo.IdLibro)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
