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
    public partial class Formulario_Registrar_clientes : Form
    {
        private Label lblNombre;
        private TextBox txtNombre;

        private Label lblApellido;
        private TextBox txtApellido;

        private Label lblTipo;
        private ComboBox cboTipo;

        private Button btnGuardar;
        private Button btnCancelar;

        // --- VARIABLES LÓGICAS ---
        private Cliente_controller controlador;
        private int? id_cliente_editar; // Null = Crear Nuevo
        public Formulario_Registrar_clientes(int? id_editar = null)
        {
            controlador = new Cliente_controller();
            id_cliente_editar = id_editar;
            this.Text = id_editar == null ? "Nuevo Cliente" : "Editar Cliente";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            InicializarComponentes();
            if (id_cliente_editar != null)
            {
                cargar_datos();
            }
        }
        private void InicializarComponentes()
        {
            int y = 20;
            int xLabel = 20;
            int xControl = 120;
            int ancho = 200;
            int salto = 45;

            // 1. NOMBRE
            lblNombre = new Label { Text = "Nombre:", Location = new Point(xLabel, y), AutoSize = true };
            txtNombre = new TextBox { Location = new Point(xControl, y - 3), Width = ancho };
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);

            y += salto;

            // 2. APELLIDO
            lblApellido = new Label { Text = "Apellido:", Location = new Point(xLabel, y), AutoSize = true };
            txtApellido = new TextBox { Location = new Point(xControl, y - 3), Width = ancho };
            this.Controls.Add(lblApellido);
            this.Controls.Add(txtApellido);

            y += salto;

            // 3. TIPO (COMBOBOX)
            lblTipo = new Label { Text = "Tipo Cliente:", Location = new Point(xLabel, y), AutoSize = true };
            cboTipo = new ComboBox
            {
                Location = new Point(xControl, y - 3),
                Width = ancho,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Cargar opciones manualmente usando un truco de Clave/Valor
            // Creamos una lista anónima o Dictionary para mapear Texto -> Valor
            var opciones = new[] {
            new { Text = "Minorista", Value = 0 },
            new { Text = "Mayorista", Value = 1 }
        };

            cboTipo.DataSource = opciones;
            cboTipo.DisplayMember = "Text";  // Lo que se ve
            cboTipo.ValueMember = "Value";   // Lo que vale por detrás (0 o 1)

            this.Controls.Add(lblTipo);
            this.Controls.Add(cboTipo);

            y += salto * 2;

            // 4. BOTONES
            btnGuardar = new Button { Text = "Guardar", Location = new Point(xControl - 20, y), Width = 90, BackColor = Color.LightGreen };
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = new Button { Text = "Cancelar", Location = new Point(xControl + 100, y), Width = 90 };
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnCancelar);
        }
        private void cargar_datos()
        {
            var cliente = controlador.Obtener_clientes_por_id(id_cliente_editar.Value);
            if (cliente != null)
            {
                txtNombre.Text = cliente.NombreCliente;
                txtApellido.Text = cliente.ApellidoCliente;

                // Magia del ValueMember: al ponerle el int, selecciona el texto correcto solo
                cboTipo.SelectedValue = cliente.TipoCliente;
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Nombre y Apellido son obligatorios.");
                return;
            }

            // Crear Objeto
            Cliente c = new Cliente
            {
                IdCliente = id_cliente_editar ?? 0, // Si es null usa 0 (nuevo)
                NombreCliente = txtNombre.Text,
                ApellidoCliente = txtApellido.Text,
                TipoCliente = (int)cboTipo.SelectedValue // Convertimos el value del combo a int
            };
            try
            {
                if (id_cliente_editar != null)
                {
                    controlador.Modificar_cliente(c);
                }
                else
                {
                    controlador.Crear_cliente(c);
                }
                MessageBox.Show("DATOS GUARDADOSSSS");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
           
           
        }

        private void Formulario_Registrar_clientes_Load(object sender, EventArgs e)
        {

        }
    }
}
