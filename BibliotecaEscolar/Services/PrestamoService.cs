using BibliotecaEscolar.Data;
using BibliotecaEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaEscolar.Services;

public class PrestamoService
{
    private readonly BibliotecaDbContext _context;
    public PrestamoService(BibliotecaDbContext context) => _context = context;
    public Task<List<Prestamo>> ListarAsync() => _context.Prestamos.AsNoTracking()
        .Include(x => x.Usuario).Include(x => x.Libro).Include(x => x.Bibliotecario)
        .OrderByDescending(x => x.FechaPrestamo).ToListAsync();
    public async Task<Prestamo> CrearAsync(int idUsuario, int idLibro, int idBibliotecario, DateTime fecha)
    {
        var usuario = await _context.Usuarios.FindAsync(idUsuario) ?? throw new ArgumentException("El usuario seleccionado no existe.");
        var libro = await _context.Libros.FindAsync(idLibro) ?? throw new ArgumentException("El libro seleccionado no existe.");
        var bibliotecario = await _context.Bibliotecarios.FindAsync(idBibliotecario) ?? throw new ArgumentException("El bibliotecario seleccionado no existe.");
        if (!libro.Disponible) throw new InvalidOperationException("El libro seleccionado no está disponible.");
        var prestamo = new Prestamo(0, usuario, bibliotecario, libro, fecha, null, false);
        libro.CambiarDisponibilidad(false); _context.Add(prestamo); await _context.SaveChangesAsync(); return prestamo;
    }
    public async Task<string> RegistrarDevolucionAsync(int id, DateTime fecha)
    {
        var prestamo = await _context.Prestamos.Include(x => x.Libro).FirstOrDefaultAsync(x => x.IdPrestamo == id)
            ?? throw new KeyNotFoundException($"No se encontró el préstamo con Id {id}.");
        prestamo.RegistrarDevolucion(fecha); prestamo.Libro.CambiarDisponibilidad(true); await _context.SaveChangesAsync();
        return "Devolución registrada correctamente.";
    }
}
