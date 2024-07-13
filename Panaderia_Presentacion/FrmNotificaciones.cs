using Panaderia_LogicaNegocio;
using System;
using System.Windows.Forms;
using Panaderia_AccesoDatos.Entidades;

namespace Panaderia_Presentacion
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
            FormHelper.InitializeComboBoxAndButton(this, cbxVentanas, btnIrPagina, "FrmNotificaciones");
        }

        private void insertarNotificacion()
        {
            try
            {
                //nuevaNotificacion.ID_Notificacion = int.Parse(txtID_Notificación.Text);
                nuevaNotificacion.ID_pedido = int.Parse(txtID_pedido.Text);
                nuevaNotificacion.Tipo = txtTipo.Text;
                nuevaNotificacion.Fecha_Notificacion = dtpFechaNotificacion.Value;

                notificacionesLogica.InsertarNotificaciones(nuevaNotificacion);
                MessageBox.Show("Notificación insertada correctamente");
                ListarNotificaciones();
            }
            catch (Exception ex) {
                MessageBox.Show("Error al insertar la notificación: " + ex.Message);
            }
        }

        public void ListarNotificaciones()
        {
            try
            {
                dgvListaNotificaciones.DataSource = notificacionesLogica.ListarNotificaciones();
            }
            catch (Exception ex) {
                MessageBox.Show("Error al listar las notificaciones: " + ex.Message);
            }
        }

        private void FrmNotificaciones_Load(object sender, EventArgs e)
        {
            ListarNotificaciones();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            insertarNotificacion();
        }
    }
}