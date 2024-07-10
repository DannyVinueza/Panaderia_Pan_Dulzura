using Panaderia_AccesoDatos.DAO;
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
    public partial class FrmProducto : Form
    {
        private ProductoLogica productoLogica;
        private Producto nuevoProducto;
        private CategoriaLogica categoriaLogica;
        public FrmProducto()
        {
            InitializeComponent();
            productoLogica = new ProductoLogica();
            nuevoProducto = new Producto();
            categoriaLogica = new CategoriaLogica();
            FormHelper.InitializeComboBoxAndButton(this, cbxVentanas, btnIrPagina, "FrmProducto");
        }

        private void insertarProducto()
        {
            nuevoProducto.Nombre = txtNombre.Text;
            nuevoProducto.ID_categoria = Convert.ToInt32(comboCategoria.SelectedValue);
            nuevoProducto.Descripcion = txtDescripcion.Text;
            nuevoProducto.Ingredientes = txtIngredientes.Text;
            nuevoProducto.Calorias = Convert.ToInt32(txtCalorias.Text);

            try
            {
                productoLogica.InsertarProducto(nuevoProducto);
                MessageBox.Show("Producto insertado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el producto: " + ex.Message);
            }
        }

        public void listarProductos()
        {
            try
            {
                dgvListaProductos.DataSource = productoLogica.ObtenerProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar los productos: " + ex.Message);
            }
        }

        

        private void cargarCategorias()
        {
            try
            {
                List<Categoria> categorias = categoriaLogica.ObtenerCategoriasList();
                comboCategoria.DataSource = categorias;
                comboCategoria.DisplayMember = "Nombre"; // Mostrar el nombre de la categoría
                comboCategoria.ValueMember = "ID_categoria"; // El valor será el ID de la categoría
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message);
            }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            listarProductos();
            cargarCategorias();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            insertarProducto();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
