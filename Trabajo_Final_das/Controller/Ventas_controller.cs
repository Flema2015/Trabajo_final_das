using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trabajo_Final_das.Models;

namespace Trabajo_Final_das.Controller
{
    public class Ventas_controller
    {
        private TrabajoFinalDasContext contexto;

        public Ventas_controller()
        {
            contexto = new TrabajoFinalDasContext();
        }

        public void Confirmar_venta(int cliente_Id, int codigo_producto, List<Producto> productos_en_carrito, string nombre_sucursal)
        {
            // ---------------------------------------------------------
            // PASO 1: Calcular Subtotal
            // ---------------------------------------------------------
            decimal subtotal = 0;
            foreach (var prod in productos_en_carrito)
            {
                subtotal += (decimal)prod.Precio;
            }

            // ---------------------------------------------------------
            // PASO 2: Calcular Descuento (Lógica 0 vs 1)
            // ---------------------------------------------------------
            var cliente = contexto.Clientes.Find(cliente_Id);
            decimal descuento = 0;

            // Si es 1 (Mayorista), aplicamos 20%. Si es 0 (Minorista), nada.
            if (cliente != null && cliente.TipoCliente == 1)
            {
                descuento = subtotal * 0.20m;
            }

            decimal totalFinal = subtotal - descuento;

            // ---------------------------------------------------------
            // PASO 3: Crear la Cabecera de la Venta
            // ---------------------------------------------------------
            // Iniciamos una transacción para que si algo falla, no se guarde nada a medias
            using (var transaction = contexto.Database.BeginTransaction())
            {
                try
                {
                    Venta nuevaVenta = new Venta
                    {
                        FechaVenta = DateTime.Now,
                        MetodosDePago = 0, // 0: Efectivo (puedes parametrizarlo si quieres)
                        codigo_producto = codigo_producto.ToString(),
                        IdCliente = cliente_Id,
                        Total_final = totalFinal,

                        Sucursal = nombre_sucursal
                    };

                    contexto.Ventas.Add(nuevaVenta);
                    contexto.SaveChanges(); // Guardamos para obtener el ID de la venta

                    // ---------------------------------------------------------
                    // PASO 4: Guardar Detalles y Descontar Stock
                    // ---------------------------------------------------------
                    if (productos_en_carrito != null)
                    {
                        foreach (var prod in productos_en_carrito)
                        {
                            var stock = contexto.Productos.Find(prod.Codigo_producto);

                            if (stock != null) stock.CantidadStock -= 1; // Restamos 1
                        }
                    }
                    contexto.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback(); // Si hubo error, deshacemos todo
                    throw; // Re-lanzamos el error para que lo vea el formulario
                }
            }
        }
    }
}
