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

        public FrmPagos()
        {
            InitializeComponent();
            pagosLogica = new PagosLogica();
            nuevoPago = new Pagos();
            FormHelper.InitializeComboBoxAndButton(this, cbxVentanas, btnIrPagina, "FrmPedidos");

        }
        private void InsertarPago()
        {
            nuevoPago.ID_pedido = Convert.ToInt32(txtIDPedido.Text);
            nuevoPago.ID_pago = Convert.ToInt32(txtIDPago.Text);
            nuevoPago.Fecha_Pago = Convert.ToDateTime(dateTimePicker1.Value);
            nuevoPago.Monto = Convert.ToInt32(txtMonto.Text);
            nuevoPago.Metodo_Pago = textMetodo.Text;
            pagosLogica.InsertarPago(nuevoPago);
            ListarPagos();
        }
        private void ListarPagos()
        {
            dataListPagos.DataSource = pagosLogica.ListarPagos();
        }


        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            ListarPagos();
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            InsertarPago();
        }

        private void dataListPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
