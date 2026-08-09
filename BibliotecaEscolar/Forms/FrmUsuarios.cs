using BibliotecaEscolar.Data;
using BibliotecaEscolar.Models;
using BibliotecaEscolar.Services;

namespace BibliotecaEscolar;

public class FrmUsuarios : Form
{
    private readonly BibliotecaDbContext _context = new(); private readonly UsuarioService _service;
    private readonly DataGridView _grid; private readonly TextBox _nombre, _apellidos, _telefono, _matricula; private int? _id;
    public FrmUsuarios()
    {
        _service = new(_context); var ui = FormHelper.CrearEstructura(this, "Gestión de Usuarios"); _grid = ui.grid;
        _nombre = FormHelper.Campo(ui.editor, "Nombre", 20, 15); _apellidos = FormHelper.Campo(ui.editor, "Apellidos", 230, 15);
        _telefono = FormHelper.Campo(ui.editor, "Teléfono", 440, 15); _matricula = FormHelper.Campo(ui.editor, "Matrícula", 650, 15);
        FormHelper.Boton(ui.buttons, "Nuevo / Limpiar", (_, _) => Limpiar()); FormHelper.Boton(ui.buttons, "Guardar", Guardar);
        FormHelper.Boton(ui.buttons, "Editar selección", Editar); FormHelper.Boton(ui.buttons, "Eliminar", Eliminar, true);
        FormHelper.Boton(ui.buttons, "Cerrar", (_, _) => Close()); Load += async (_, _) => await Cargar();
    }
    private async Task Cargar() { try { _grid.DataSource = await _service.ListarAsync(); OcultarNavegaciones(); Limpiar(); } catch (Exception ex) { FormHelper.Error("Usuarios", ex); } }
    private async void Guardar(object? s, EventArgs e) { try { if (_id.HasValue) await _service.ModificarAsync(_id.Value, _nombre.Text, _apellidos.Text, _telefono.Text, _matricula.Text); else await _service.CrearAsync(_nombre.Text, _apellidos.Text, _telefono.Text, _matricula.Text); MessageBox.Show("Usuario guardado correctamente."); await Cargar(); } catch (Exception ex) { FormHelper.Error("Usuarios", ex); } }
    private async void Editar(object? s, EventArgs e) { if (_grid.CurrentRow?.DataBoundItem is not Usuario x) { MessageBox.Show("Seleccione un usuario."); return; } try { var item = await _service.BuscarPorIdAsync(x.IdUsuario) ?? throw new KeyNotFoundException("El usuario ya no existe."); _id=item.IdUsuario; _nombre.Text=item.Nombre; _apellidos.Text=item.Apellidos; _telefono.Text=item.Telefono; _matricula.Text=item.Matricula; } catch(Exception ex){FormHelper.Error("Usuarios",ex);} }
    private async void Eliminar(object? s, EventArgs e) { if (_grid.CurrentRow?.DataBoundItem is not Usuario x) { MessageBox.Show("Seleccione un usuario."); return; } if(MessageBox.Show("¿Eliminar el usuario seleccionado?","Confirmar",MessageBoxButtons.YesNo)!=DialogResult.Yes)return; try { MessageBox.Show(await _service.EliminarAsync(x.IdUsuario)); await Cargar(); } catch(Exception ex){FormHelper.Error("Usuarios",ex);} }
    private void Limpiar(){_id=null; _nombre.Clear();_apellidos.Clear();_telefono.Clear();_matricula.Clear();_grid.ClearSelection();}
    private void OcultarNavegaciones(){if(_grid.Columns[nameof(Usuario.Prestamos)] is DataGridViewColumn c)c.Visible=false;}
    protected override void OnFormClosed(FormClosedEventArgs e){_context.Dispose();base.OnFormClosed(e);}
}
