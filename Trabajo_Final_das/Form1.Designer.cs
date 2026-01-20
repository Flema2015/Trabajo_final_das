namespace Trabajo_Final_das
{
    partial class Form1
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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            agregarProductoToolStripMenuItem = new ToolStripMenuItem();
            eliminarProductoToolStripMenuItem = new ToolStripMenuItem();
            modificarProductoToolStripMenuItem = new ToolStripMenuItem();
            disponibilidadDeProductosToolStripMenuItem = new ToolStripMenuItem();
            categoriasDeProductosToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            generarFacturasToolStripMenuItem = new ToolStripMenuItem();
            inventarioToolStripMenuItem = new ToolStripMenuItem();
            gestiónProductosToolStripMenuItem = new ToolStripMenuItem();
            reportesDeVentasPorPeriodoToolStripMenuItem = new ToolStripMenuItem();
            prodcutosMásVendidosToolStripMenuItem = new ToolStripMenuItem();
            estadoDeCuentasCorrientesDeClientesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, gestiónProductosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(901, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { agregarProductoToolStripMenuItem, eliminarProductoToolStripMenuItem, modificarProductoToolStripMenuItem, disponibilidadDeProductosToolStripMenuItem, categoriasDeProductosToolStripMenuItem });
            toolStripMenuItem1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(150, 24);
            toolStripMenuItem1.Text = "Gestión Productos";
            // 
            // agregarProductoToolStripMenuItem
            // 
            agregarProductoToolStripMenuItem.Name = "agregarProductoToolStripMenuItem";
            agregarProductoToolStripMenuItem.Size = new Size(274, 24);
            agregarProductoToolStripMenuItem.Text = "Agregar Productos";
            agregarProductoToolStripMenuItem.Click += agregarProductoToolStripMenuItem_Click;
            // 
            // eliminarProductoToolStripMenuItem
            // 
            eliminarProductoToolStripMenuItem.Name = "eliminarProductoToolStripMenuItem";
            eliminarProductoToolStripMenuItem.Size = new Size(274, 24);
            eliminarProductoToolStripMenuItem.Text = "Eliminar Productos";
            eliminarProductoToolStripMenuItem.Click += eliminarProductoToolStripMenuItem_Click;
            // 
            // modificarProductoToolStripMenuItem
            // 
            modificarProductoToolStripMenuItem.Name = "modificarProductoToolStripMenuItem";
            modificarProductoToolStripMenuItem.Size = new Size(274, 24);
            modificarProductoToolStripMenuItem.Text = "Modificar Productos";
            modificarProductoToolStripMenuItem.Click += modificarProductoToolStripMenuItem_Click;
            // 
            // disponibilidadDeProductosToolStripMenuItem
            // 
            disponibilidadDeProductosToolStripMenuItem.Name = "disponibilidadDeProductosToolStripMenuItem";
            disponibilidadDeProductosToolStripMenuItem.Size = new Size(274, 24);
            disponibilidadDeProductosToolStripMenuItem.Text = "Disponibilidad de Productos";
            disponibilidadDeProductosToolStripMenuItem.Click += disponibilidadDeProductosToolStripMenuItem_Click;
            // 
            // categoriasDeProductosToolStripMenuItem
            // 
            categoriasDeProductosToolStripMenuItem.Name = "categoriasDeProductosToolStripMenuItem";
            categoriasDeProductosToolStripMenuItem.Size = new Size(274, 24);
            categoriasDeProductosToolStripMenuItem.Text = "Categorias de Productos";
            categoriasDeProductosToolStripMenuItem.Click += categoriasDeProductosToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripMenuItem2.ImageAlign = ContentAlignment.BottomLeft;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(134, 24);
            toolStripMenuItem2.Text = "Gestión Clientes";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { generarFacturasToolStripMenuItem, inventarioToolStripMenuItem });
            toolStripMenuItem3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(126, 24);
            toolStripMenuItem3.Text = "Gestión Ventas";
            // 
            // generarFacturasToolStripMenuItem
            // 
            generarFacturasToolStripMenuItem.Name = "generarFacturasToolStripMenuItem";
            generarFacturasToolStripMenuItem.Size = new Size(197, 24);
            generarFacturasToolStripMenuItem.Text = "Generar Facturas";
            // 
            // inventarioToolStripMenuItem
            // 
            inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            inventarioToolStripMenuItem.Size = new Size(197, 24);
            inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // gestiónProductosToolStripMenuItem
            // 
            gestiónProductosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reportesDeVentasPorPeriodoToolStripMenuItem, prodcutosMásVendidosToolStripMenuItem, estadoDeCuentasCorrientesDeClientesToolStripMenuItem });
            gestiónProductosToolStripMenuItem.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gestiónProductosToolStripMenuItem.Name = "gestiónProductosToolStripMenuItem";
            gestiónProductosToolStripMenuItem.Size = new Size(168, 24);
            gestiónProductosToolStripMenuItem.Text = "Reportes y Consultas";
            // 
            // reportesDeVentasPorPeriodoToolStripMenuItem
            // 
            reportesDeVentasPorPeriodoToolStripMenuItem.Name = "reportesDeVentasPorPeriodoToolStripMenuItem";
            reportesDeVentasPorPeriodoToolStripMenuItem.Size = new Size(356, 24);
            reportesDeVentasPorPeriodoToolStripMenuItem.Text = "Reportes de ventas";
            // 
            // prodcutosMásVendidosToolStripMenuItem
            // 
            prodcutosMásVendidosToolStripMenuItem.Name = "prodcutosMásVendidosToolStripMenuItem";
            prodcutosMásVendidosToolStripMenuItem.Size = new Size(356, 24);
            prodcutosMásVendidosToolStripMenuItem.Text = "Prodcutos más vendidos";
            // 
            // estadoDeCuentasCorrientesDeClientesToolStripMenuItem
            // 
            estadoDeCuentasCorrientesDeClientesToolStripMenuItem.Name = "estadoDeCuentasCorrientesDeClientesToolStripMenuItem";
            estadoDeCuentasCorrientesDeClientesToolStripMenuItem.Size = new Size(356, 24);
            estadoDeCuentasCorrientesDeClientesToolStripMenuItem.Text = "Estado de cuentas corrientes de clientes";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 474);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem gestiónProductosToolStripMenuItem;
        private ToolStripMenuItem agregarProductoToolStripMenuItem;
        private ToolStripMenuItem eliminarProductoToolStripMenuItem;
        private ToolStripMenuItem modificarProductoToolStripMenuItem;
        private ToolStripMenuItem disponibilidadDeProductosToolStripMenuItem;
        private ToolStripMenuItem categoriasDeProductosToolStripMenuItem;
        private ToolStripMenuItem generarFacturasToolStripMenuItem;
        private ToolStripMenuItem inventarioToolStripMenuItem;
        private ToolStripMenuItem reportesDeVentasPorPeriodoToolStripMenuItem;
        private ToolStripMenuItem prodcutosMásVendidosToolStripMenuItem;
        private ToolStripMenuItem estadoDeCuentasCorrientesDeClientesToolStripMenuItem;
    }
}
