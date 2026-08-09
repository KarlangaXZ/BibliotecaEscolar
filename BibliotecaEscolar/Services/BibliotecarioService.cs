using BibliotecaEscolar.Data;
using BibliotecaEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaEscolar.Services;

public class BibliotecarioService
{
    private readonly BibliotecaDbContext _context;
    public BibliotecarioService(BibliotecaDbContext context) => _context = context;

    public Task<List<Bibliotecario>> ListarAsync() => _context.Bibliotecarios.AsNoTracking()
        .OrderBy(x => x.Apellidos).ThenBy(x => x.Nombre).ToListAsync();
    public Task<Bibliotecario?> BuscarPorIdAsync(int id) => _context.Bibliotecarios.AsNoTracking()
        .FirstOrDefaultAsync(x => x.IdBibliotecario == id);

    public async Task<Bibliotecario> CrearAsync(string nombre, string apellidos, string? telefono, string codigo)
    {
        (nombre, apellidos, codigo) = Validar(nombre, apellidos, codigo);
        if (await ExisteCodigoAsync(codigo)) throw new InvalidOperationException($"Ya existe un bibliotecario con el código '{codigo}'.");
        var item = new Bibliotecario(0, nombre, apellidos, telefono ?? string.Empty, codigo);
        _context.Add(item); await _context.SaveChangesAsync(); return item;
    }

    public async Task<Bibliotecario> ModificarAsync(int id, string nombre, string apellidos, string? telefono, string codigo)
    {
        (nombre, apellidos, codigo) = Validar(nombre, apellidos, codigo);
        var item = await _context.Bibliotecarios.FindAsync(id) ?? throw new KeyNotFoundException($"No se encontró el bibliotecario con Id {id}.");
        if (await ExisteCodigoAsync(codigo, id)) throw new InvalidOperationException($"Ya existe otro bibliotecario con el código '{codigo}'.");
        item.ActualizarDatos(nombre, apellidos, telefono, codigo); await _context.SaveChangesAsync(); return item;
    }

    public async Task<string> EliminarAsync(int id)
    {
        var item = await _context.Bibliotecarios.FindAsync(id) ?? throw new KeyNotFoundException($"No se encontró el bibliotecario con Id {id}.");
        if (await _context.Prestamos.AnyAsync(x => x.IdBibliotecario == id)) throw new InvalidOperationException("No se puede eliminar el bibliotecario porque tiene préstamos asociados.");
        _context.Remove(item); await _context.SaveChangesAsync(); return "Bibliotecario eliminado correctamente.";
    }

    private Task<bool> ExisteCodigoAsync(string codigo, int? excluir = null)
    {
        string valor = codigo.ToUpperInvariant();
        return _context.Bibliotecarios.AnyAsync(x => x.CodigoEmpleado.ToUpper() == valor && (!excluir.HasValue || x.IdBibliotecario != excluir));
    }
    private static (string, string, string) Validar(string nombre, string apellidos, string codigo)
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es obligatorio.");
        if (string.IsNullOrWhiteSpace(apellidos)) throw new ArgumentException("Los apellidos son obligatorios.");
        if (string.IsNullOrWhiteSpace(codigo)) throw new ArgumentException("El código de empleado es obligatorio.");
        return (nombre.Trim(), apellidos.Trim(), codigo.Trim());
    }
}
