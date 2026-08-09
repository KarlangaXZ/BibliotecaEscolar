namespace BibliotecaEscolar.Models;

public class Prestamo
{
    public int IdPrestamo { get; private set; }
    public int IdUsuario { get; private set; }
    public Usuario Usuario { get; private set; }
    public int IdBibliotecario { get; private set; }
    public Bibliotecario Bibliotecario { get; private set; }
    public int IdLibro { get; private set; }
    public Libro Libro { get; private set; }
    public DateTime FechaPrestamo { get; private set; }
    public DateTime? FechaDevolucion { get; private set; }
    public bool Devuelto { get; private set; }

    private Prestamo()
    {
        Usuario = null!;
        Bibliotecario = null!;
        Libro = null!;
    }

    public Prestamo(int idPrestamo, Usuario usuario, Bibliotecario bibliotecario, Libro libro,
        DateTime fechaPrestamo, DateTime? fechaDevolucion, bool devuelto)
    {
        IdPrestamo = idPrestamo;
        Usuario = usuario;
        IdUsuario = usuario.IdUsuario;
        Bibliotecario = bibliotecario;
        IdBibliotecario = bibliotecario.IdBibliotecario;
        Libro = libro;
        IdLibro = libro.IdLibro;
        FechaPrestamo = fechaPrestamo;
        FechaDevolucion = fechaDevolucion;
        Devuelto = devuelto;
    }

    public void RegistrarDevolucion(DateTime fechaDevolucion)
    {
        if (Devuelto) throw new InvalidOperationException("El préstamo ya fue devuelto.");
        if (fechaDevolucion < FechaPrestamo) throw new ArgumentException("La fecha de devolución no puede ser anterior al préstamo.");
        FechaDevolucion = fechaDevolucion;
        Devuelto = true;
    }
}
