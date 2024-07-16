using Panaderia_AccesoDatos.Entidades;
using Panaderia_LogicaNegocio;
using System;
using System.Windows.Forms;

namespace Panaderia_Presentacion
{
    public partial class FrmCategoria : Form
    {
        private CategoriaLogica categoriaLogica;
        private Categoria nuevaCategoria;
        private bool datosCargados = false;

        public FrmCategoria()
        {
            InitializeComponent();
            categoriaLogica = new CategoriaLogica();
            nuevaCategoria = new Categoria();
            dvgListarCategoria.CellClick += dvgListarCategoria_CellClick;
        }

        public void listarCategorias()
        {
            try
            {
                dvgListarCategoria.DataSource = categoriaLogica.ObtenerCategorias();
                dvgListarCategoria.ClearSelection();
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
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la categoria: " + ex.Message);
            }
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            dvgListarCategoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgListarCategoria.MultiSelect = false;
            listarCategorias();
            datosCargados = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            insertarCategoria();
        }

        private void dvgListarCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LlenarCamposConCategoriaSeleccionada();
            }
        }

        private void LlenarCamposConCategoriaSeleccionada()
        {
            if (!datosCargados || dvgListarCategoria.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dvgListarCategoria.SelectedRows[0];
            txtIdCategoria.Text = selectedRow.Cells["ID_categoria"].Value.ToString();
            txtNombreCategoria.Text = selectedRow.Cells["Nombre"].Value.ToString();
        }

   



        private void LimpiarCampos()
        {
            txtIdCategoria.Text = string.Empty;
            txtNombreCategoria.Text = string.Empty;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Categoria categoriaActualizada = new Categoria
                {
                    ID_categoria = Convert.ToInt32(txtIdCategoria.Text),
                    Nombre = txtNombreCategoria.Text
                };

                categoriaLogica.ActualizarCategoria(categoriaActualizada);
                MessageBox.Show("Categoría actualizada correctamente");
                listarCategorias();
                LimpiarCampos();
                dvgListarCategoria.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la categoría: " + ex.Message);
            }

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dvgListarCategoria.SelectedRows.Count > 0)
            {
                int idCategoria = Convert.ToInt32(dvgListarCategoria.SelectedRows[0].Cells["ID_categoria"].Value);
                try
                {
                    categoriaLogica.EliminarCategoria(idCategoria);
                    MessageBox.Show("Categoría eliminada correctamente");
                    listarCategorias();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la categoría: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoría para eliminar.");
            }

        }
    }
}