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
    public partial class Formulario_Eliminar_Modificar_productos : Form
    {
        private DataGridView dgvProductos;
        private Button btnAccion; // Este botón cambiará de función
        private Button btnCancelar;
        private TextBox txtBuscar; // Un plus: buscador rápido
        private Label lblBuscar;

        // Lógica
        private Producto_contoller controlador;
        private string _modo; // "EDITAR" o "BORRAR"

        public Formulario_Eliminar_Modificar_productos(string modo)
        {
            controlador = new Producto_contoller();
            _modo = modo;

            // Configuración de la ventana
            this.Text = _modo == "EDITAR" ? "Seleccione para Editar" : "Seleccione para Eliminar";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow; // Ventana flotante simple

            InicializarComponentes();
            Cargar_Grilla();
        }
        private void InicializarComponentes()
        {
            // 1. Panel Superior (Buscador)
            Panel panelTop = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.WhiteSmoke };

            lblBuscar = new Label { Text = "Buscar:", Location = new Point(15, 18), AutoSize = true };
            txtBuscar = new TextBox { Location = new Point(70, 15), Width = 300 };
            txtBuscar.TextChanged += (s, e) => Filtrar_Grilla(); // Evento para buscar mientras escribes

            panelTop.Controls.Add(lblBuscar);
            panelTop.Controls.Add(txtBuscar);
            this.Controls.Add(panelTop);

            // 2. Panel Inferior (Botones)
            Panel panelBottom = new Panel { Dock = DockStyle.Bottom, Height = 60, BackColor = Color.WhiteSmoke };

            btnAccion = new Button
            {
                Location = new Point(380, 15),
                Size = new Size(100, 35),
                UseVisualStyleBackColor = true
            };

            // Personalizamos el botón según el modo
            if (_modo == "EDITAR")
            {
                btnAccion.Text = "Modificar";
                btnAccion.BackColor = Color.LightBlue;
            }
            else // BORRAR
            {
                btnAccion.Text = "Eliminar";
                btnAccion.BackColor = Color.LightCoral;
            }
            btnAccion.Click += BtnAccion_Click; // El evento mágico

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(490, 15),
                Size = new Size(80, 35)
            };
            btnCancelar.Click += (s, e) => this.Close();

            panelBottom.Controls.Add(btnAccion);
            panelBottom.Controls.Add(btnCancelar);
            this.Controls.Add(panelBottom);

            // 3. La Grilla (Al medio)
            dgvProductos = new DataGridView();
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.AllowUserToAddRows = false;

            // Doble clic para acción rápida
            dgvProductos.DoubleClick += BtnAccion_Click;

            this.Controls.Add(dgvProductos);
            dgvProductos.BringToFront(); // Traer al frente para que no lo tapen los paneles
        }

        private void Cargar_Grilla()
        {
            var lista = controlador.Obtener_productos();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = lista;

        }

        // Método simple para buscar (filtra en memoria)
        private void Filtrar_Grilla()
        {
            // Esto es un truco rápido para filtrar sin ir a la DB cada vez
            var listaCompleta = controlador.Obtener_productos();
            var texto = txtBuscar.Text.ToLower();

            var listaFiltrada = listaCompleta.FindAll(p =>
                p.Nombre.ToLower().Contains(texto) ||
                p.Codigo_producto.ToLower().Contains(texto)
            );

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaFiltrada;
        }

        // --- LA LÓGICA DE LOS BOTONES ---
        private void BtnAccion_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un producto de la lista.");
                return;
            }

            // 1. Obtenemos el ID seleccionados
            string idSeleccionado = (string)dgvProductos.SelectedRows[0].Cells["Codigo_producto"].Value;

            if (_modo == "EDITAR")
            {
                // ABRIR EL FORMULARIO DE EDICIÓN
                // Pasamos el ID al formulario que hicimos antes
                Formulario_alta_producto frmEditar = new Formulario_alta_producto(idSeleccionado);
                frmEditar.MdiParent = this.MdiParent; // Truco: Usamos el mismo padre MDI
                frmEditar.Show();

                // Cerramos esta ventana de búsqueda porque ya cumplió su función
                Cargar_Grilla();
                this.Close();
            }
            else if (_modo == "BORRAR")
            {
                // CONFIRMAR Y ELIMINAR
                var respuesta = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        controlador.Eliminar_producto(idSeleccionado);
                        MessageBox.Show("Producto eliminado.");
                        Cargar_Grilla(); // Refrescamos la lista por si quiere borrar otro
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
        }


        private void Formulario_Eliminar_Modificar_productos_Load(object sender, EventArgs e)
        {

        }
    }
}
