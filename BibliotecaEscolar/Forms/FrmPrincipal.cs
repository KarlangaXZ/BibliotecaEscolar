namespace BibliotecaEscolar;

public partial class FrmPrincipal : Form
{
    public FrmPrincipal() => InitializeComponent();
    private void BtnUsuarios_Click(object sender, EventArgs e) { using var f = new FrmUsuarios(); f.ShowDialog(this); }
    private void BtnLibros_Click(object sender, EventArgs e) { using var f = new FrmLibros(); f.ShowDialog(this); }
    private void BtnCategorias_Click(object sender, EventArgs e) { using var f = new FrmCategorias(); f.ShowDialog(this); }
    private void BtnBibliotecarios_Click(object sender, EventArgs e) { using var f = new FrmBibliotecarios(); f.ShowDialog(this); }
    private void BtnPrestamos_Click(object sender, EventArgs e) { using var f = new FrmPrestamos(); f.ShowDialog(this); }
    private void BtnSalir_Click(object sender, EventArgs e) => Close();
}
