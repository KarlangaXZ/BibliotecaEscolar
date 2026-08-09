using BibliotecaEscolar.Data; using BibliotecaEscolar.Models; using BibliotecaEscolar.Services;
namespace BibliotecaEscolar;
public class FrmBibliotecarios : Form
{
    private readonly BibliotecaDbContext _context=new(); private readonly BibliotecarioService _service; private readonly DataGridView _grid;
    private readonly TextBox _nombre,_apellidos,_telefono,_codigo; private int? _id;
    public FrmBibliotecarios(){_service=new(_context);var ui=FormHelper.CrearEstructura(this,"Gestión de Bibliotecarios");_grid=ui.grid;
        _nombre=FormHelper.Campo(ui.editor,"Nombre",20,15);_apellidos=FormHelper.Campo(ui.editor,"Apellidos",230,15);_telefono=FormHelper.Campo(ui.editor,"Teléfono",440,15);_codigo=FormHelper.Campo(ui.editor,"Código empleado",650,15);
        FormHelper.Boton(ui.buttons,"Nuevo / Limpiar",(_,_)=>Limpiar());FormHelper.Boton(ui.buttons,"Guardar",Guardar);FormHelper.Boton(ui.buttons,"Editar selección",Editar);FormHelper.Boton(ui.buttons,"Eliminar",Eliminar,true);FormHelper.Boton(ui.buttons,"Cerrar",(_,_)=>Close());Load+=async(_,_)=>await Cargar();}
    private async Task Cargar(){try{_grid.DataSource=await _service.ListarAsync();if(_grid.Columns[nameof(Bibliotecario.Prestamos)] is DataGridViewColumn c)c.Visible=false;Limpiar();}catch(Exception ex){FormHelper.Error("Bibliotecarios",ex);}}
    private async void Guardar(object?s,EventArgs e){try{if(_id.HasValue)await _service.ModificarAsync(_id.Value,_nombre.Text,_apellidos.Text,_telefono.Text,_codigo.Text);else await _service.CrearAsync(_nombre.Text,_apellidos.Text,_telefono.Text,_codigo.Text);MessageBox.Show("Bibliotecario guardado correctamente.");await Cargar();}catch(Exception ex){FormHelper.Error("Bibliotecarios",ex);}}
    private async void Editar(object?s,EventArgs e){if(_grid.CurrentRow?.DataBoundItem is not Bibliotecario x){MessageBox.Show("Seleccione un bibliotecario.");return;}try{var i=await _service.BuscarPorIdAsync(x.IdBibliotecario)??throw new KeyNotFoundException("El bibliotecario ya no existe.");_id=i.IdBibliotecario;_nombre.Text=i.Nombre;_apellidos.Text=i.Apellidos;_telefono.Text=i.Telefono;_codigo.Text=i.CodigoEmpleado;}catch(Exception ex){FormHelper.Error("Bibliotecarios",ex);}}
    private async void Eliminar(object?s,EventArgs e){if(_grid.CurrentRow?.DataBoundItem is not Bibliotecario x){MessageBox.Show("Seleccione un bibliotecario.");return;}if(MessageBox.Show("¿Eliminar el bibliotecario seleccionado?","Confirmar",MessageBoxButtons.YesNo)!=DialogResult.Yes)return;try{MessageBox.Show(await _service.EliminarAsync(x.IdBibliotecario));await Cargar();}catch(Exception ex){FormHelper.Error("Bibliotecarios",ex);}}
    private void Limpiar(){_id=null;_nombre.Clear();_apellidos.Clear();_telefono.Clear();_codigo.Clear();_grid.ClearSelection();}protected override void OnFormClosed(FormClosedEventArgs e){_context.Dispose();base.OnFormClosed(e);}
}
