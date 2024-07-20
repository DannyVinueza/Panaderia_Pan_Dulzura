using Panaderia_AccesoDatos.Entidades;
using Panaderia_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Panaderia_Presentacion
{
    public partial class FrmDetallePedido : Form
    {
        private DetallePedidoLogica DetallePedidoLogica;
        private Detalle_Pedido nuevoDetallePedido;
        private PedidosLogica PedidosLogica;
        private ProductoLogica ProductoLogica;
        private bool datosCargados = false;

        public FrmDetallePedido()
        {
            InitializeComponent();
            DetallePedidoLogica= new DetallePedidoLogica();
            nuevoDetallePedido = new Detalle_Pedido();
            PedidosLogica= new PedidosLogica();
            ProductoLogica = new ProductoLogica();
            dgvListaDetallePedido.CellClick += dgvListaDetallePedido_CellClick;

         }
        private void CargarPedidos()
        {
            DataTable dt = PedidosLogica.ListarPedidos();

            List<Pedidos> pedidos = new List<Pedidos>();
            foreach (DataRow row in dt.Rows)
            {
                Pedidos pedido = new Pedidos
                {
                    ID_pedido = Convert.ToInt32(row["ID_pedido"]),
                };
                pedidos.Add(pedido);
            }

            cbxIdPedido.DataSource = pedidos;
            cbxIdPedido.DisplayMember = "Nombre";
            cbxIdPedido.ValueMember = "ID_pedido";
        }
        private void CargarProductos()
        {
            DataTable dt = ProductoLogica.ObtenerProductos(); 

            List<Producto> productos = new List<Producto>();
            foreach (DataRow row in dt.Rows)
            {
                Producto producto = new Producto
                {
                    ID_producto = Convert.ToInt32(row["ID_producto"]),
                    Nombre = Convert.ToInt32(row["ID_producto"]) + " " + row["Nombre"].ToString(), 
                 };
                productos.Add(producto);
            }

            cbxIdProducto.DataSource = productos;
            cbxIdProducto.ValueMember = "ID_producto";
            cbxIdProducto.DisplayMember = "Nombre";


        }
    
        
        private void dgvListaDetallePedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LlenarCamposDetallePedido();
            }
        }

        private void insertarDetallePedido()
        {
            try
            {
                //nuevoDetallePedido.ID_detalle = Convert.ToInt32(txtidDetalle.Text);
                nuevoDetallePedido.ID_pedido = Convert.ToInt32(cbxIdPedido.Text);
                nuevoDetallePedido.ID_producto = Convert.ToInt32(cbxIdProducto.SelectedValue);
                nuevoDetallePedido.Cantidad = Convert.ToInt32(txtCantidad.Text);
                nuevoDetallePedido.Precio = Convert.ToDouble(txtPrecio.Text);
                DetallePedidoLogica.InsertarDetallePedido(nuevoDetallePedido);
                MessageBox.Show("Detalle ingresado correctamente");
                listarDetallePedido();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al insertar el detalle:" + ex.Message);
            }

        }

        private void LimpiarInfo()
        {
            txtidDetalle.Text= string.Empty;
            cbxIdPedido.Text= string.Empty;
            cbxIdProducto.Text= string.Empty;
            txtCantidad.Text= string.Empty;
            txtPrecio.Text= string.Empty;
        }
        public void listarDetallePedido()
        {
            try
            {
                dgvListaDetallePedido.DataSource = DetallePedidoLogica.ListarDetallePedido();
                dgvListaDetallePedido.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar el detalle de los pedidos: " + ex.Message);
            }
        }

        private int GetSelecionIdDetalle()
        {
            if (dgvListaDetallePedido.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow= dgvListaDetallePedido.SelectedRows[0];
                return Convert.ToInt32(selectedRow.Cells["ID_detalle"].Value);
            }
            else
            {
                MessageBox.Show("Seleccionar un id detalle para eliminar");
                return -1;
            }
        }

        private void LlenarCamposDetallePedido()
        {
            if (!datosCargados || dgvListaDetallePedido.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow selectedRow = dgvListaDetallePedido.SelectedRows[0];
            txtidDetalle.Text = selectedRow.Cells["ID_detalle"].Value.ToString();
            cbxIdPedido.SelectedValue =  selectedRow.Cells["ID_pedido"].Value.ToString();
            cbxIdProducto.SelectedValue = selectedRow.Cells["ID_producto"].Value.ToString();
            txtCantidad.Text = selectedRow.Cells["Cantidad"].Value.ToString();
            txtPrecio.Text = selectedRow.Cells["Precio"].Value.ToString();
        }
                  

        private void FrmDetallePedido_Load(object sender, EventArgs e)
        {
            dgvListaDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaDetallePedido.MultiSelect = false;
            listarDetallePedido();
            CargarPedidos();
            CargarProductos();
            datosCargados = true;

            if (dgvListaDetallePedido.Rows.Count > 0)
            {
                dgvListaDetallePedido.ClearSelection ();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            insertarDetallePedido();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int ID_detalle = GetSelecionIdDetalle();
            if (ID_detalle != -1)
            {
                try
                {
                    DetallePedidoLogica.EliminarDetallePedido(ID_detalle);
                    MessageBox.Show("Detalle eliminado Correctamente");

                    listarDetallePedido();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar detalle" + ex.Message);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarInfo();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Detalle_Pedido detalleActualizado = new Detalle_Pedido
                {
                    ID_detalle = Convert.ToInt32(txtidDetalle.Text),
                    ID_pedido = Convert.ToInt32(cbxIdPedido.Text),
                    ID_producto = Convert.ToInt32(cbxIdProducto.Text),
                    Cantidad = Convert.ToInt32(txtCantidad.Text),
                    Precio = Convert.ToDouble(txtPrecio.Text)
                };

                DetallePedidoLogica.ActualizarDetallePedido(detalleActualizado);
                MessageBox.Show("Detalle Pedido Actualizado");
                listarDetallePedido();
                LimpiarInfo();
                dgvListaDetallePedido.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el detalle" + ex.Message);
            }
        }

        private void cbxIdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
