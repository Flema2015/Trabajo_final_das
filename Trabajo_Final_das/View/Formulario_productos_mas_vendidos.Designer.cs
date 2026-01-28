namespace Trabajo_Final_das.View
{
    partial class Formulario_productos_mas_vendidos
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
            dgtproductos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgtproductos).BeginInit();
            SuspendLayout();
            // 
            // dgtproductos
            // 
            dgtproductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtproductos.Location = new Point(12, 31);
            dgtproductos.Name = "dgtproductos";
            dgtproductos.Size = new Size(928, 444);
            dgtproductos.TabIndex = 0;
            dgtproductos.CellContentClick += dgtproductos_CellContentClick;
            // 
            // Formulario_productos_mas_vendidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 487);
            Controls.Add(dgtproductos);
            Name = "Formulario_productos_mas_vendidos";
            Text = "Formulario_productos_mas_vendidos";
            Load += Formulario_productos_mas_vendidos_Load;
            ((System.ComponentModel.ISupportInitialize)dgtproductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgtproductos;
    }
}