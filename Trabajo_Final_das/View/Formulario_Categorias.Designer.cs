namespace Trabajo_Final_das.View
{
    partial class Formulario_Categorias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstCategorias = new ListBox();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnVer_categorias = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lstCategorias
            // 
            lstCategorias.FormattingEnabled = true;
            lstCategorias.ItemHeight = 15;
            lstCategorias.Location = new Point(12, 78);
            lstCategorias.Name = "lstCategorias";
            lstCategorias.Size = new Size(776, 349);
            lstCategorias.TabIndex = 0;
            lstCategorias.SelectedIndexChanged += lstCategorias_SelectedIndexChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(12, 22);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(110, 40);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Renombrar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(185, 22);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 40);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnVer_categorias
            // 
            btnVer_categorias.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVer_categorias.Location = new Point(360, 22);
            btnVer_categorias.Name = "btnVer_categorias";
            btnVer_categorias.Size = new Size(133, 40);
            btnVer_categorias.TabIndex = 4;
            btnVer_categorias.Text = "Ver Categorias";
            btnVer_categorias.UseVisualStyleBackColor = true;
            btnVer_categorias.Click += btnVer_categorias_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(708, 22);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(80, 40);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // Formulario_Categorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnVer_categorias);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(lstCategorias);
            Name = "Formulario_Categorias";
            Text = "Formulario_Categorias";
            Load += Formulario_Categorias_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstCategorias;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnVer_categorias;
        private Button btnSalir;
    }
}