using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final_das.Models;

namespace Trabajo_Final_das.Controller
{
    public class Cliente_controller
    {
        private TrabajoFinalDasContext contexto;

        public Cliente_controller()
        {
            contexto = new TrabajoFinalDasContext();
        }

        public List<Cliente> Obtener_clientes()
        {
            return contexto.Clientes.ToList();
        }

        public void Crear_cliente(Cliente cliente)
        {
            contexto.Clientes.Add(cliente);
            contexto.SaveChanges();
        }

        public void Eliminar_cliente(Cliente cliente)
        {
            contexto.Clientes.Remove(cliente);
            contexto.SaveChanges();
        }

        public void Modificar_cliente(Cliente cliente)
        {
            var cliente_a_modificar = contexto.Clientes.Find(cliente.IdCliente);
            if (cliente_a_modificar != null)
            {
                cliente_a_modificar.NombreCliente = cliente.NombreCliente;
                cliente_a_modificar.ApellidoCliente = cliente.ApellidoCliente;
                cliente_a_modificar.TipoCliente = cliente.TipoCliente;
            }
        }

       
    }
}
