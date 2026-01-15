using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final_das.Models;

namespace Trabajo_Final_das.Controller
{
    public class Producto_contoller
    {
        private TrabajoFinalDasContext contexto;

        public Producto_contoller()
        {
            contexto = new TrabajoFinalDasContext();
        }

        public List<Producto>Obtener_productos()
        {
            return contexto.Productos.ToList();
        }

        public Producto Obtener_productos_por_id(int id_producto)
        {
            return contexto.Productos.Find(id_producto);
        }
      
        public void Crear_producto(Producto producto)
        {
            contexto.Productos.Add(producto);
            contexto.SaveChanges();
        }

        public void Eliminar_producto(int producto_id)
        {
            var producto = contexto.Productos.Find(producto_id);
            if (producto != null)
            {
                contexto.Productos.Remove(producto);
                contexto.SaveChanges();

            }
        }

        public void Modificar_producto(Producto producto)
        {
            var producto_a_modificar = contexto.Productos.Find(producto.Codigo_producto);
            if (producto_a_modificar != null)
            {
                producto_a_modificar.Nombre = producto.Nombre;
                producto_a_modificar.Descripcion = producto.Descripcion;
                producto_a_modificar.Categoria = producto.Categoria;
                producto_a_modificar.Precio = producto.Precio;
                producto_a_modificar.CantidadStock = producto.CantidadStock;
                contexto.SaveChanges();
            }
        }
    }
    
}
