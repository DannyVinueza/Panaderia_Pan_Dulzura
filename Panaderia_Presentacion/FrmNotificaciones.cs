using Panaderia_LogicaNegocio;
using System;
using System.Windows.Forms;
using Panaderia_AccesoDatos.Entidades;
using Panaderia_LogicaNegocio.Panaderia_LogicaNegocio;
using Panaderia_Presentacion;


namespace Panaderia_presentacion
{
    public partial class FrmNotificaciones : Form
    {
        private NotificacionesLogica notificacionesLogica;
        private Notificaciones nuevaNotificacion;

        public FrmNotificaciones()
        {
            InitializeComponent();
            notificacionesLogica = new NotificacionesLogica();
            nuevaNotificacion = new Notificaciones();
            dtpFechaNotificacion.Format = DateTimePickerFormat.Custom;
            dtpFechaNotificacion.CustomFormat = "yyyy/MM/dd HH:mm:ss";
        }

        private void InsertarNotificacion()
        {
            try
            {
                nuevaNotificacion.ID_pedido = int.Parse(txtID_pedido.Text);
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
            txtID_pedido.Text = string.Empty;
            txtTipo.Text = string.Empty;
            dtpFechaNotificacion.Text = string.Empty;
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
                txtID_pedido.Text = selectedRow.Cells["ID_pedido"].Value.ToString();
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la notificación: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Notificaciones notificacionActualizada = new Notificaciones
                {
                    ID_Notificacion = ObtenerIdNotificacionSeleccionada(),
                    ID_pedido = int.Parse(txtID_pedido.Text),
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

        private void FrmNotificaciones_Load(object sender, EventArgs e)
        {
            dgvListaNotificaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaNotificaciones.MultiSelect = false;
            ListarNotificaciones();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            InsertarNotificacion();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}