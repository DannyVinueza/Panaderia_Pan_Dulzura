using Panaderia_AccesoDatos.Entidades;
using Panaderia_LogicaNegocio;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Panaderia_Presentacion
{
    public partial class FrmPedidos : Form
    {
        private PedidosLogica pedidosLogica;
        private UsuariosLogica usuariosLogica;
        private Pedidos nuevoPedido;
        private bool datosCargados = false;

        public FrmPedidos()
        {
            InitializeComponent();
            pedidosLogica = new PedidosLogica();
            usuariosLogica = new UsuariosLogica();
            nuevoPedido = new Pedidos();
            dateTimeFechaEntrega.Format = DateTimePickerFormat.Custom;
            dateTimeFechaEntrega.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            dateTimeFechaPedido.Format = DateTimePickerFormat.Custom;
            dateTimeFechaPedido.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            dataListPedidos.CellClick += dataListPedidos_CellClick;
        }

        private void dataListPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LlenarCamposConPedidoSeleccionado();
            }
        }

        private void LlenarCamposConPedidoSeleccionado()
        {
            if (!datosCargados || dataListPedidos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dataListPedidos.SelectedRows[0];
            txtIDPedido.Text = selectedRow.Cells["ID_pedido"].Value.ToString();
            cbxUsuarios.SelectedValue = selectedRow.Cells["ID_usuario"].Value;
            dateTimeFechaPedido.Value = Convert.ToDateTime(selectedRow.Cells["Fecha_Pedido"].Value);
            dateTimeFechaEntrega.Value = Convert.ToDateTime(selectedRow.Cells["Fecha_Entrega"].Value);
            txtEstado.Text = selectedRow.Cells["Estado"].Value.ToString();
        }

        private void CargarUsuarios()
        {
            try
            {
                List<Usuarios> usuarios = usuariosLogica.ObtenerUsuariosList();
                cbxUsuarios.DataSource = usuarios;
                cbxUsuarios.DisplayMember = "Nombre";
                cbxUsuarios.ValueMember = "ID_usuario";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los: " + ex.Message);
            }
        }

        private int ObtenerPedidoId()
        {
            if (dataListPedidos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataListPedidos.SelectedRows[0];
                return Convert.ToInt32(selectedRow.Cells["ID_pedido"].Value);
            }
            else
            {
                MessageBox.Show("Por favor selecciona un pedido para eliminar.");
                return -1;
            }
        }

        private void LimpiarCampos()
        {
            txtIDPedido.Text = string.Empty;
            cbxUsuarios.SelectedIndex = -1;
            dateTimeFechaPedido.Value = DateTime.Now;
            dateTimeFechaEntrega.Value = DateTime.Now;
            txtEstado.Text = string.Empty;
        }

        private void InsertarPedido()
        {
            try
            {
                nuevoPedido.ID_usuario = Convert.ToInt32(cbxUsuarios.SelectedValue);
                nuevoPedido.Fecha_Pedido = Convert.ToDateTime(dateTimeFechaPedido.Value);
                nuevoPedido.Fecha_Entrega = Convert.ToDateTime(dateTimeFechaEntrega.Value);
                nuevoPedido.Estado = txtEstado.Text;
                pedidosLogica.InsertarPedido(nuevoPedido);
                MessageBox.Show("Pedido insertado correctamente");
                ListarPedidos();
            }
            catch (Exception ex) {
                MessageBox.Show("Error al insertar el pedido: " + ex.Message);
            }
        }

        private void ListarPedidos()
        {
            try
            {
                dataListPedidos.DataSource = pedidosLogica.ListarPedidos();
                dataListPedidos.ClearSelection();
            }catch (Exception ex)
            {
                MessageBox.Show("Error al listar los pedidos: " + ex.Message);
            }
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            InsertarPedido();
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            dataListPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListPedidos.MultiSelect = false;
            ListarPedidos();
            CargarUsuarios();
            datosCargados = true;

            if (dataListPedidos.Rows.Count > 0)
            {
                dataListPedidos.ClearSelection();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idPedido = ObtenerPedidoId();

            if (idPedido != -1)
            {
                try
                {
                    pedidosLogica.EliminarPedido(idPedido);
                    MessageBox.Show("Pedido eliminado correctamente");

                    ListarPedidos();
                    LimpiarCampos();
                }catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el pedido: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Pedidos actualizarPedido = new Pedidos();
                actualizarPedido.ID_pedido = Convert.ToInt32(txtIDPedido.Text);
                actualizarPedido.ID_usuario = Convert.ToInt32(cbxUsuarios.SelectedValue);
                actualizarPedido.Fecha_Pedido = Convert.ToDateTime(dateTimeFechaPedido.Value);
                actualizarPedido.Fecha_Entrega = Convert.ToDateTime(dateTimeFechaEntrega.Value);
                actualizarPedido.Estado = txtEstado.Text;

                pedidosLogica.ActualizarPedido(actualizarPedido);
                MessageBox.Show("Pedido actualizado correctamente.");
                ListarPedidos();
                LimpiarCampos();
                dataListPedidos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el pedido: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
