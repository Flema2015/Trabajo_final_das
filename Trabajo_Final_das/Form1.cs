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
    }
}
