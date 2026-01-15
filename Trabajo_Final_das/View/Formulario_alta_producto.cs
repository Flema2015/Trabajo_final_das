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

namespace Trabajo_Final_das
{
    public partial class Formulario_alta_producto : Form
    {
        private int? codigo_producto_a_editar = null;

        public Formulario_alta_producto(int codigo_producto)
        {
            codigo_producto_a_editar = codigo_producto;
            Cargar_datos();
        }
        public Formulario_alta_producto()
        {

            controlador = new Producto_contoller();

            // Configuración básica del formulario
            this.Text = "Nuevo Producto";
            this.Size = new Size(450, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // No redimensionable
            this.MaximizeBox = false;
            InicializarComponentes();
        }
        // Definimos los controles como variables de clase
        private Label lblCodigo;
        private TextBox txtCodigo;

        private Label lblNombre;
        private TextBox txtNombre;

        private Label lblDescripcion;
        private TextBox txtDescripcion;

        private Label lblPrecio;
        private NumericUpDown numPrecio;

        private Label lblStock;
        private NumericUpDown numStock; // Nuevo campo por requerimiento

        private Label lblCategoria;
        private ComboBox cboCategoria; // Usamos combo aunque sea texto, es más prolijo

        private Button btnGuardar;
        private Button btnCancelar;

        // Controlador
        private Producto_contoller controlador;

        public void Cargar_datos()
        {
            Producto producto = controlador.Obtener_productos_por_id(codigo_producto_a_editar.Value);
            if (producto != null)
            {
                txtCodigo.Text = producto.Codigo_producto.ToString();
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;
                numPrecio.Value = (decimal)producto.Precio;
                numStock.Value = (decimal)producto.CantidadStock;
                cboCategoria.Text = producto.Categoria;
            }
        }

        private void InicializarComponentes()
        {
            int y = 20; // Coordenada vertical inicial
            int salto = 40; // Espacio entre renglones
            int labelX = 20;
            int controlX = 120;
            int anchoControl = 200;

            // --- CODIGO ---
            lblCodigo = new Label() { Text = "Código:", Location = new Point(labelX, y), AutoSize = true };
            txtCodigo = new TextBox() { Location = new Point(controlX, y), Width = anchoControl };
            this.Controls.Add(lblCodigo);
            this.Controls.Add(txtCodigo);

            y += salto; // Bajamos un renglón

            // --- NOMBRE ---
            lblNombre = new Label() { Text = "Nombre:", Location = new Point(labelX, y), AutoSize = true };
            txtNombre = new TextBox() { Location = new Point(controlX, y), Width = anchoControl };
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);

            y += salto;

            // --- DESCRIPCION ---
            lblDescripcion = new Label() { Text = "Descripción:", Location = new Point(labelX, y), AutoSize = true };
            txtDescripcion = new TextBox() { Location = new Point(controlX, y), Width = anchoControl };
            this.Controls.Add(lblDescripcion);
            this.Controls.Add(txtDescripcion);

            y += salto;

            // --- PRECIO ---
            lblPrecio = new Label() { Text = "Precio ($):", Location = new Point(labelX, y), AutoSize = true };
            numPrecio = new NumericUpDown() { Location = new Point(controlX, y), Width = anchoControl, DecimalPlaces = 2, Maximum = 9999999 };
            this.Controls.Add(lblPrecio);
            this.Controls.Add(numPrecio);

            y += salto;

            // --- STOCK (Requerimiento ) ---
            lblStock = new Label() { Text = "Stock Inicial:", Location = new Point(labelX, y), AutoSize = true };
            numStock = new NumericUpDown() { Location = new Point(controlX, y), Width = anchoControl, DecimalPlaces = 0, Maximum = 10000 };
            this.Controls.Add(lblStock);
            this.Controls.Add(numStock);

            y += salto;

            // --- CATEGORIA (Texto manual) ---
            lblCategoria = new Label() { Text = "Categoría:", Location = new Point(labelX, y), AutoSize = true };
            cboCategoria = new ComboBox() { Location = new Point(controlX, y), Width = anchoControl, DropDownStyle = ComboBoxStyle.DropDownList };
            // Llenamos manual ya que eliminamos la tabla
            cboCategoria.Items.AddRange(new object[] { "Electrónica", "Hogar", "Indumentaria", "Computación" });
            cboCategoria.SelectedIndex = 0;
            this.Controls.Add(lblCategoria);
            this.Controls.Add(cboCategoria);

            y += salto * 2; // Doble salto para los botones

            // --- BOTONES ---
            btnGuardar = new Button() { Text = "Guardar", Location = new Point(controlX, y), Width = 90, BackColor = Color.LightGreen };
            btnCancelar = new Button() { Text = "Cancelar", Location = new Point(controlX + 110, y), Width = 90 };

            // Conectar EVENTOS (Clicks)
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { this.Close(); }; // Lambda para cerrar rápido

            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnCancelar);
        }

        // Lógica del botón Guardar
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("Código y Nombre son obligatorios.");
                    return;
                }

                // Crear Objeto
                Producto p = new Producto
                {
                    Codigo_producto = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = numPrecio.Value,
                    CantidadStock = (int)numStock.Value, // Convertimos decimal a int
                    Categoria = cboCategoria.Text // Guardamos el texto seleccionado
                };
                if (codigo_producto_a_editar == null)
                {
                    controlador.Crear_producto(p);
                }
                else
                {
                    p.Codigo_producto = codigo_producto_a_editar.Value.ToString();
                    controlador.Modificar_producto(p);
                }


                MessageBox.Show("Producto registrado correctamente.");
                this.Close(); // Cerramos el formulario y volvemos al menú
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void Formulario_alta_producto_Load(object sender, EventArgs e)
        {

        }
    }
}
