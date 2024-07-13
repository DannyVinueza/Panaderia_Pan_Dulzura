using Panaderia_AccesoDatos.Entidades;
using Panaderia_LogicaNegocio;
using System;
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
            FormHelper.InitializeComboBoxAndButton(this, cbxVentanas, btnIrPagina, "FrmDetallePedido");
        }

        private void insertarDetallePedido()
        {
            try
            {
                //nuevoDetallePedido.ID_detalle = Convert.ToInt32(txtidDetalle.Text);
                nuevoDetallePedido.ID_pedido = Convert.ToInt32(txtidPedido.Text);
                nuevoDetallePedido.ID_producto = Convert.ToInt32(txtidProducto.Text);
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
        public void listarDetallePedido()
        {
            try
            {
                dgvListaDetallePedido.DataSource = DetallePedidoLogica.ListarDetallePedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar el detalle de los pedidos: " + ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            insertarDetallePedido();
        }

        private void FrmDetallePedido_Load(object sender, EventArgs e)
        {
            listarDetallePedido();
        }
    }
}
