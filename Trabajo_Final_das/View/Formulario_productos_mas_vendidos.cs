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
    public partial class Formulario_productos_mas_vendidos : Form
    {
        private Ventas_controller ventas_Controller;
        public Formulario_productos_mas_vendidos()
        {
            ventas_Controller = new Ventas_controller();
            InitializeComponent();
            cargar_grilla();
        }
        private void cargar_grilla()
        {
            try
            {
                var lista = ventas_Controller.ObtenerRankingProductos();
                dgtproductos.DataSource = lista;
                if (dgtproductos.Columns["TotalRecaudado"] != null)
                {
                    dgtproductos.Columns["TotalRecaudado"].DefaultCellStyle.Format = "C2"; 
                }

            }
            catch(Exception ex)
            {
                throw new Exception("Error al cargar productos");
            }
        }
        private void dgtproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Formulario_productos_mas_vendidos_Load(object sender, EventArgs e)
        {

        }
    }
}
