using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_das.Controller;

namespace Trabajo_Final_das.View
{
    public partial class Formulario_modificar_cliente : Form
    {
        private Cliente_controller controlador;
        public Formulario_modificar_cliente()
        {
            controlador = new Cliente_controller();
            InitializeComponent();
            cargar_grilla();
        }

        private void Formulario_modificar_cliente_Load(object sender, EventArgs e)
        {
            //cargar_grilla();
        }
        private void cargar_grilla()
        {
            var lista = controlador.Obtener_todos();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id_seleccionado = (int)dataGridView1.SelectedRows[0].Cells["IdCliente"].Value;
                Formulario_Registrar_clientes frm = new Formulario_Registrar_clientes(id_seleccionado);
                frm.Show();

                cargar_grilla();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para editar.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
