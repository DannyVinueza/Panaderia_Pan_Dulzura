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
        private bool datosCargados = false;

        public FrmProducto()
        {
            InitializeComponent();
            productoLogica = new ProductoLogica();
            nuevoProducto = new Producto();
            categoriaLogica = new CategoriaLogica();
            dgvListaProductos.CellClick += dgvListaProductos_CellClick;
        }

        private void dgvListaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LlenarCamposConProductoSeleccionado();
            }
        }

        private void insertarProducto()
        {
            try
            {
                nuevoProducto.Nombre = txtNombre.Text;
                nuevoProducto.ID_categoria = Convert.ToInt32(comboCategoria.SelectedValue);
                nuevoProducto.Descripcion = txtDescripcion.Text;
                nuevoProducto.Ingredientes = txtIngredientes.Text;
                nuevoProducto.Calorias = Convert.ToInt32(txtCalorias.Text);
                productoLogica.InsertarProducto(nuevoProducto);
                MessageBox.Show("Producto insertado correctamente");
                listarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el producto: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtIdProducto.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtIngredientes.Text = string.Empty;
            txtCalorias.Text = string.Empty;
            comboCategoria.SelectedIndex = -1;
        }

        public void listarProductos()
        {
            try
            {
                dgvListaProductos.DataSource = productoLogica.ObtenerProductos();
                dgvListaProductos.ClearSelection();
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
                comboCategoria.DisplayMember = "Nombre"; 
                comboCategoria.ValueMember = "ID_categoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message);
            }
        }

        private int GetSelectedProductId()
        {
            if (dgvListaProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvListaProductos.SelectedRows[0];
                return Convert.ToInt32(selectedRow.Cells["ID_producto"].Value);
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
                return -1; 
            }
        }

        private void LlenarCamposConProductoSeleccionado()
        {
            if (!datosCargados || dgvListaProductos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dgvListaProductos.SelectedRows[0];
            txtIdProducto.Text = selectedRow.Cells["ID_producto"].Value.ToString();
            txtNombre.Text = selectedRow.Cells["Nombre"].Value.ToString();
            comboCategoria.SelectedValue = selectedRow.Cells["ID_categoria"].Value;
            txtDescripcion.Text = selectedRow.Cells["Descripcion"].Value.ToString();
            txtIngredientes.Text = selectedRow.Cells["Ingredientes"].Value.ToString();
            txtCalorias.Text = selectedRow.Cells["Calorias"].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idProducto = GetSelectedProductId();

            if (idProducto != -1) 
            {
                try
                {
                    productoLogica.EliminarProducto(idProducto);
                    MessageBox.Show("Producto eliminado correctamente");

                   
                    listarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                }
            }
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto productoActualizado = new Producto
                {
                    ID_producto = Convert.ToInt32(txtIdProducto.Text),
                    Nombre = txtNombre.Text,
                    ID_categoria = Convert.ToInt32(comboCategoria.SelectedValue),
                    Descripcion = txtDescripcion.Text,
                    Ingredientes = txtIngredientes.Text,
                    Calorias = Convert.ToInt32(txtCalorias.Text)
                };

                productoLogica.ActualizarProducto(productoActualizado);
                MessageBox.Show("Producto actualizado correctamente");
                listarProductos();
                LimpiarCampos(); 
                dgvListaProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el producto: " + ex.Message);
            }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            dgvListaProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaProductos.MultiSelect = false;
            listarProductos();
            cargarCategorias();
            datosCargados = true;

        
            if (dgvListaProductos.Rows.Count > 0)
            {
                dgvListaProductos.ClearSelection();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            insertarProducto();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
