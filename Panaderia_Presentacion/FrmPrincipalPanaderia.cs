using Panaderia_presentacion;
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
    public partial class FrmPrincipalPanaderia : Form
    {
        private int childFormNumber = 0;

        public FrmPrincipalPanaderia()
        {
            InitializeComponent();
        }

        private void abrirProductoNuevo()
        {
            FrmProducto nuevofrmProducto = new FrmProducto();
            nuevofrmProducto.MdiParent = this;
            nuevofrmProducto.Show();
        }

        private void abrirCategoriaNuevo()
        {
            FrmCategoria nuevofrmCategoria = new FrmCategoria();
            nuevofrmCategoria.MdiParent = this;
            nuevofrmCategoria.Show();
        }

        private void abrirUsuarioNuevo()
        {
            FrmUsuarios nuevofrmUsuario = new FrmUsuarios();
            nuevofrmUsuario.MdiParent = this;
            nuevofrmUsuario.Show();
        }

        private void abrirPedidoNuevo()
        {
            FrmPedidos nuevofrmPedidos = new FrmPedidos();
            nuevofrmPedidos.MdiParent = this;
            nuevofrmPedidos.Show();
        }

        private void abriDetallePedidoNuevo()
        {
            FrmDetallePedido nuevofrmDetallePedido = new FrmDetallePedido();
            nuevofrmDetallePedido.MdiParent = this;
            nuevofrmDetallePedido.Show();
        }

        private void abrirNotificacionNuevo()
        {
            FrmNotificaciones nuevofrmNotificaciones = new FrmNotificaciones();
            nuevofrmNotificaciones.MdiParent = this;
            nuevofrmNotificaciones.Show();
        }

        private void abrirPagoNuevo()
        {
            FrmPagos nuevofrmPagos = new FrmPagos();
            nuevofrmPagos.MdiParent = this;
            nuevofrmPagos.Show();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            abrirProductoNuevo();
        }

        private void newToolStripButtonOpenFile(object sender, EventArgs e)
        {
            abrirProductoNuevo();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirProductoNuevo();
        }

        private void FrmPrincipalPanaderia_Load(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            abrirProductoNuevo();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCategoriaNuevo();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            abrirCategoriaNuevo();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirUsuarioNuevo();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirPedidoNuevo();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            abrirUsuarioNuevo();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            abrirPedidoNuevo();
        }

        private void detallePedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abriDetallePedidoNuevo();
        }

        private void notificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirNotificacionNuevo();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            abrirNotificacionNuevo();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            abriDetallePedidoNuevo();
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirPagoNuevo();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            abrirPagoNuevo();
        }
    }
}
