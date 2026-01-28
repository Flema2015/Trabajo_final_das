using Trabajo_Final_das.View;
namespace Trabajo_Final_das
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario_alta_producto frm = new Formulario_alta_producto();
            frm.MdiParent = this;
            frm.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario_Eliminar_Modificar_productos frm = new Formulario_Eliminar_Modificar_productos("BORRAR");
            frm.MdiParent = this;
            frm.Show();
        }

        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario_Eliminar_Modificar_productos frm = new Formulario_Eliminar_Modificar_productos("EDITAR");
            frm.MdiParent = this;
            frm.Show();
        }

        private void disponibilidadDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos_por_sucursal frm = new Productos_por_sucursal();
            frm.MdiParent = this;
            frm.Show();
        }

        private void categoriasDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario_Categorias frm = new Formulario_Categorias();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario_Registrar_clientes frm = new Formulario_Registrar_clientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario_modificar_cliente frm = new Formulario_modificar_cliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void historialClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario_historial_cliente frm = new Formulario_historial_cliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void generarFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario_generar_factura frm = new Formulario_generar_factura();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportesDeVentasPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario_reportes_de_ventas frm = new Formulario_reportes_de_ventas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void prodcutosMásVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario_productos_mas_vendidos frm = new Formulario_productos_mas_vendidos();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
