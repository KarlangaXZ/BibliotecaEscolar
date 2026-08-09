using BibliotecaEscolar.Data;
using BibliotecaEscolar.Models;
using BibliotecaEscolar.Services;

namespace BibliotecaEscolar;

public partial class FrmCategorias : Form
{
    private readonly BibliotecaDbContext _context;
    private readonly CategoriaService _categoriaService;
    private int? _idCategoriaEnEdicion;

    public FrmCategorias()
    {
        InitializeComponent();
        _context = new BibliotecaDbContext();
        _categoriaService = new CategoriaService(_context);
    }

    private async void FrmCategorias_Load(object sender, EventArgs e)
    {
        await CargarCategoriasAsync();
    }

    private void BtnNuevo_Click(object sender, EventArgs e)
    {
        LimpiarEdicion();
        txtNombre.Focus();
    }

    private async void BtnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (_idCategoriaEnEdicion.HasValue)
            {
                await _categoriaService.ModificarAsync(
                    _idCategoriaEnEdicion.Value,
                    txtNombre.Text,
                    txtDescripcion.Text);

                MessageBox.Show("Categoría modificada correctamente.", "Categorías",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                await _categoriaService.CrearAsync(
                    txtNombre.Text,
                    txtDescripcion.Text);

                MessageBox.Show("Categoría creada correctamente.", "Categorías",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            await CargarCategoriasAsync();
        }
        catch (Exception ex)
        {
            MostrarError(ex.Message);
        }
    }

    private async void BtnEditar_Click(object sender, EventArgs e)
    {
        int? idCategoria = ObtenerIdSeleccionado();

        if (!idCategoria.HasValue)
        {
            MostrarError("Seleccione una categoría para editar.");
            return;
        }

        try
        {
            Categoria? categoria = await _categoriaService.BuscarPorIdAsync(idCategoria.Value);

            if (categoria is null)
            {
                MostrarError("La categoría seleccionada ya no existe.");
                await CargarCategoriasAsync();
                return;
            }

            _idCategoriaEnEdicion = categoria.IdCategoria;
            txtNombre.Text = categoria.Nombre;
            txtDescripcion.Text = categoria.Descripcion;
            lblEstado.Text = $"Editando categoría Id: {categoria.IdCategoria}";
            txtNombre.Focus();
        }
        catch (Exception ex)
        {
            MostrarError(ex.Message);
        }
    }

    private async void BtnEliminar_Click(object sender, EventArgs e)
    {
        int? idCategoria = ObtenerIdSeleccionado();

        if (!idCategoria.HasValue)
        {
            MostrarError("Seleccione una categoría para eliminar.");
            return;
        }

        DialogResult confirmacion = MessageBox.Show(
            "¿Desea eliminar la categoría seleccionada?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmacion != DialogResult.Yes)
        {
            return;
        }

        try
        {
            string mensaje = await _categoriaService.EliminarAsync(idCategoria.Value);
            MessageBox.Show(mensaje, "Categorías",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarCategoriasAsync();
        }
        catch (Exception ex)
        {
            MostrarError(ex.Message);
        }
    }

    private void BtnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async Task CargarCategoriasAsync()
    {
        try
        {
            dgvCategorias.DataSource = await _categoriaService.ListarAsync();
            LimpiarEdicion();
        }
        catch (Exception ex)
        {
            MostrarError($"No fue posible cargar las categorías. {ex.Message}");
        }
    }

    private int? ObtenerIdSeleccionado()
    {
        return dgvCategorias.CurrentRow?.DataBoundItem is Categoria categoria
            ? categoria.IdCategoria
            : null;
    }

    private void LimpiarEdicion()
    {
        _idCategoriaEnEdicion = null;
        txtNombre.Clear();
        txtDescripcion.Clear();
        lblEstado.Text = "Nueva categoría";
        dgvCategorias.ClearSelection();
    }

    private static void MostrarError(string mensaje)
    {
        MessageBox.Show(mensaje, "Categorías",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _context.Dispose();
        base.OnFormClosed(e);
    }
}
