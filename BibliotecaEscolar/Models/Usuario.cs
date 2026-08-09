namespace BibliotecaEscolar.Models;

public class Usuario : Persona
{
    public int IdUsuario { get; private set; }
    public string Matricula { get; private set; } = string.Empty;
    public ICollection<Prestamo> Prestamos { get; private set; }

    private Usuario()
    {
        Matricula = string.Empty;
        Prestamos = new List<Prestamo>();
    }

    public Usuario(int idUsuario, string nombre, string apellidos, string? telefono, string matricula)
        : base(nombre, apellidos, telefono)
    {
        IdUsuario = idUsuario;
        Prestamos = new List<Prestamo>();
        ActualizarMatricula(matricula);
    }

    public void ActualizarDatos(
        string nombre,
        string apellidos,
        string? telefono,
        string matricula)
    {
        if (string.IsNullOrWhiteSpace(matricula))
        {
            throw new ArgumentException("La matrícula es obligatoria.", nameof(matricula));
        }

        ActualizarDatosPersonales(nombre, apellidos, telefono);
        Matricula = matricula.Trim();
    }

    private void ActualizarMatricula(string matricula)
    {
        if (string.IsNullOrWhiteSpace(matricula))
        {
            throw new ArgumentException("La matrícula es obligatoria.", nameof(matricula));
        }

        Matricula = matricula.Trim();
    }

    public override string ObtenerDescripcion()
    {
        return $"Usuario: {Nombre} {Apellidos} - Matrícula: {Matricula}";
    }
}
