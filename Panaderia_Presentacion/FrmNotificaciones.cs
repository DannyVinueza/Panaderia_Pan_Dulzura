using Panaderia_LogicaNegocio;
using System;
using System.Windows.Forms;
using Panaderia_AccesoDatos.Entidades;
using Panaderia_LogicaNegocio.Panaderia_LogicaNegocio;
using Panaderia_Presentacion;
using System.Collections.Generic;
using System.Data;


namespace Panaderia_presentacion
{
    public partial class FrmNotificaciones : Form
    {
        private NotificacionesLogica notificacionesLogica;
        private Notificaciones nuevaNotificacion;
        private PedidosLogica PedidosLogica;
        private bool datosCargados = false;

        public FrmNotificaciones()
        {
            InitializeComponent();
            notificacionesLogica = new NotificacionesLogica();
            nuevaNotificacion = new Notificaciones();
            PedidosLogica = new PedidosLogica();
            dtpFechaNotificacion.Format = DateTimePickerFormat.Custom;
            dtpFechaNotificacion.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            dgvListaNotificaciones.CellClick += dgvListaNotificaciones_CellClick;
        }

        private void dgvListaNotificaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                btnLimpiar.Enabled = true;
                LlenarCamposConNotificacionSeleccionada();
            }
        }

        private void InsertarNotificacion()
        {
            try
            {
                nuevaNotificacion.ID_pedido = int.Parse(cbxIdPedido.SelectedValue.ToString());
                nuevaNotificacion.Tipo = txtTipo.Text;
                nuevaNotificacion.Fecha_Notificacion = dtpFechaNotificacion.Value;

                notificacionesLogica.InsertarNotificacion(nuevaNotificacion);
                MessageBox.Show("Notificación insertada correctamente");
                LimpiarCampos();
                ListarNotificaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la notificación: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            cbxIdPedido.SelectedIndex = -1;
            txtTipo.Text = string.Empty;
            dtpFechaNotificacion.Value = DateTime.Now;
            txtID_Notificación.Text = string.Empty;
        }

        public void ListarNotificaciones()
        {
            try
            {
                dgvListaNotificaciones.DataSource = notificacionesLogica.ListarNotificaciones();
                dgvListaNotificaciones.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar las notificaciones: " + ex.Message);
            }
        }

        private int ObtenerIdNotificacionSeleccionada()
        {
            if (dgvListaNotificaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvListaNotificaciones.SelectedRows[0];
                return Convert.ToInt32(selectedRow.Cells["ID_Notificacion"].Value);
            }
            else
            {
                MessageBox.Show("Por favor seleccione una notificación para eliminar.");
                return -1;
            }
        }

        private void LlenarCamposConNotificacionSeleccionada()
        {
            if (dgvListaNotificaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvListaNotificaciones.SelectedRows[0];
                txtID_Notificación.Text = selectedRow.Cells["ID_notificacion"].Value.ToString();
                cbxIdPedido.SelectedValue = selectedRow.Cells["ID_pedido"].Value;
                txtTipo.Text = selectedRow.Cells["Tipo"].Value.ToString();
                dtpFechaNotificacion.Value = Convert.ToDateTime(selectedRow.Cells["Fecha_Notificacion"].Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idNotificacion = ObtenerIdNotificacionSeleccionada();

            if (idNotificacion != -1)
            {
                try
                {
                    notificacionesLogica.EliminarNotificacion(idNotificacion);
                    MessageBox.Show("Notificación eliminada correctamente");
                    ListarNotificaciones();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la notificación: " + ex.Message);
                }
            }
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
            cbxIdPedido.DisplayMember = "Id_pedido";
            cbxIdPedido.ValueMember = "ID_pedido";
        }

        private void FrmNotificaciones_Load(object sender, EventArgs e)
        {
            dgvListaNotificaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaNotificaciones.MultiSelect = false;
            datosCargados = true;
            ListarNotificaciones();
            CargarPedidos();

            if(dgvListaNotificaciones.Rows.Count > 0)
            {
                dgvListaNotificaciones.ClearSelection();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            InsertarNotificacion();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            try
            {
                Notificaciones notificacionActualizada = new Notificaciones
                {
                    ID_Notificacion = ObtenerIdNotificacionSeleccionada(),
                    ID_pedido = int.Parse(cbxIdPedido.SelectedValue.ToString()),
                    Tipo = txtTipo.Text,
                    Fecha_Notificacion = dtpFechaNotificacion.Value
                };

                notificacionesLogica.ActualizarNotificacion(notificacionActualizada);
                MessageBox.Show("Notificación actualizada correctamente");
                LimpiarCampos();
                ListarNotificaciones();
                dgvListaNotificaciones.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la notificación: " + ex.Message);
            }
        }
    }
}