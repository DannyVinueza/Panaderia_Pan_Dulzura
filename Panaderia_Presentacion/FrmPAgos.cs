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
using Panaderia_LogicaNegocio;

namespace Panaderia_Presentacion
{
    public partial class FrmPagos : Form
    {
        private PagosLogica pagosLogica;
        private Pagos nuevoPago;
        private PedidosLogica pedidos;

        public FrmPagos()
        {
            InitializeComponent();
            pagosLogica = new PagosLogica();
            nuevoPago = new Pagos();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            FormHelper.InitializeComboBoxAndButton(this, cbxVentanas, btnIrPagina, "FrmPAgos");

        }
        private void InsertarPago()
        {
            try
            {
                nuevoPago.ID_pedido = Convert.ToInt32(txtIDPedido.Text);
                //nuevoPago.ID_pago = Convert.ToInt32(txtIDPago.Text);
                nuevoPago.Fecha_Pago = Convert.ToDateTime(dateTimePicker1.Value);
                nuevoPago.Monto = Convert.ToDouble(txtMonto.Text);
                nuevoPago.Metodo_Pago = textMetodo.Text;
                pagosLogica.InsertarPago(nuevoPago);
                MessageBox.Show("Pago insertado correctamente");
                ListarPagos();
            }
            catch (Exception ex) {
                MessageBox.Show("Error al insertar el pago: " + ex.Message);
            }
        }
        private void ListarPagos()
        {
            try
            {
                dataListPagos.DataSource = pagosLogica.ListarPagos();
            }catch (Exception ex)
            {
                MessageBox.Show("Error al listar los pagos: " + ex.Message);
            }
        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            ListarPagos();
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            InsertarPago();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Pagos actualizarPago = new Pagos();
                actualizarPago.ID_pago = Convert.ToInt32(txtIDPago.Text);
                actualizarPago.ID_pedido = Convert.ToInt32(txtIDPedido.Text);
                actualizarPago.Fecha_Pago = Convert.ToDateTime(dateTimePicker1.Value);
                actualizarPago.Monto = Convert.ToInt32(txtMonto.Text);
                actualizarPago.Metodo_Pago = textMetodo.Text;

                pagosLogica.ActualizarPago(actualizarPago);
                MessageBox.Show("Pago actualizado correctamente.");
                ListarPagos();
                LimpiarPagos();
                dataListPagos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el pago: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idPago = ObtenerPedidoId();

            if (idPedido != -1)
            {
                try
                {
                    pedidosLogica.EliminarPedido(idPedido);
                    MessageBox.Show("Pedido eliminado correctamente");

                    ListarPedidos();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el pedido: " + ex.Message);
                }
            }

        }
    }
}
