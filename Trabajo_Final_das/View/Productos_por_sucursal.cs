using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_das.Models;

namespace Trabajo_Final_das.View
{
    public partial class Productos_por_sucursal : Form
    {
        private TrabajoFinalDasContext contexto;
        public Productos_por_sucursal()
        {
            contexto = new TrabajoFinalDasContext();

            InitializeComponent();
        }


        private void cargar_sucursales_disponibles()
        {
            try
            {
                var lista_sucursales = contexto.Productos
                                       .Select(p => p.Sucursal)
                                       .Distinct()
                                       .ToList();
                cmbSucursal.Items.Clear();
                foreach (var suc in lista_sucursales)
                {
                    if (!string.IsNullOrEmpty(suc))
                    {
                        cmbSucursal.Items.Add(suc);
                    }
                }
                if (cmbSucursal.Items.Count > 0)
                    cmbSucursal.SelectedIndex = 0; // Selecciona el primero automáticamente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sucursales: " + ex.Message);
            }
        }

        private void cargar_productos_disponibles()
        {
            try
            {
                var lista_productos = contexto.Productos
                                       .Select(p => p.Nombre)
                                       .ToList();
                cmbProductos.Items.Clear();
                foreach (var producto in lista_productos)
                {
                    if (!string.IsNullOrEmpty(producto))
                    {
                        cmbProductos.Items.Add(producto);
                    }
                }
                if (cmbProductos.Items.Count > 0)
                    cmbProductos.SelectedIndex = 0; // Selecciona el primero automáticamente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sucursales: " + ex.Message);
            }


        }

        private void filtrar_grilla()
        {
            try
            {
                if (cmbSucursal.SelectedItem == null) return;
                string sucursal_elegida = cmbSucursal.SelectedItem.ToString();

                var consulta = contexto.Productos
                    .Where(p => p.Sucursal == sucursal_elegida && p.CantidadStock > 0)
                    .Select(p => new
                    {
                        p.Codigo_producto,
                        p.Nombre,
                        p.Descripcion,
                        p.Categoria,
                        p.Precio,
                        p.CantidadStock,
                        p.Sucursal,

                    }).ToList();

                dtgFiltrar_por_sucursal.DataSource = null;
                dtgFiltrar_por_sucursal.DataSource = consulta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar productos: " + ex.Message);
            }

        }
        private void Productos_por_sucursal_Load(object sender, EventArgs e)
        {
            cargar_sucursales_disponibles();
            cargar_productos_disponibles();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            filtrar_grilla();
        }
    }
}
