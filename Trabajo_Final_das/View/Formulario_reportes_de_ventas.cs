using Microsoft.EntityFrameworkCore.Query.Internal;
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
    public partial class Formulario_reportes_de_ventas : Form
    {
        private Ventas_controller ventas_Controller;
        private Producto_contoller controlador_productos;
        
        public Formulario_reportes_de_ventas()
        {
            ventas_Controller = new Ventas_controller();
            controlador_productos = new Producto_contoller();
            InitializeComponent();
            cargar_combos();
        }

        private void Formulario_reportes_de_ventas_Load(object sender, EventArgs e)
        {

        }
        private void cargar_combos()
        {
            var productos = controlador_productos.Obtener_productos();


            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Codigo_producto";
            cmbProducto.SelectedIndex = -1; // Nada seleccionado al inicio
            CmbSucursal.Items.AddRange(new object[] { "Sucursal Central", "Sucursal Norte", "Sucursal Sur" });
        }
        private void actualizarGrilla(object dataSource)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataSource;
        }

        public void cargar_grilla(DateTime fechaDesde)
        {
            try
            {
                var lista = ventas_Controller.obtener_ventas_recientes(fechaDesde);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }
        private void calcular_filtrar()
        {
            DateTime Fecha_filtro;
            if (radiobutton7dias.Checked)
            {
                Fecha_filtro = DateTime.Now.AddDays(-7);


            }
            else if (radiobutton15dias.Checked)
            {
                Fecha_filtro = DateTime.Now.AddDays(-15);
            }
            else if (radioButton30dias.Checked)
            {
                Fecha_filtro = DateTime.Now.AddDays(-30);
            }
            else
            {
                Fecha_filtro = DateTime.MinValue;
            }
            cargar_grilla(Fecha_filtro);
        }
        private void EventoFiltro_CheckedChanged(object sender, EventArgs e)
        {
            // Validamos que el sender sea un RadioButton y que esté CHECKED
            // (Porque el evento se dispara dos veces: una para el que se desmarca y otra para el que se marca)
            RadioButton rbt = sender as RadioButton;

            if (rbt != null && rbt.Checked)
            {
                calcular_filtrar();
            }
        }


        private void grupoboxMovimientos_Enter(object sender, EventArgs e)
        {

        }

        private void radiobutton7dias_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton7dias.Checked)
            {
                calcular_filtrar();
            }
        }

        private void radiobutton15dias_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton15dias.Checked)
            {
                calcular_filtrar();
            }
        }

        private void radioButton30dias_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton30dias.Checked)
            {
                calcular_filtrar();
            }
        }
        private void filtro_producto_elegido(object sender, EventArgs e)
        {
            CmbSucursal.SelectedIndex = -1;
            
            if (cmbProducto.SelectedValue != null)
            {
                string id_producto = cmbProducto.SelectedValue.ToString();
                var lista = ventas_Controller.ObtenerVentasFiltradas(productoId: id_producto);
                actualizarGrilla(lista);
            }
        }
        private void filtro_sucursal_elegido(object sender, EventArgs e)
        {
            cmbProducto.SelectedIndex = -1;
            
            if (CmbSucursal.SelectedItem != null)
            {
                string nombre_sucursal = CmbSucursal.SelectedItem.ToString();
                var lista = ventas_Controller.ObtenerVentasFiltradas(sucursal: nombre_sucursal);
                actualizarGrilla(lista);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
   
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbProducto.SelectedIndex = -1;
            CmbSucursal.SelectedIndex = -1;
            dataGridView1.DataSource = null;
        }
    }
}
