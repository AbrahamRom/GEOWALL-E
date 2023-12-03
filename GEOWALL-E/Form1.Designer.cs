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
            PANEL_COMANDOS = new TextBox();
            PANEL_DIBUJO = new PictureBox();
            IMAGEN_WALL_E_NOMBRE = new Label();
            WALLE_E_NOMBRE = new Label();
            IMAGEN_WALLE = new Label();
            DRAW = new Boton_personalizado();
            IMPORT = new Boton_personalizado();
            SAVE = new Boton_personalizado();
            ((System.ComponentModel.ISupportInitialize)PANEL_DIBUJO).BeginInit();
            SuspendLayout();
            // 
            // PANEL_COMANDOS
            // 
            PANEL_COMANDOS.BackColor = SystemColors.HighlightText;
            PANEL_COMANDOS.BorderStyle = BorderStyle.FixedSingle;
            PANEL_COMANDOS.Cursor = Cursors.IBeam;
            PANEL_COMANDOS.Location = new Point(31, 136);
            PANEL_COMANDOS.Multiline = true;
            PANEL_COMANDOS.Name = "PANEL_COMANDOS";
            PANEL_COMANDOS.Size = new Size(569, 521);
            PANEL_COMANDOS.TabIndex = 2;
            PANEL_COMANDOS.TextChanged += PANEL_COMANDOS_TextChanged;
            // 
            // PANEL_DIBUJO
            // 
            PANEL_DIBUJO.BackColor = SystemColors.ButtonHighlight;
            PANEL_DIBUJO.BorderStyle = BorderStyle.FixedSingle;
            PANEL_DIBUJO.Location = new Point(634, 51);
            PANEL_DIBUJO.Name = "PANEL_DIBUJO";
            PANEL_DIBUJO.Size = new Size(1236, 890);
            PANEL_DIBUJO.TabIndex = 3;
            PANEL_DIBUJO.TabStop = false;
            PANEL_DIBUJO.Click += PANEL_DIBUJO_Click;
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
            WALLE_E_NOMBRE.BackColor = SystemColors.ButtonHighlight;
            WALLE_E_NOMBRE.ForeColor = SystemColors.ControlText;
            WALLE_E_NOMBRE.Image = Properties.Resources.walle_nombre;
            WALLE_E_NOMBRE.Location = new Point(83, 27);
            WALLE_E_NOMBRE.Name = "WALLE_E_NOMBRE";
            WALLE_E_NOMBRE.Size = new Size(466, 106);
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
            // DRAW
            // 
            DRAW.BackColor = Color.Red;
            DRAW.FlatAppearance.BorderSize = 0;
            DRAW.FlatStyle = FlatStyle.Flat;
            DRAW.ForeColor = Color.White;
            DRAW.Location = new Point(349, 683);
            DRAW.Name = "DRAW";
            DRAW.Size = new Size(163, 79);
            DRAW.TabIndex = 9;
            DRAW.Text = "DRAW";
            DRAW.UseVisualStyleBackColor = false;
            DRAW.Click += DRAW_Click;
            // 
            // IMPORT
            // 
            IMPORT.BackColor = Color.Red;
            IMPORT.FlatAppearance.BorderSize = 0;
            IMPORT.FlatStyle = FlatStyle.Flat;
            IMPORT.ForeColor = Color.White;
            IMPORT.Location = new Point(349, 768);
            IMPORT.Name = "IMPORT";
            IMPORT.Size = new Size(163, 79);
            IMPORT.TabIndex = 10;
            IMPORT.Text = "IMPORT";
            IMPORT.UseVisualStyleBackColor = false;
            IMPORT.Click += IMPORT_Click;
            // 
            // SAVE
            // 
            SAVE.BackColor = Color.Red;
            SAVE.FlatAppearance.BorderSize = 0;
            SAVE.FlatStyle = FlatStyle.Flat;
            SAVE.ForeColor = Color.White;
            SAVE.Location = new Point(349, 853);
            SAVE.Name = "SAVE";
            SAVE.Size = new Size(163, 79);
            SAVE.TabIndex = 11;
            SAVE.Text = "SAVE";
            SAVE.UseVisualStyleBackColor = false;
            SAVE.Click += SAVE_Click;
            // 
            // GEOWALL_E
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1882, 953);
            Controls.Add(SAVE);
            Controls.Add(IMPORT);
            Controls.Add(DRAW);
            Controls.Add(IMAGEN_WALLE);
            Controls.Add(WALLE_E_NOMBRE);
            Controls.Add(IMAGEN_WALL_E_NOMBRE);
            Controls.Add(PANEL_DIBUJO);
            Controls.Add(PANEL_COMANDOS);
            Name = "GEOWALL_E";
            Text = "GEOWALL-E";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)PANEL_DIBUJO).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox PANEL_COMANDOS;
        private PictureBox PANEL_DIBUJO;
        private Label IMAGEN_WALL_E_NOMBRE;
        private Label WALLE_E_NOMBRE;
        private Label IMAGEN_WALLE;
        private Boton_personalizado DRAW;
        private Boton_personalizado IMPORT;
        private Boton_personalizado SAVE;
    }
}