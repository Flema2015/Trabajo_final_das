
namespace Trabajo_Final_das.View
{
    partial class Formulario_reportes_de_ventas
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
            dataGridView1 = new DataGridView();
            radiobutton7dias = new RadioButton();
            radiobutton15dias = new RadioButton();
            radioButton30dias = new RadioButton();
            grupoboxMovimientos = new GroupBox();
            cmbProducto = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            CmbSucursal = new ComboBox();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            grupoboxMovimientos.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 103);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(992, 480);
            dataGridView1.TabIndex = 0;
            // 
            // radiobutton7dias
            // 
            radiobutton7dias.AutoSize = true;
            radiobutton7dias.Location = new Point(6, 13);
            radiobutton7dias.Name = "radiobutton7dias";
            radiobutton7dias.Size = new Size(145, 19);
            radiobutton7dias.TabIndex = 1;
            radiobutton7dias.TabStop = true;
            radiobutton7dias.Text = "Movimientos ult.7 días";
            radiobutton7dias.UseVisualStyleBackColor = true;
            radiobutton7dias.CheckedChanged += radiobutton7dias_CheckedChanged;
            // 
            // radiobutton15dias
            // 
            radiobutton15dias.AutoSize = true;
            radiobutton15dias.Location = new Point(6, 38);
            radiobutton15dias.Name = "radiobutton15dias";
            radiobutton15dias.Size = new Size(151, 19);
            radiobutton15dias.TabIndex = 2;
            radiobutton15dias.TabStop = true;
            radiobutton15dias.Text = "Movimientos ult.15 días";
            radiobutton15dias.UseVisualStyleBackColor = true;
            radiobutton15dias.CheckedChanged += radiobutton15dias_CheckedChanged;
            // 
            // radioButton30dias
            // 
            radioButton30dias.AutoSize = true;
            radioButton30dias.Location = new Point(6, 63);
            radioButton30dias.Name = "radioButton30dias";
            radioButton30dias.Size = new Size(151, 19);
            radioButton30dias.TabIndex = 3;
            radioButton30dias.TabStop = true;
            radioButton30dias.Text = "Movimientos ult.30 días";
            radioButton30dias.UseVisualStyleBackColor = true;
            radioButton30dias.CheckedChanged += radioButton30dias_CheckedChanged;
            // 
            // grupoboxMovimientos
            // 
            grupoboxMovimientos.Controls.Add(radioButton30dias);
            grupoboxMovimientos.Controls.Add(radiobutton7dias);
            grupoboxMovimientos.Controls.Add(radiobutton15dias);
            grupoboxMovimientos.Location = new Point(12, -1);
            grupoboxMovimientos.Name = "grupoboxMovimientos";
            grupoboxMovimientos.Size = new Size(189, 98);
            grupoboxMovimientos.TabIndex = 4;
            grupoboxMovimientos.TabStop = false;
            grupoboxMovimientos.Enter += grupoboxMovimientos_Enter;
            // 
            // cmbProducto
            // 
            cmbProducto.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(422, 45);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(150, 29);
            cmbProducto.TabIndex = 5;
            cmbProducto.SelectedIndexChanged += filtro_producto_elegido;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(207, 45);
            label1.Name = "label1";
            label1.Size = new Size(191, 25);
            label1.TabIndex = 6;
            label1.Text = "Filtrar por producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(590, 45);
            label2.Name = "label2";
            label2.Size = new Size(182, 25);
            label2.TabIndex = 8;
            label2.Text = "Filtrar por Sucursal";
            label2.Click += label2_Click;
            // 
            // CmbSucursal
            // 
            CmbSucursal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSucursal.FormattingEnabled = true;
            CmbSucursal.Location = new Point(778, 45);
            CmbSucursal.Name = "CmbSucursal";
            CmbSucursal.Size = new Size(143, 29);
            CmbSucursal.TabIndex = 7;
            CmbSucursal.SelectedIndexChanged += filtro_sucursal_elegido;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(927, 12);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(77, 85);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // Formulario_reportes_de_ventas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 595);
            Controls.Add(btnLimpiar);
            Controls.Add(label2);
            Controls.Add(CmbSucursal);
            Controls.Add(label1);
            Controls.Add(cmbProducto);
            Controls.Add(dataGridView1);
            Controls.Add(grupoboxMovimientos);
            Name = "Formulario_reportes_de_ventas";
            Text = "Formulario_reportes_de_ventas";
            Load += Formulario_reportes_de_ventas_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            grupoboxMovimientos.ResumeLayout(false);
            grupoboxMovimientos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private DataGridView dataGridView1;
        private RadioButton radiobutton7dias;
        private RadioButton radiobutton15dias;
        private RadioButton radioButton30dias;
        private GroupBox grupoboxMovimientos;
        private ComboBox cmbProducto;
        private Label label1;
        private Label label2;
        private ComboBox CmbSucursal;
        private Button btnLimpiar;
    }
}