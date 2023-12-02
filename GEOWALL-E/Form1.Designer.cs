namespace GEOWALL_E
{
    partial class GEOWALL_E
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GEOWALL_E));
            BTN_ACCION = new Button();
            PANEL_COMANDOS = new TextBox();
            PANEL_DIBUJO = new PictureBox();
            IMPORTAR = new Button();
            GUARDADR_FUNCIONES = new Button();
            IMAGEN_WALL_E_NOMBRE = new Label();
            WALLE_E_NOMBRE = new Label();
            IMAGEN_WALLE = new Label();
            ((System.ComponentModel.ISupportInitialize)PANEL_DIBUJO).BeginInit();
            SuspendLayout();
            // 
            // BTN_ACCION
            // 
            BTN_ACCION.Location = new Point(359, 671);
            BTN_ACCION.Name = "BTN_ACCION";
            BTN_ACCION.Size = new Size(180, 86);
            BTN_ACCION.TabIndex = 0;
            BTN_ACCION.Text = "DIBUJAR";
            BTN_ACCION.UseVisualStyleBackColor = true;
            BTN_ACCION.Click += BTN_ACCION_Click;
            // 
            // PANEL_COMANDOS
            // 
            PANEL_COMANDOS.BackColor = SystemColors.HighlightText;
            PANEL_COMANDOS.Cursor = Cursors.IBeam;
            PANEL_COMANDOS.Location = new Point(31, 94);
            PANEL_COMANDOS.Multiline = true;
            PANEL_COMANDOS.Name = "PANEL_COMANDOS";
            PANEL_COMANDOS.Size = new Size(575, 563);
            PANEL_COMANDOS.TabIndex = 2;
            PANEL_COMANDOS.TextChanged += PANEL_COMANDOS_TextChanged;
            // 
            // PANEL_DIBUJO
            // 
            PANEL_DIBUJO.BackColor = SystemColors.ButtonHighlight;
            PANEL_DIBUJO.Location = new Point(634, 51);
            PANEL_DIBUJO.Name = "PANEL_DIBUJO";
            PANEL_DIBUJO.Size = new Size(1236, 890);
            PANEL_DIBUJO.TabIndex = 3;
            PANEL_DIBUJO.TabStop = false;
            PANEL_DIBUJO.Click += PANEL_DIBUJO_Click;
            // 
            // IMPORTAR
            // 
            IMPORTAR.Location = new Point(359, 763);
            IMPORTAR.Name = "IMPORTAR";
            IMPORTAR.Size = new Size(180, 88);
            IMPORTAR.TabIndex = 4;
            IMPORTAR.Text = "IMPORTAR";
            IMPORTAR.UseVisualStyleBackColor = true;
            IMPORTAR.Click += IMPORTAR_Click;
            // 
            // GUARDADR_FUNCIONES
            // 
            GUARDADR_FUNCIONES.Location = new Point(359, 857);
            GUARDADR_FUNCIONES.Name = "GUARDADR_FUNCIONES";
            GUARDADR_FUNCIONES.Size = new Size(180, 84);
            GUARDADR_FUNCIONES.TabIndex = 5;
            GUARDADR_FUNCIONES.Text = "GUARDAR";
            GUARDADR_FUNCIONES.UseVisualStyleBackColor = true;
            GUARDADR_FUNCIONES.Click += GUARDADR_FUNCIONES_Click;
            // 
            // IMAGEN_WALL_E_NOMBRE
            // 
            IMAGEN_WALL_E_NOMBRE.AutoSize = true;
            IMAGEN_WALL_E_NOMBRE.Image = (Image)resources.GetObject("IMAGEN_WALL_E_NOMBRE.Image");
            IMAGEN_WALL_E_NOMBRE.ImageAlign = ContentAlignment.TopCenter;
            IMAGEN_WALL_E_NOMBRE.Location = new Point(1017, 28);
            IMAGEN_WALL_E_NOMBRE.Name = "IMAGEN_WALL_E_NOMBRE";
            IMAGEN_WALL_E_NOMBRE.Size = new Size(0, 20);
            IMAGEN_WALL_E_NOMBRE.TabIndex = 6;
            // 
            // WALLE_E_NOMBRE
            // 
            WALLE_E_NOMBRE.BackColor = SystemColors.ActiveCaptionText;
            WALLE_E_NOMBRE.BorderStyle = BorderStyle.FixedSingle;
            WALLE_E_NOMBRE.ForeColor = SystemColors.ControlText;
            WALLE_E_NOMBRE.Image = Properties.Resources.walle_nombre;
            WALLE_E_NOMBRE.Location = new Point(104, 9);
            WALLE_E_NOMBRE.Name = "WALLE_E_NOMBRE";
            WALLE_E_NOMBRE.Size = new Size(416, 63);
            WALLE_E_NOMBRE.TabIndex = 7;
            // 
            // IMAGEN_WALLE
            // 
            IMAGEN_WALLE.Image = Properties.Resources.images;
            IMAGEN_WALLE.Location = new Point(83, 674);
            IMAGEN_WALLE.Name = "IMAGEN_WALLE";
            IMAGEN_WALLE.Size = new Size(192, 270);
            IMAGEN_WALLE.TabIndex = 8;
            // 
            // GEOWALL_E
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(1882, 953);
            Controls.Add(IMAGEN_WALLE);
            Controls.Add(WALLE_E_NOMBRE);
            Controls.Add(IMAGEN_WALL_E_NOMBRE);
            Controls.Add(GUARDADR_FUNCIONES);
            Controls.Add(IMPORTAR);
            Controls.Add(PANEL_DIBUJO);
            Controls.Add(PANEL_COMANDOS);
            Controls.Add(BTN_ACCION);
            Name = "GEOWALL_E";
            Text = "GEOWALL-E";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)PANEL_DIBUJO).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN_ACCION;
        private TextBox PANEL_COMANDOS;
        private PictureBox PANEL_DIBUJO;
        private Button IMPORTAR;
        private Button GUARDADR_FUNCIONES;
        private Label IMAGEN_WALL_E_NOMBRE;
        private Label WALLE_E_NOMBRE;
        private Label IMAGEN_WALLE;
    }
}