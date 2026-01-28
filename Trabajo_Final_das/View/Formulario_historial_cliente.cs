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
using Trabajo_Final_das.Models;

namespace Trabajo_Final_das.View
{
    public partial class Formulario_historial_cliente : Form
    {
        private Cliente_controller controlador;
        private Ventas_controller ventasController = new Ventas_controller();
        public Formulario_historial_cliente()
        {
            controlador = new Cliente_controller();
            InitializeComponent();
            cargar_datos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void cargar_datos()
        {

            var clientes = controlador.Obtener_todos();


            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "Nombre_completo";
            cmbCliente.ValueMember = "IdCliente";
            cmbCliente.SelectedIndex = -1; // Nada seleccionado al inicio
            dataGridView1.DataSource = null;
            lblTotal.Text = "Total Gastado: $0.00";
            //cmbCliente.SelectionChangeCommitted += new EventHandler(CboClientes_SelectionChangeCommitted);
            


        }
        private void Formulario_historial_cliente_Load(object sender, EventArgs e)
        {

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1 || cmbCliente.SelectedValue == null) return;


            Cliente cliente = (Cliente)cmbCliente.SelectedItem;
            //int cliente_id = cliente.IdCliente;
            Cargar_Historial_Ventas(cliente.IdCliente);

        }
        
        private void Cargar_Historial_Ventas(int clienteId)
        {
            try
            {
                // 1. Pedimos los datos "cocinados" al controlador
                var datos = ventasController.Obtener_Historial_Por_Cliente(clienteId);

                // 2. Refrescamos la grilla
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = datos;


                decimal total = controlador.ObtenerTotalGastadoPorCliente(clienteId);
                lblTotal.Text = $"Total Gastado: ${total:N2}";
                
                // Opcional: Si no hay datos, avisar
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Este cliente no tiene compras registradas.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
        }
        //private void CboClientes_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    // Este evento ocurre SOLO cuando el usuario hace clic (evita errores de carga)
        //    if (cmbCliente.SelectedValue != null)
        //    {
        //        int idCliente = (int)cmbCliente.SelectedValue;
        //        Cargar_Historial_Ventas(idCliente);
        //    }
        //}

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
