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
    public partial class Formulario_generar_factura : Form
    {
        private ComboBox cboClientes;
        private ComboBox cboProductos;
        private ComboBox cboSucursal;
        private NumericUpDown numCantidad;
        private ComboBox cboMetodoPago;
        private Label lblPrecioUnitario;
        private Label lblTotal;
        private Label lblDescuentoInfo;
        private Button btnRegistrar;

        private Ventas_controller venta_Controller;
        private Cliente_controller cliente_Controller; // Para traer clientes
        private Producto_contoller producto_Controller; // Para traer productos

        // Variables para cálculo
        private decimal precio_Actual_Producto = 0;
        private bool esMayorista = false;
        public Formulario_generar_factura()
        {
            venta_Controller = new Ventas_controller();
            cliente_Controller = new Cliente_controller();
            producto_Controller = new Producto_contoller();

            this.Text = "Nueva Venta";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            InicializarComponentes();
            CargarCombos();
            //InitializeComponent();
        }
        private void InicializarComponentes()
        {
            int y = 20; int x = 30; int w = 250; int salto = 50;

            // 1. CLIENTE (Quién compra)
            this.Controls.Add(new Label { Text = "Cliente:", Location = new Point(x, y), AutoSize = true });
            cboClientes = new ComboBox { Location = new Point(x + 100, y - 3), Width = w, DropDownStyle = ComboBoxStyle.DropDownList };
            cboClientes.SelectionChangeCommitted += AlCambiarCliente; // Evento importante
            this.Controls.Add(cboClientes);

            y += salto;

            // 2. PRODUCTO (Qué compra)
            this.Controls.Add(new Label { Text = "Producto:", Location = new Point(x, y), AutoSize = true });
            cboProductos = new ComboBox { Location = new Point(x + 100, y - 3), Width = w, DropDownStyle = ComboBoxStyle.DropDownList };
            cboProductos.SelectionChangeCommitted += AlCambiarProducto; // Evento importante
            this.Controls.Add(cboProductos);

            y += salto;

            // 3. PRECIO UNITARIO (Informativo)
            this.Controls.Add(new Label { Text = "Precio Unit.:", Location = new Point(x, y), AutoSize = true });
            lblPrecioUnitario = new Label { Text = "$0.00", Location = new Point(x + 100, y), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
            this.Controls.Add(lblPrecioUnitario);

            y += salto;

            // 4. CANTIDAD
            this.Controls.Add(new Label { Text = "Cantidad:", Location = new Point(x, y), AutoSize = true });
            numCantidad = new NumericUpDown { Location = new Point(x + 100, y - 3), Width = 100, Minimum = 1, Maximum = 1000 };
            numCantidad.ValueChanged += (s, e) => Calcular_total(); // Recalcular al cambiar numero
            this.Controls.Add(numCantidad);

            y += salto;

            // 5. METODO PAGO
            this.Controls.Add(new Label { Text = "Pago:", Location = new Point(x, y), AutoSize = true });
            cboMetodoPago = new ComboBox { Location = new Point(x + 100, y - 3), Width = w, DropDownStyle = ComboBoxStyle.DropDownList };
            cboMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta de Débito", "Tarjeta de Crédito", "Transferencia" });
            cboMetodoPago.SelectedIndex = 0;
            this.Controls.Add(cboMetodoPago);

            y += salto;

            // Sucursal
            this.Controls.Add(new Label { Text = "Sucursal:", Location = new Point(x, y), AutoSize = true });
            cboSucursal = new ComboBox { Location = new Point(x + 100, y - 3), Width = w, DropDownStyle = ComboBoxStyle.DropDownList };
            cboSucursal.Items.AddRange(new object[] { "Sucursal Central", "Sucursal Sur", "Sucursal Norte"});
            cboSucursal.SelectedIndex = 0;
            this.Controls.Add(cboSucursal);

            y += salto;

            // 6. TOTAL Y DESCUENTO
            lblDescuentoInfo = new Label { Text = "", Location = new Point(x, y), AutoSize = true, ForeColor = Color.Green };
            this.Controls.Add(lblDescuentoInfo);

            y += 20;

            this.Controls.Add(new Label { Text = "TOTAL:", Location = new Point(x, y), AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold) });
            lblTotal = new Label { Text = "$0.00", Location = new Point(x + 100, y), AutoSize = true, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.Blue };
            this.Controls.Add(lblTotal);

            y += 60;

            // 7. BOTON
            btnRegistrar = new Button { Text = "CONFIRMAR VENTA", Location = new Point(x, y), Width = 350, Height = 40, BackColor = Color.LightGreen };
            btnRegistrar.Click += BtnRegistrar_Click;
            this.Controls.Add(btnRegistrar);
        }

        private void AlCambiarCliente(object sender, EventArgs e)
        {
            if (cboClientes.SelectedItem != null)
            {
                // Obtenemos el objeto Cliente completo del combo
                Cliente c = (Cliente)cboClientes.SelectedItem;

                // Verificamos si es Mayorista (1) o Minorista (0)
                esMayorista = (c.TipoCliente == 1);

                if (esMayorista)
                    lblDescuentoInfo.Text = "Cliente Mayorista: ¡20% de Descuento aplicado!";
                else
                    lblDescuentoInfo.Text = "Cliente Minorista: Precio de lista.";

                Calcular_total();
            }
        }
        private void CargarCombos()
        {
            // Clientes
            cboClientes.DataSource = cliente_Controller.Obtener_todos();
            cboClientes.DisplayMember = "Nombre_completo";
            cboClientes.ValueMember = "IdCliente";
            cboClientes.SelectedIndex = -1;

            // Productos
            cboProductos.DataSource = producto_Controller.Obtener_productos();
            cboProductos.DisplayMember = "Nombre";
            cboProductos.ValueMember = "Codigo_producto"; // Ojo: Debe ser la propiedad string del código
            cboProductos.SelectedIndex = -1;


        }
        private void AlCambiarProducto(object sender, EventArgs e)
        {
            if (cboProductos.SelectedItem != null)
            {
                // Obtenemos el objeto Producto completo
                Producto p = (Producto)cboProductos.SelectedItem;

                precio_Actual_Producto = (decimal)p.Precio; // Guardamos el precio en memoria
                lblPrecioUnitario.Text = $"${precio_Actual_Producto:N2}"; // Mostramos lindo

                Calcular_total();
            }
        }
        
        private void Calcular_total()
        {
            decimal subtotal = precio_Actual_Producto * numCantidad.Value;

            if (esMayorista)
            {
                subtotal = subtotal * 0.90m;
            }
            lblTotal.Text = $"${subtotal:N2}";
        }
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (cboClientes.SelectedValue == null || cboProductos.SelectedValue == null)
            {
                MessageBox.Show("Seleccione Cliente y Producto.");
                return;
            }

            try
            {
                // Calculamos el total final una vez más para estar seguros
                decimal precioFinal = precio_Actual_Producto * numCantidad.Value;
                if (esMayorista) precioFinal *= 0.80m;

                // Creamos el objeto
                Venta v = new Venta
                {
                    IdCliente = (int)cboClientes.SelectedValue,
                    codigo_producto = cboProductos.SelectedValue.ToString(),
                    MetodosDePago = cboMetodoPago.Text,
                    Total_final = precioFinal,
                    Sucursal = cboSucursal.SelectedItem.ToString(), 
                    stock_venta = (int)numCantidad.Value, // O podrías poner un combo de sucursales también
                    // La fecha se pone sola en el controller (DateTime.Now)
                };

                // Guardamos (Esto también descuenta stock)
                venta_Controller.Confirmar_venta(v);

                MessageBox.Show("¡Venta registrada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;

                // 2. Si hay un "InnerException" (la causa raiz), lo agregamos al mensaje
                if (ex.InnerException != null)
                {
                    mensajeError += "\n\n--- DETALLE TÉCNICO ---\n" + ex.InnerException.Message;

                    // A veces hay un tercer nivel de error (muy comun en SQL)
                    if (ex.InnerException.InnerException != null)
                    {
                        mensajeError += "\n" + ex.InnerException.InnerException.Message;
                    }
                }

                // 3. Mostramos todo
                MessageBox.Show(mensajeError, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error al vender: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Formulario_generar_factura_Load(object sender, EventArgs e)
        {

        }
    }
}
