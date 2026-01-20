using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Trabajo_Final_das.Models;

namespace Trabajo_Final_das.View
{
    public partial class Formulario_Categorias : Form
    {
        private TrabajoFinalDasContext contexto;
        public Formulario_Categorias()
        {
            contexto = new TrabajoFinalDasContext();
            InitializeComponent();
        }

        private void Formulario_Categorias_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btnVer_categorias_Click(object sender, EventArgs e)
        {
            try
            {
                lstCategorias.DataSource = null;

                var categorias = contexto.Productos
                                    .Select(p => p.Categoria)
                                    .Where(c => !string.IsNullOrEmpty(c))
                                    .Distinct()
                                    .OrderBy(c => c)
                                    .ToList();
                lstCategorias.DataSource = categorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorias " + ex.Message);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstCategorias.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría");
                return;
            }

            string categoriaVieja = lstCategorias.SelectedItem.ToString();

            string categoriaNueva = Interaction.InputBox(
                "Ingrese el nuevo nombre de la categoría:",
                "Renombrar categoría",
                categoriaVieja
            );

            if (string.IsNullOrWhiteSpace(categoriaNueva))
                return;

            var productos = contexto.Productos
                .Where(p => p.Categoria == categoriaVieja)
                .ToList();

            foreach (var p in productos)
            {
                p.Categoria = categoriaNueva;
            }

            contexto.SaveChanges();
            btnVer_categorias.PerformClick();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstCategorias.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría");
                return;
            }

            string categoria = lstCategorias.SelectedItem.ToString();

            DialogResult r = MessageBox.Show(
                $"La categoría '{categoria}' será eliminada de los productos.\n¿Continuar?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (r != DialogResult.Yes)
                return;

            var productos = contexto.Productos
                .Where(p => p.Categoria == categoria)
                .ToList();

            foreach (var p in productos)
            {
                p.Categoria = null; // o "Sin categoría"
            }

            contexto.SaveChanges();
            btnVer_categorias.PerformClick();
        }
    }
}
