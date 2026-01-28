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
        public object obtener_ventas_recientes(DateTime fecha_limite)
        {
            var reporte = (from v in contexto.Ventas
                           join c in contexto.Clientes on v.IdCliente equals c.IdCliente
                           join p in contexto.Productos on v.codigo_producto equals p.Codigo_producto
                           where v.FechaVenta >= fecha_limite
                           orderby v.FechaVenta descending
                           select new
                           {
                               Fecha = v.FechaVenta,
                               cliente = c.NombreCliente + "" + c.ApellidoCliente,
                               productos = p.Nombre,
                               cantidad = v.stock_venta,
                               total = v.Total_final,
                               metodo = v.MetodosDePago
                           }).ToList();
            return reporte;

        }
        public void Confirmar_venta(Venta venta)
        {
            using (var transaccion = contexto.Database.BeginTransaction())
            {
                try
                {
                    // 1. Validar Stock
                    var productoDb = contexto.Productos.Find(venta.codigo_producto);

                    if (productoDb.CantidadStock < venta.stock_venta)
                    {
                        throw new Exception($"No hay suficiente stock. Stock actual: {productoDb.CantidadStock}");
                    }

                    // 2. Descontar Stock
                    productoDb.CantidadStock -= venta.stock_venta;

                    // 3. Guardar la Venta (La fecha la ponemos aquí para asegurar precisión)
                    venta.FechaVenta = DateTime.Now;
                    contexto.Ventas.Add(venta);

                    // 4. Confirmar cambios
                    contexto.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw; // Re-lanzamos el error para que lo vea el formulario
                }
            }
        }
        
        public object Obtener_Historial_Por_Cliente(int idCliente)
        {
            var historial = (from v in contexto.Ventas
                             join p in contexto.Productos
                             on v.codigo_producto equals p.Codigo_producto // OJO: Que ambos sean del mismo tipo (string o int)

                             where v.IdCliente == idCliente

                             // AQUÍ ELEJIMOS QUÉ MOSTRAR EN LAS COLUMNAS
                             select new
                             {
                                 Fecha = v.FechaVenta,
                                 Producto = p.Nombre,  
                                 categoria = p.Categoria,
                                 Total = v.Total_final,
                                 MetodoPago = v.MetodosDePago,  
                                 stock = p.CantidadStock,
                                 Sucursal = v.Sucursal       // Viene de la tabla VENTA
                             }).ToList();

            return historial;
        }


        public Producto Obtener_productos(string id)
        {
            return contexto.Productos.Find(id);
        }

      
        public List<object> ObtenerVentasFiltradas(string productoId = null, string sucursal = null)
        {
            // 1. Empezamos con la tabla "cruda" de Ventas
            var query = contexto.Ventas.AsNoTracking().AsQueryable();

            // 2. Aplicamos filtros SI ES QUE VINIERON (Paso a Paso)

            // Si me mandaron un producto, filtro por producto
            if (!string.IsNullOrEmpty(productoId))
            {
                query = query.Where(v => v.codigo_producto == productoId);
            }

            // Si me mandaron una sucursal, filtro por sucursal
            if (!string.IsNullOrEmpty(sucursal))
            {
                query = query.Where(v => v.Sucursal == sucursal);
            }

            // 3. AHORA que ya filtramos lo que no sirve, hacemos los JOINS y el SELECT final
            var resultado = (from v in query // Usamos la variable 'query' que ya está filtrada
                             join c in contexto.Clientes on v.IdCliente equals c.IdCliente
                             join p in contexto.Productos on v.codigo_producto equals p.Codigo_producto
                             orderby v.FechaVenta descending
                             select new
                             {
                                 Fecha = v.FechaVenta,
                                 Cliente = c.NombreCliente + " " + c.ApellidoCliente,
                                 Producto = p.Nombre,
                                 Sucursal = v.Sucursal,
                                 Cantidad = v.stock_venta,
                                 Total = v.Total_final,
                                 Metodo = v.MetodosDePago
                             }).ToList<object>();

            return resultado;
        }
        public object ObtenerRankingProductos()
        {
            var ranking = (from v in contexto.Ventas
                           join p in contexto.Productos on v.codigo_producto equals p.Codigo_producto

                           // 1. AGRUPAMOS por Nombre y Código
                           // (La 'g' representa el grupo de ventas de ese producto específico)
                           group v by new { p.Nombre, p.Codigo_producto } into g


                           select new
                           {
                               Producto = g.Key.Nombre, // Nombre del producto (la llave del grupo)
                               Codigo = g.Key.Codigo_producto,

                               // 3. SUMAMOS las cantidades dentro de ese grupo
                               TotalUnidades = g.Sum(x => x.stock_venta),

                               // Opcional: También podrías sumar el dinero recaudado
                               TotalRecaudado = g.Sum(x => x.Total_final)
                           })
                           // 4. ORDENAMOS descendente (del mayor al menor)
                           .OrderByDescending(r => r.TotalUnidades)
                           .ToList();

            return ranking;
        }
    }
}
