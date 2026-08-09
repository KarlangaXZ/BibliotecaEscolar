using BibliotecaEscolar.Data;
using BibliotecaEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaEscolar.Services;

public class LibroService
{
    private readonly BibliotecaDbContext _context;
    public LibroService(BibliotecaDbContext context) => _context = context;
    public Task<List<Libro>> ListarAsync() => _context.Libros.AsNoTracking().Include(x => x.Categoria).OrderBy(x => x.Titulo).ToListAsync();
    public Task<Libro?> BuscarPorIdAsync(int id) => _context.Libros.AsNoTracking().Include(x => x.Categoria).FirstOrDefaultAsync(x => x.IdLibro == id);

    public async Task<Libro> CrearAsync(string titulo, string autor, string isbn, int anio, bool disponible, int idCategoria)
    {
        (titulo, autor, isbn) = Validar(titulo, autor, isbn, anio);
        if (await ExisteIsbnAsync(isbn)) throw new InvalidOperationException($"Ya existe un libro con el ISBN '{isbn}'.");
        var categoria = await _context.Categorias.FindAsync(idCategoria) ?? throw new ArgumentException("La categoría seleccionada no existe.");
        var libro = new Libro(0, titulo, autor, isbn, anio, disponible, categoria);
        _context.Add(libro); await _context.SaveChangesAsync(); return libro;
    }
    public async Task<Libro> ModificarAsync(int id, string titulo, string autor, string isbn, int anio, bool disponible, int idCategoria)
    {
        (titulo, autor, isbn) = Validar(titulo, autor, isbn, anio);
        var libro = await _context.Libros.FindAsync(id) ?? throw new KeyNotFoundException($"No se encontró el libro con Id {id}.");
        if (await ExisteIsbnAsync(isbn, id)) throw new InvalidOperationException($"Ya existe otro libro con el ISBN '{isbn}'.");
        var categoria = await _context.Categorias.FindAsync(idCategoria) ?? throw new ArgumentException("La categoría seleccionada no existe.");
        libro.ActualizarDatos(titulo, autor, isbn, anio, disponible, categoria); await _context.SaveChangesAsync(); return libro;
    }
    public async Task<string> EliminarAsync(int id)
    {
        var libro = await _context.Libros.FindAsync(id) ?? throw new KeyNotFoundException($"No se encontró el libro con Id {id}.");
        if (await _context.Prestamos.AnyAsync(x => x.IdLibro == id)) throw new InvalidOperationException("No se puede eliminar el libro porque tiene préstamos asociados.");
        _context.Remove(libro); await _context.SaveChangesAsync(); return "Libro eliminado correctamente.";
    }
    private Task<bool> ExisteIsbnAsync(string isbn, int? excluir = null)
    { string valor = isbn.ToUpperInvariant(); return _context.Libros.AnyAsync(x => x.ISBN.ToUpper() == valor && (!excluir.HasValue || x.IdLibro != excluir)); }
    private static (string, string, string) Validar(string titulo, string autor, string isbn, int anio)
    {
        if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentException("El título es obligatorio.");
        if (string.IsNullOrWhiteSpace(autor)) throw new ArgumentException("El autor es obligatorio.");
        if (string.IsNullOrWhiteSpace(isbn)) throw new ArgumentException("El ISBN es obligatorio.");
        if (anio <= 0) throw new ArgumentException("El año de publicación debe ser válido.");
        return (titulo.Trim(), autor.Trim(), isbn.Trim());
    }
}
