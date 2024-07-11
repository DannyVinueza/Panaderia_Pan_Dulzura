using Panaderia_LogicaNegocio;
using Panaderia_AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            FormHelper.InitializeComboBoxAndButton(this, cbxVentanas, btnIrPagina, "FrmNotificaciones");
        }

        private void insertarNotificacion()
        {
            insertarNotificacion(nuevaNotificacion);
        }

        private void insertarNotificacion(Notificaciones nuevaNotificacion)
        {
            nuevaNotificacion.ID_Notificacion = int.Parse(txtID_Notificación.Text);
            nuevaNotificacion.ID_pedido = int.Parse(txtID_pedido.Text);
            nuevaNotificacion.Tipo = cbxTipo.Text;
            nuevaNotificacion.Fecha_Notificacion = dtpFechaNotificacion.Value;

            notificacionesLogica.InsertarNotificaciones(nuevaNotificacion);
        }

        public void ListarNotificaciones()
        {
            dgvListaNotificaciones.DataSource = notificacionesLogica.ListarNotificaciones();
        }

        private void btnAceptar_Load(object sender, EventArgs e)
        {
            ListarNotificaciones();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            insertarNotificacion();
            ListarNotificaciones();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {

        }
    }
}