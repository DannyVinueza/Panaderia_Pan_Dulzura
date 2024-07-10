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
    public partial class FrmDetallePedido : Form
    {
        private DetallePedidoLogica DetallePedidoLogica;
        private Detalle_Pedido nuevoDetallePedido;

        public FrmDetallePedido()
        {
            InitializeComponent();
            DetallePedidoLogica= new DetallePedidoLogica();
            nuevoDetallePedido = new Detalle_Pedido();
        }

        private void insertarDetallePedido()
        {
            //nuevoDetallePedido.ID_detalle = Convert.ToInt32(txtidDetalle.Text);
            nuevoDetallePedido.ID_pedido = Convert.ToInt32(txtidPedido.Text);
            nuevoDetallePedido.ID_producto = Convert.ToInt32(txtidProducto.Text);
            nuevoDetallePedido.Cantidad = Convert.ToInt32(txtCantidad.Text);
            nuevoDetallePedido.Precio = Convert.ToInt32(txtPrecio.Text);
            try
            {
                DetallePedidoLogica.InsertarDetallePedido(nuevoDetallePedido);
                MessageBox.Show("Detalle ingresado correctamente");
                listarDetallePedido();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al insertar el detalle:" + ex.Message);
            }

        }
        public void listarDetallePedido()
        {
            dgvListaDetallePedido.DataSource = DetallePedidoLogica.ListarDetallePedido();

        }

        private void FrmDetallePedido_Load(object sender, EventArgs e)
        {
            listarDetallePedido();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            insertarDetallePedido();
        }
    }
}
