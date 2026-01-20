namespace Trabajo_Final_das.View
{
    partial class Productos_por_sucursal
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
            dtgFiltrar_por_sucursal = new DataGridView();
            cmbSucursal = new ComboBox();
            label1 = new Label();
            btnSalir = new Button();
            label2 = new Label();
            cmbProductos = new ComboBox();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgFiltrar_por_sucursal).BeginInit();
            SuspendLayout();
            // 
            // dtgFiltrar_por_sucursal
            // 
            dtgFiltrar_por_sucursal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgFiltrar_por_sucursal.Location = new Point(2, 62);
            dtgFiltrar_por_sucursal.Name = "dtgFiltrar_por_sucursal";
            dtgFiltrar_por_sucursal.Size = new Size(795, 381);
            dtgFiltrar_por_sucursal.TabIndex = 0;
            // 
            // cmbSucursal
            // 
            cmbSucursal.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(379, 22);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(121, 28);
            cmbSucursal.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(275, 25);
            label1.Name = "label1";
            label1.Size = new Size(74, 21);
            label1.TabIndex = 2;
            label1.Text = "Sucursal";
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(650, 19);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(76, 33);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(36, 24);
            label2.Name = "label2";
            label2.Size = new Size(80, 21);
            label2.TabIndex = 4;
            label2.Text = "Producto";
            // 
            // cmbProductos
            // 
            cmbProductos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(130, 23);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(121, 28);
            cmbProductos.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(544, 19);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(76, 33);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Buscar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // Productos_por_sucursal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 455);
            Controls.Add(btnGuardar);
            Controls.Add(cmbProductos);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            Controls.Add(label1);
            Controls.Add(cmbSucursal);
            Controls.Add(dtgFiltrar_por_sucursal);
            Name = "Productos_por_sucursal";
            Text = "Productos_por_sucursal";
            Load += Productos_por_sucursal_Load;
            ((System.ComponentModel.ISupportInitialize)dtgFiltrar_por_sucursal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgFiltrar_por_sucursal;
        private ComboBox cmbSucursal;
        private Label label1;
        private Button btnSalir;
        private Label label2;
        private ComboBox cmbProductos;
        private Button btnGuardar;
    }
}