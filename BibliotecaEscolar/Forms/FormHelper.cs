namespace BibliotecaEscolar;

internal static class FormHelper
{
    public static (Panel editor, DataGridView grid, FlowLayoutPanel buttons) CrearEstructura(Form form, string titulo)
    {
        form.Text = titulo; form.Size = new Size(950, 650); form.MinimumSize = new Size(800, 560);
        form.StartPosition = FormStartPosition.CenterParent; form.BackColor = Color.FromArgb(242, 245, 249);
        var header = new Label { Text = titulo.ToUpperInvariant(), Dock = DockStyle.Top, Height = 65, TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.FromArgb(31, 78, 121), ForeColor = Color.White, Font = new Font("Segoe UI", 18, FontStyle.Bold) };
        var editor = new Panel { Dock = DockStyle.Top, Height = 145, Padding = new Padding(18), AutoScroll = true };
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 65, Padding = new Padding(12), FlowDirection = FlowDirection.LeftToRight };
        var grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, MultiSelect = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoGenerateColumns = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false, BackgroundColor = Color.White };
        form.Controls.Add(grid); form.Controls.Add(buttons); form.Controls.Add(editor); form.Controls.Add(header);
        return (editor, grid, buttons);
    }
    public static TextBox Campo(Panel panel, string etiqueta, int x, int y, int ancho = 190)
    {
        panel.Controls.Add(new Label { Text = etiqueta, Location = new Point(x, y), AutoSize = true });
        var box = new TextBox { Location = new Point(x, y + 22), Width = ancho }; panel.Controls.Add(box); return box;
    }
    public static ComboBox Combo(Panel panel, string etiqueta, int x, int y, int ancho = 220)
    {
        panel.Controls.Add(new Label { Text = etiqueta, Location = new Point(x, y), AutoSize = true });
        var combo = new ComboBox { Location = new Point(x, y + 22), Width = ancho, DropDownStyle = ComboBoxStyle.DropDownList };
        panel.Controls.Add(combo); return combo;
    }
    public static Button Boton(FlowLayoutPanel panel, string texto, EventHandler evento, bool peligro = false)
    {
        var boton = new Button { Text = texto, Width = 130, Height = 38, FlatStyle = FlatStyle.Flat, ForeColor = Color.White,
            BackColor = peligro ? Color.FromArgb(192, 57, 43) : Color.FromArgb(46, 117, 182) };
        boton.Click += evento; panel.Controls.Add(boton); return boton;
    }
    public static void Error(string modulo, Exception ex) => MessageBox.Show(ex.Message, modulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
