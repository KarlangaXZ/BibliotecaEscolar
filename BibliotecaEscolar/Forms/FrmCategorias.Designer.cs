namespace BibliotecaEscolar;

partial class FrmCategorias
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
        lblTitulo = new Label();
        pnlContenido = new Panel();
        tlpPrincipal = new TableLayoutPanel();
        dgvCategorias = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colNombre = new DataGridViewTextBoxColumn();
        colDescripcion = new DataGridViewTextBoxColumn();
        grpEdicion = new GroupBox();
        tlpEdicion = new TableLayoutPanel();
        lblNombre = new Label();
        txtNombre = new TextBox();
        lblDescripcion = new Label();
        txtDescripcion = new TextBox();
        lblEstado = new Label();
        tlpBotones = new TableLayoutPanel();
        btnNuevo = new Button();
        btnGuardar = new Button();
        btnEditar = new Button();
        btnEliminar = new Button();
        btnCerrar = new Button();
        pnlEncabezado.SuspendLayout();
        pnlContenido.SuspendLayout();
        tlpPrincipal.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
        grpEdicion.SuspendLayout();
        tlpEdicion.SuspendLayout();
        tlpBotones.SuspendLayout();
        SuspendLayout();
        // 
        // pnlEncabezado
        // 
        pnlEncabezado.BackColor = Color.FromArgb(31, 78, 121);
        pnlEncabezado.Controls.Add(lblTitulo);
        pnlEncabezado.Dock = DockStyle.Top;
        pnlEncabezado.Location = new Point(0, 0);
        pnlEncabezado.Name = "pnlEncabezado";
        pnlEncabezado.Size = new Size(850, 78);
        pnlEncabezado.TabIndex = 0;
        // 
        // lblTitulo
        // 
        lblTitulo.Dock = DockStyle.Fill;
        lblTitulo.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(0, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(850, 78);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Gestión de Categorías";
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlContenido
        // 
        pnlContenido.BackColor = Color.FromArgb(242, 245, 249);
        pnlContenido.Controls.Add(tlpPrincipal);
        pnlContenido.Dock = DockStyle.Fill;
        pnlContenido.Location = new Point(0, 78);
        pnlContenido.Name = "pnlContenido";
        pnlContenido.Padding = new Padding(20);
        pnlContenido.Size = new Size(850, 522);
        pnlContenido.TabIndex = 1;
        // 
        // tlpPrincipal
        // 
        tlpPrincipal.ColumnCount = 1;
        tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpPrincipal.Controls.Add(dgvCategorias, 0, 0);
        tlpPrincipal.Controls.Add(grpEdicion, 0, 1);
        tlpPrincipal.Controls.Add(tlpBotones, 0, 2);
        tlpPrincipal.Dock = DockStyle.Fill;
        tlpPrincipal.Location = new Point(20, 20);
        tlpPrincipal.Name = "tlpPrincipal";
        tlpPrincipal.RowCount = 3;
        tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
        tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
        tlpPrincipal.Size = new Size(810, 482);
        tlpPrincipal.TabIndex = 0;
        // 
        // dgvCategorias
        // 
        dgvCategorias.AllowUserToAddRows = false;
        dgvCategorias.AllowUserToDeleteRows = false;
        dgvCategorias.AllowUserToResizeRows = false;
        dgvCategorias.AutoGenerateColumns = false;
        dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCategorias.BackgroundColor = Color.White;
        dgvCategorias.BorderStyle = BorderStyle.Fixed3D;
        dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCategorias.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colDescripcion });
        dgvCategorias.Dock = DockStyle.Fill;
        dgvCategorias.Location = new Point(3, 3);
        dgvCategorias.MultiSelect = false;
        dgvCategorias.Name = "dgvCategorias";
        dgvCategorias.ReadOnly = true;
        dgvCategorias.RowHeadersVisible = false;
        dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCategorias.Size = new Size(804, 264);
        dgvCategorias.TabIndex = 0;
        // 
        // colId
        // 
        colId.DataPropertyName = "IdCategoria";
        colId.FillWeight = 20F;
        colId.HeaderText = "Id";
        colId.Name = "colId";
        colId.ReadOnly = true;
        // 
        // colNombre
        // 
        colNombre.DataPropertyName = "Nombre";
        colNombre.FillWeight = 45F;
        colNombre.HeaderText = "Nombre";
        colNombre.Name = "colNombre";
        colNombre.ReadOnly = true;
        // 
        // colDescripcion
        // 
        colDescripcion.DataPropertyName = "Descripcion";
        colDescripcion.FillWeight = 80F;
        colDescripcion.HeaderText = "Descripción";
        colDescripcion.Name = "colDescripcion";
        colDescripcion.ReadOnly = true;
        // 
        // grpEdicion
        // 
        grpEdicion.Controls.Add(tlpEdicion);
        grpEdicion.Dock = DockStyle.Fill;
        grpEdicion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpEdicion.Location = new Point(3, 273);
        grpEdicion.Name = "grpEdicion";
        grpEdicion.Padding = new Padding(12, 8, 12, 8);
        grpEdicion.Size = new Size(804, 144);
        grpEdicion.TabIndex = 1;
        grpEdicion.TabStop = false;
        grpEdicion.Text = "Datos de la categoría";
        // 
        // tlpEdicion
        // 
        tlpEdicion.ColumnCount = 2;
        tlpEdicion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
        tlpEdicion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpEdicion.Controls.Add(lblNombre, 0, 0);
        tlpEdicion.Controls.Add(txtNombre, 1, 0);
        tlpEdicion.Controls.Add(lblDescripcion, 0, 1);
        tlpEdicion.Controls.Add(txtDescripcion, 1, 1);
        tlpEdicion.Controls.Add(lblEstado, 1, 2);
        tlpEdicion.Dock = DockStyle.Fill;
        tlpEdicion.Location = new Point(12, 26);
        tlpEdicion.Name = "tlpEdicion";
        tlpEdicion.RowCount = 3;
        tlpEdicion.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        tlpEdicion.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpEdicion.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
        tlpEdicion.Size = new Size(780, 110);
        tlpEdicion.TabIndex = 0;
        // 
        // lblNombre
        // 
        lblNombre.Dock = DockStyle.Fill;
        lblNombre.Font = new Font("Segoe UI", 10F);
        lblNombre.Location = new Point(3, 0);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(104, 35);
        lblNombre.TabIndex = 0;
        lblNombre.Text = "Nombre:";
        lblNombre.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtNombre
        // 
        txtNombre.Dock = DockStyle.Fill;
        txtNombre.Font = new Font("Segoe UI", 10F);
        txtNombre.Location = new Point(113, 3);
        txtNombre.MaxLength = 100;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(664, 25);
        txtNombre.TabIndex = 1;
        // 
        // lblDescripcion
        // 
        lblDescripcion.Dock = DockStyle.Fill;
        lblDescripcion.Font = new Font("Segoe UI", 10F);
        lblDescripcion.Location = new Point(3, 35);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(104, 50);
        lblDescripcion.TabIndex = 2;
        lblDescripcion.Text = "Descripción:";
        lblDescripcion.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtDescripcion
        // 
        txtDescripcion.Dock = DockStyle.Fill;
        txtDescripcion.Font = new Font("Segoe UI", 10F);
        txtDescripcion.Location = new Point(113, 38);
        txtDescripcion.MaxLength = 300;
        txtDescripcion.Multiline = true;
        txtDescripcion.Name = "txtDescripcion";
        txtDescripcion.ScrollBars = ScrollBars.Vertical;
        txtDescripcion.Size = new Size(664, 44);
        txtDescripcion.TabIndex = 3;
        // 
        // lblEstado
        // 
        lblEstado.Dock = DockStyle.Fill;
        lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        lblEstado.ForeColor = Color.FromArgb(31, 78, 121);
        lblEstado.Location = new Point(113, 85);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(664, 25);
        lblEstado.TabIndex = 4;
        lblEstado.Text = "Nueva categoría";
        lblEstado.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // tlpBotones
        // 
        tlpBotones.ColumnCount = 5;
        tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpBotones.Controls.Add(btnNuevo, 0, 0);
        tlpBotones.Controls.Add(btnGuardar, 1, 0);
        tlpBotones.Controls.Add(btnEditar, 2, 0);
        tlpBotones.Controls.Add(btnEliminar, 3, 0);
        tlpBotones.Controls.Add(btnCerrar, 4, 0);
        tlpBotones.Dock = DockStyle.Fill;
        tlpBotones.Location = new Point(3, 423);
        tlpBotones.Name = "tlpBotones";
        tlpBotones.RowCount = 1;
        tlpBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpBotones.Size = new Size(804, 56);
        tlpBotones.TabIndex = 2;
        // 
        // btnNuevo
        // 
        btnNuevo.Anchor = AnchorStyles.None;
        btnNuevo.BackColor = Color.FromArgb(46, 117, 182);
        btnNuevo.FlatAppearance.BorderSize = 0;
        btnNuevo.FlatStyle = FlatStyle.Flat;
        btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnNuevo.ForeColor = Color.White;
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Size = new Size(125, 40);
        btnNuevo.TabIndex = 0;
        btnNuevo.Text = "Nuevo";
        btnNuevo.UseVisualStyleBackColor = false;
        btnNuevo.Click += BtnNuevo_Click;
        // 
        // btnGuardar
        // 
        btnGuardar.Anchor = AnchorStyles.None;
        btnGuardar.BackColor = Color.FromArgb(46, 117, 182);
        btnGuardar.FlatAppearance.BorderSize = 0;
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnGuardar.ForeColor = Color.White;
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(125, 40);
        btnGuardar.TabIndex = 1;
        btnGuardar.Text = "Guardar";
        btnGuardar.UseVisualStyleBackColor = false;
        btnGuardar.Click += BtnGuardar_Click;
        // 
        // btnEditar
        // 
        btnEditar.Anchor = AnchorStyles.None;
        btnEditar.BackColor = Color.FromArgb(46, 117, 182);
        btnEditar.FlatAppearance.BorderSize = 0;
        btnEditar.FlatStyle = FlatStyle.Flat;
        btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnEditar.ForeColor = Color.White;
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(125, 40);
        btnEditar.TabIndex = 2;
        btnEditar.Text = "Editar";
        btnEditar.UseVisualStyleBackColor = false;
        btnEditar.Click += BtnEditar_Click;
        // 
        // btnEliminar
        // 
        btnEliminar.Anchor = AnchorStyles.None;
        btnEliminar.BackColor = Color.FromArgb(192, 57, 43);
        btnEliminar.FlatAppearance.BorderSize = 0;
        btnEliminar.FlatStyle = FlatStyle.Flat;
        btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnEliminar.ForeColor = Color.White;
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(125, 40);
        btnEliminar.TabIndex = 3;
        btnEliminar.Text = "Eliminar";
        btnEliminar.UseVisualStyleBackColor = false;
        btnEliminar.Click += BtnEliminar_Click;
        // 
        // btnCerrar
        // 
        btnCerrar.Anchor = AnchorStyles.None;
        btnCerrar.BackColor = Color.FromArgb(91, 101, 112);
        btnCerrar.DialogResult = DialogResult.Cancel;
        btnCerrar.FlatAppearance.BorderSize = 0;
        btnCerrar.FlatStyle = FlatStyle.Flat;
        btnCerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnCerrar.ForeColor = Color.White;
        btnCerrar.Name = "btnCerrar";
        btnCerrar.Size = new Size(125, 40);
        btnCerrar.TabIndex = 4;
        btnCerrar.Text = "Cerrar";
        btnCerrar.UseVisualStyleBackColor = false;
        btnCerrar.Click += BtnCerrar_Click;
        // 
        // FrmCategorias
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(242, 245, 249);
        CancelButton = btnCerrar;
        ClientSize = new Size(850, 600);
        Controls.Add(pnlContenido);
        Controls.Add(pnlEncabezado);
        Font = new Font("Segoe UI", 9F);
        MinimumSize = new Size(760, 560);
        Name = "FrmCategorias";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Gestión de Categorías";
        Load += FrmCategorias_Load;
        pnlEncabezado.ResumeLayout(false);
        pnlContenido.ResumeLayout(false);
        tlpPrincipal.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
        grpEdicion.ResumeLayout(false);
        tlpEdicion.ResumeLayout(false);
        tlpEdicion.PerformLayout();
        tlpBotones.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlEncabezado;
    private Label lblTitulo;
    private Panel pnlContenido;
    private TableLayoutPanel tlpPrincipal;
    private DataGridView dgvCategorias;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colNombre;
    private DataGridViewTextBoxColumn colDescripcion;
    private GroupBox grpEdicion;
    private TableLayoutPanel tlpEdicion;
    private Label lblNombre;
    private TextBox txtNombre;
    private Label lblDescripcion;
    private TextBox txtDescripcion;
    private Label lblEstado;
    private TableLayoutPanel tlpBotones;
    private Button btnNuevo;
    private Button btnGuardar;
    private Button btnEditar;
    private Button btnEliminar;
    private Button btnCerrar;
}
