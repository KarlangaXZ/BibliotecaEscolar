namespace BibliotecaEscolar.Models;

public class Libro
{
    public int IdLibro { get; private set; }
    public string Titulo { get; private set; } = string.Empty;
    public string Autor { get; private set; } = string.Empty;
    public string ISBN { get; private set; } = string.Empty;
    public int AnioPublicacion { get; private set; }
    public bool Disponible { get; private set; }
    public int IdCategoria { get; private set; }
    public Categoria Categoria { get; private set; } = null!;
    public ICollection<Prestamo> Prestamos { get; private set; }

    private Libro()
    {
        Titulo = string.Empty;
        Autor = string.Empty;
        ISBN = string.Empty;
        Categoria = null!;
        Prestamos = new List<Prestamo>();
    }

    public Libro(int idLibro, string titulo, string autor, string isbn, int anioPublicacion, bool disponible, Categoria categoria)
    {
        IdLibro = idLibro;
        Prestamos = new List<Prestamo>();
        ActualizarDatos(titulo, autor, isbn, anioPublicacion, disponible, categoria);
    }

    public void ActualizarDatos(string titulo, string autor, string isbn, int anioPublicacion,
        bool disponible, Categoria categoria)
    {
        if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentException("El título es obligatorio.", nameof(titulo));
        if (string.IsNullOrWhiteSpace(autor)) throw new ArgumentException("El autor es obligatorio.", nameof(autor));
        if (string.IsNullOrWhiteSpace(isbn)) throw new ArgumentException("El ISBN es obligatorio.", nameof(isbn));
        ArgumentNullException.ThrowIfNull(categoria);
        if (anioPublicacion <= 0) throw new ArgumentException("El año de publicación debe ser válido.", nameof(anioPublicacion));

        Titulo = titulo.Trim();
        Autor = autor.Trim();
        ISBN = isbn.Trim();
        AnioPublicacion = anioPublicacion;
        Disponible = disponible;
        Categoria = categoria;
        IdCategoria = categoria.IdCategoria;
    }

    public void CambiarDisponibilidad(bool disponible)
    {
        Disponible = disponible;
    }
}
