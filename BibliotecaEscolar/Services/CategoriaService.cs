using BibliotecaEscolar.Data;
using BibliotecaEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaEscolar.Services;

public class CategoriaService
{
    private readonly BibliotecaDbContext _context;

    public CategoriaService(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> ListarAsync()
    {
        return await _context.Categorias
            .AsNoTracking()
            .OrderBy(categoria => categoria.Nombre)
            .ToListAsync();
    }

    public async Task<Categoria?> BuscarPorIdAsync(int idCategoria)
    {
        return await _context.Categorias
            .AsNoTracking()
            .FirstOrDefaultAsync(categoria => categoria.IdCategoria == idCategoria);
    }

    public async Task<Categoria> CrearAsync(string nombre, string? descripcion = null)
    {
        string nombreNormalizado = ValidarYNormalizarNombre(nombre);

        if (await ExisteNombreAsync(nombreNormalizado))
        {
            throw new InvalidOperationException(
                $"Ya existe una categoría con el nombre '{nombreNormalizado}'.");
        }

        var categoria = new Categoria(0, nombreNormalizado, descripcion);
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        return categoria;
    }

    public async Task<Categoria> ModificarAsync(
        int idCategoria,
        string nombre,
        string? descripcion = null)
    {
        string nombreNormalizado = ValidarYNormalizarNombre(nombre);
        Categoria? categoria = await _context.Categorias.FindAsync(idCategoria);

        if (categoria is null)
        {
            throw new KeyNotFoundException(
                $"No se encontró la categoría con Id {idCategoria}.");
        }

        if (await ExisteNombreAsync(nombreNormalizado, idCategoria))
        {
            throw new InvalidOperationException(
                $"Ya existe otra categoría con el nombre '{nombreNormalizado}'.");
        }

        categoria.ActualizarDatos(nombreNormalizado, descripcion);
        await _context.SaveChangesAsync();

        return categoria;
    }

    public async Task<string> EliminarAsync(int idCategoria)
    {
        Categoria? categoria = await _context.Categorias.FindAsync(idCategoria);

        if (categoria is null)
        {
            throw new KeyNotFoundException(
                $"No se encontró la categoría con Id {idCategoria}.");
        }

        bool tieneLibros = await _context.Libros
            .AnyAsync(libro => libro.IdCategoria == idCategoria);

        if (tieneLibros)
        {
            throw new InvalidOperationException(
                "No se puede eliminar la categoría porque tiene libros asociados.");
        }

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();

        return "Categoría eliminada correctamente.";
    }

    private async Task<bool> ExisteNombreAsync(
        string nombre,
        int? idCategoriaExcluida = null)
    {
        string nombreMayusculas = nombre.ToUpperInvariant();

        return await _context.Categorias.AnyAsync(categoria =>
            categoria.Nombre.ToUpper() == nombreMayusculas &&
            (!idCategoriaExcluida.HasValue ||
             categoria.IdCategoria != idCategoriaExcluida.Value));
    }

    private static string ValidarYNormalizarNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException(
                "El nombre de la categoría es obligatorio.", nameof(nombre));
        }

        return nombre.Trim();
    }
}
