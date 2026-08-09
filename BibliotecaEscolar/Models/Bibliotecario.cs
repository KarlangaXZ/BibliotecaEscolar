namespace BibliotecaEscolar.Models;

public class Bibliotecario : Persona
{
    public int IdBibliotecario { get; private set; }
    public string CodigoEmpleado { get; private set; } = string.Empty;
    public ICollection<Prestamo> Prestamos { get; private set; }

    private Bibliotecario()
    {
        CodigoEmpleado = string.Empty;
        Prestamos = new List<Prestamo>();
    }

    public Bibliotecario(int idBibliotecario, string nombre, string apellidos, string telefono, string codigoEmpleado)
        : base(nombre, apellidos, telefono)
    {
        IdBibliotecario = idBibliotecario;
        Prestamos = new List<Prestamo>();
        ActualizarDatos(nombre, apellidos, telefono, codigoEmpleado);
    }

    public void ActualizarDatos(string nombre, string apellidos, string? telefono, string codigoEmpleado)
    {
        if (string.IsNullOrWhiteSpace(codigoEmpleado))
        {
            throw new ArgumentException("El código de empleado es obligatorio.", nameof(codigoEmpleado));
        }

        ActualizarDatosPersonales(nombre, apellidos, telefono);
        CodigoEmpleado = codigoEmpleado.Trim();
    }

    public override string ObtenerDescripcion()
    {
        return $"Bibliotecario: {Nombre} {Apellidos} - Código: {CodigoEmpleado}";
    }
}
