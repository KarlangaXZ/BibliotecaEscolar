namespace BibliotecaEscolar.Models;

public class Categoria
{
    public int IdCategoria { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public ICollection<Libro> Libros { get; private set; }

    private Categoria()
    {
        Nombre = string.Empty;
        Descripcion = string.Empty;
        Libros = new List<Libro>();
    }

    public Categoria(int idCategoria, string nombre, string? descripcion)
    {
        IdCategoria = idCategoria;
        Libros = new List<Libro>();
        ActualizarDatos(nombre, descripcion);
    }

    public void ActualizarDatos(string nombre, string? descripcion)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre de la categoría es obligatorio.", nameof(nombre));
        }

        Nombre = nombre.Trim();
        Descripcion = string.IsNullOrWhiteSpace(descripcion)
            ? "Sin descripción"
            : descripcion.Trim();
    }
}
