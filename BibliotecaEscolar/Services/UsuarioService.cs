using BibliotecaEscolar.Data;
using BibliotecaEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaEscolar.Services;

public class UsuarioService
{
    private readonly BibliotecaDbContext _context;

    public UsuarioService(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Usuario>> ListarAsync()
    {
        return await _context.Usuarios
            .AsNoTracking()
            .OrderBy(usuario => usuario.Apellidos)
            .ThenBy(usuario => usuario.Nombre)
            .ToListAsync();
    }

    public async Task<Usuario?> BuscarPorIdAsync(int idUsuario)
    {
        return await _context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(usuario => usuario.IdUsuario == idUsuario);
    }

    public async Task<Usuario> CrearAsync(
        string nombre,
        string apellidos,
        string? telefono,
        string matricula)
    {
        string nombreNormalizado = ValidarYNormalizarObligatorio(nombre, "nombre");
        string apellidosNormalizados = ValidarYNormalizarObligatorio(apellidos, "apellidos");
        string matriculaNormalizada = ValidarYNormalizarObligatorio(matricula, "matrícula");

        if (await ExisteMatriculaAsync(matriculaNormalizada))
        {
            throw new InvalidOperationException(
                $"Ya existe un usuario con la matrícula '{matriculaNormalizada}'.");
        }

        var usuario = new Usuario(
            0,
            nombreNormalizado,
            apellidosNormalizados,
            telefono,
            matriculaNormalizada);

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }

    public async Task<Usuario> ModificarAsync(
        int idUsuario,
        string nombre,
        string apellidos,
        string? telefono,
        string matricula)
    {
        string nombreNormalizado = ValidarYNormalizarObligatorio(nombre, "nombre");
        string apellidosNormalizados = ValidarYNormalizarObligatorio(apellidos, "apellidos");
        string matriculaNormalizada = ValidarYNormalizarObligatorio(matricula, "matrícula");
        Usuario? usuario = await _context.Usuarios.FindAsync(idUsuario);

        if (usuario is null)
        {
            throw new KeyNotFoundException(
                $"No se encontró el usuario con Id {idUsuario}.");
        }

        if (await ExisteMatriculaAsync(matriculaNormalizada, idUsuario))
        {
            throw new InvalidOperationException(
                $"Ya existe otro usuario con la matrícula '{matriculaNormalizada}'.");
        }

        usuario.ActualizarDatos(
            nombreNormalizado,
            apellidosNormalizados,
            telefono,
            matriculaNormalizada);

        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<string> EliminarAsync(int idUsuario)
    {
        Usuario? usuario = await _context.Usuarios.FindAsync(idUsuario);

        if (usuario is null)
        {
            throw new KeyNotFoundException(
                $"No se encontró el usuario con Id {idUsuario}.");
        }

        bool tienePrestamos = await _context.Prestamos
            .AnyAsync(prestamo => prestamo.IdUsuario == idUsuario);

        if (tienePrestamos)
        {
            throw new InvalidOperationException(
                "No se puede eliminar el usuario porque tiene préstamos asociados.");
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return "Usuario eliminado correctamente.";
    }

    private async Task<bool> ExisteMatriculaAsync(
        string matricula,
        int? idUsuarioExcluido = null)
    {
        string matriculaMayusculas = matricula.ToUpperInvariant();

        return await _context.Usuarios.AnyAsync(usuario =>
            usuario.Matricula.ToUpper() == matriculaMayusculas &&
            (!idUsuarioExcluido.HasValue ||
             usuario.IdUsuario != idUsuarioExcluido.Value));
    }

    private static string ValidarYNormalizarObligatorio(string valor, string nombreCampo)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new ArgumentException($"El campo {nombreCampo} es obligatorio.", nombreCampo);
        }

        return valor.Trim();
    }
}
