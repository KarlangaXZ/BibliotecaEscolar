namespace BibliotecaEscolar;

partial class FrmPrincipal
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        pnlEncabezado = new Panel();
        lblSubtitulo = new Label();
        lblTitulo = new Label();
        pnlContenido = new Panel();
        tlpModulos = new TableLayoutPanel();
        btnUsuarios = new Button();
        btnLibros = new Button();
        btnCategorias = new Button();
        btnBibliotecarios = new Button();
        btnPrestamos = new Button();
        btnSalir = new Button();
        pnlEncabezado.SuspendLayout();
        pnlContenido.SuspendLayout();
        tlpModulos.SuspendLayout();
        SuspendLayout();
        // 
        // pnlEncabezado
        // 
        pnlEncabezado.BackColor = Color.FromArgb(31, 78, 121);
        pnlEncabezado.Controls.Add(lblSubtitulo);
        pnlEncabezado.Controls.Add(lblTitulo);
        pnlEncabezado.Dock = DockStyle.Top;
        pnlEncabezado.Location = new Point(0, 0);
        pnlEncabezado.Name = "pnlEncabezado";
        pnlEncabezado.Size = new Size(884, 145);
        pnlEncabezado.TabIndex = 0;
        // 
        // lblSubtitulo
        // 
        lblSubtitulo.Dock = DockStyle.Top;
        lblSubtitulo.Font = new Font("Segoe UI", 12F);
        lblSubtitulo.ForeColor = Color.FromArgb(220, 230, 241);
        lblSubtitulo.Location = new Point(0, 78);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Size = new Size(884, 38);
        lblSubtitulo.TabIndex = 1;
        lblSubtitulo.Text = "Sistema de Gestión de Biblioteca";
        lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTitulo
        // 
        lblTitulo.Dock = DockStyle.Top;
        lblTitulo.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(0, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Padding = new Padding(0, 18, 0, 0);
        lblTitulo.Size = new Size(884, 78);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "BIBLIOTECA ESCOLAR";
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlContenido
        // 
        pnlContenido.BackColor = Color.FromArgb(242, 245, 249);
        pnlContenido.Controls.Add(tlpModulos);
        pnlContenido.Dock = DockStyle.Fill;
        pnlContenido.Location = new Point(0, 145);
        pnlContenido.Name = "pnlContenido";
        pnlContenido.Padding = new Padding(70, 55, 70, 55);
        pnlContenido.Size = new Size(884, 416);
        pnlContenido.TabIndex = 1;
        // 
        // tlpModulos
        // 
        tlpModulos.ColumnCount = 2;
        tlpModulos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpModulos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpModulos.Controls.Add(btnUsuarios, 0, 0);
        tlpModulos.Controls.Add(btnLibros, 1, 0);
        tlpModulos.Controls.Add(btnCategorias, 0, 1);
        tlpModulos.Controls.Add(btnBibliotecarios, 1, 1);
        tlpModulos.Controls.Add(btnPrestamos, 0, 2);
        tlpModulos.Controls.Add(btnSalir, 1, 2);
        tlpModulos.Dock = DockStyle.Fill;
        tlpModulos.Location = new Point(70, 55);
        tlpModulos.Name = "tlpModulos";
        tlpModulos.RowCount = 3;
        tlpModulos.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
        tlpModulos.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
        tlpModulos.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
        tlpModulos.Size = new Size(744, 306);
        tlpModulos.TabIndex = 0;
        // 
        // btnUsuarios
        // 
        btnUsuarios.Anchor = AnchorStyles.None;
        btnUsuarios.BackColor = Color.FromArgb(46, 117, 182);
        btnUsuarios.Cursor = Cursors.Hand;
        btnUsuarios.FlatAppearance.BorderSize = 0;
        btnUsuarios.FlatStyle = FlatStyle.Flat;
        btnUsuarios.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        btnUsuarios.ForeColor = Color.White;
        btnUsuarios.Name = "btnUsuarios";
        btnUsuarios.Size = new Size(270, 68);
        btnUsuarios.TabIndex = 0;
        btnUsuarios.Text = "Usuarios";
        btnUsuarios.UseVisualStyleBackColor = false;
        btnUsuarios.Click += BtnUsuarios_Click;
        // 
        // btnLibros
        // 
        btnLibros.Anchor = AnchorStyles.None;
        btnLibros.BackColor = Color.FromArgb(46, 117, 182);
        btnLibros.Cursor = Cursors.Hand;
        btnLibros.FlatAppearance.BorderSize = 0;
        btnLibros.FlatStyle = FlatStyle.Flat;
        btnLibros.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        btnLibros.ForeColor = Color.White;
        btnLibros.Name = "btnLibros";
        btnLibros.Size = new Size(270, 68);
        btnLibros.TabIndex = 1;
        btnLibros.Text = "Libros";
        btnLibros.UseVisualStyleBackColor = false;
        btnLibros.Click += BtnLibros_Click;
        // 
        // btnCategorias
        // 
        btnCategorias.Anchor = AnchorStyles.None;
        btnCategorias.BackColor = Color.FromArgb(46, 117, 182);
        btnCategorias.Cursor = Cursors.Hand;
        btnCategorias.FlatAppearance.BorderSize = 0;
        btnCategorias.FlatStyle = FlatStyle.Flat;
        btnCategorias.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        btnCategorias.ForeColor = Color.White;
        btnCategorias.Name = "btnCategorias";
        btnCategorias.Size = new Size(270, 68);
        btnCategorias.TabIndex = 2;
        btnCategorias.Text = "Categorías";
        btnCategorias.UseVisualStyleBackColor = false;
        btnCategorias.Click += BtnCategorias_Click;
        // 
        // btnBibliotecarios
        // 
        btnBibliotecarios.Anchor = AnchorStyles.None;
        btnBibliotecarios.BackColor = Color.FromArgb(46, 117, 182);
        btnBibliotecarios.Cursor = Cursors.Hand;
        btnBibliotecarios.FlatAppearance.BorderSize = 0;
        btnBibliotecarios.FlatStyle = FlatStyle.Flat;
        btnBibliotecarios.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        btnBibliotecarios.ForeColor = Color.White;
        btnBibliotecarios.Name = "btnBibliotecarios";
        btnBibliotecarios.Size = new Size(270, 68);
        btnBibliotecarios.TabIndex = 3;
        btnBibliotecarios.Text = "Bibliotecarios";
        btnBibliotecarios.UseVisualStyleBackColor = false;
        btnBibliotecarios.Click += BtnBibliotecarios_Click;
        // 
        // btnPrestamos
        // 
        btnPrestamos.Anchor = AnchorStyles.None;
        btnPrestamos.BackColor = Color.FromArgb(46, 117, 182);
        btnPrestamos.Cursor = Cursors.Hand;
        btnPrestamos.FlatAppearance.BorderSize = 0;
        btnPrestamos.FlatStyle = FlatStyle.Flat;
        btnPrestamos.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        btnPrestamos.ForeColor = Color.White;
        btnPrestamos.Name = "btnPrestamos";
        btnPrestamos.Size = new Size(270, 68);
        btnPrestamos.TabIndex = 4;
        btnPrestamos.Text = "Préstamos";
        btnPrestamos.UseVisualStyleBackColor = false;
        btnPrestamos.Click += BtnPrestamos_Click;
        // 
        // btnSalir
        // 
        btnSalir.Anchor = AnchorStyles.None;
        btnSalir.BackColor = Color.FromArgb(192, 57, 43);
        btnSalir.Cursor = Cursors.Hand;
        btnSalir.FlatAppearance.BorderSize = 0;
        btnSalir.FlatStyle = FlatStyle.Flat;
        btnSalir.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        btnSalir.ForeColor = Color.White;
        btnSalir.Name = "btnSalir";
        btnSalir.Size = new Size(270, 68);
        btnSalir.TabIndex = 5;
        btnSalir.Text = "Salir";
        btnSalir.UseVisualStyleBackColor = false;
        btnSalir.Click += BtnSalir_Click;
        // 
        // FrmPrincipal
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(242, 245, 249);
        ClientSize = new Size(884, 561);
        Controls.Add(pnlContenido);
        Controls.Add(pnlEncabezado);
        Font = new Font("Segoe UI", 9F);
        MinimumSize = new Size(800, 560);
        Name = "FrmPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Biblioteca Escolar";
        pnlEncabezado.ResumeLayout(false);
        pnlContenido.ResumeLayout(false);
        tlpModulos.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlEncabezado;
    private Label lblSubtitulo;
    private Label lblTitulo;
    private Panel pnlContenido;
    private TableLayoutPanel tlpModulos;
    private Button btnUsuarios;
    private Button btnLibros;
    private Button btnCategorias;
    private Button btnBibliotecarios;
    private Button btnPrestamos;
    private Button btnSalir;
}
