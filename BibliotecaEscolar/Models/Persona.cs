namespace BibliotecaEscolar.Models;

public abstract class Persona
{
    public string Nombre { get; private set; }
    public string Apellidos { get; private set; }
    public string Telefono { get; private set; }

    protected Persona(string nombre, string apellidos, string? telefono)
    {
        Nombre = string.Empty;
        Apellidos = string.Empty;
        Telefono = string.Empty;
        ActualizarDatosPersonales(nombre, apellidos, telefono);
    }

    protected void ActualizarDatosPersonales(
        string nombre,
        string apellidos,
        string? telefono)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre del usuario es obligatorio.", nameof(nombre));
        }

        if (string.IsNullOrWhiteSpace(apellidos))
        {
            throw new ArgumentException("Los apellidos del usuario son obligatorios.", nameof(apellidos));
        }

        Nombre = nombre.Trim();
        Apellidos = apellidos.Trim();
        Telefono = string.IsNullOrWhiteSpace(telefono)
            ? "No especificado"
            : telefono.Trim();
    }

    protected Persona()
    {
        Nombre = string.Empty;
        Apellidos = string.Empty;
        Telefono = string.Empty;
    }

    public abstract string ObtenerDescripcion();
}
