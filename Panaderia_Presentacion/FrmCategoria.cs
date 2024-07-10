using Panaderia_AccesoDatos.Entidades;
using Panaderia_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panaderia_Presentacion
{
    public partial class FrmCategoria : Form
    {
        private CategoriaLogica categoriaLogica;
        private Categoria nuevaCategoria;
        public FrmCategoria()
        {
            InitializeComponent();
            categoriaLogica = new CategoriaLogica();
            nuevaCategoria = new Categoria();
            FormHelper.InitializeComboBoxAndButton(this, cbxVentanas, btnIrPagina, "FrmCategoria");
        }

        public void listarCategorias()
        {
            try
            {
                dvgListarCategoria.DataSource = categoriaLogica.ObtenerCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar las categorias: " + ex.Message);
            }
        }

        public void insertarCategoria()
        {
            nuevaCategoria.Nombre = txtNombreCategoria.Text;
            try
            {
                categoriaLogica.InsertarCategoria(nuevaCategoria);
                MessageBox.Show("Categoria insertada correctamente");
                listarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la categoria: " + ex.Message);
            }
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            listarCategorias();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            insertarCategoria();
        }

       
    }
}
