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
        private PedidosLogica PedidosLogica;
        private Pagos nuevoPago;
        private bool datosCargados = false;

        public FrmPagos()
        {
            InitializeComponent();
            pagosLogica = new PagosLogica();
            PedidosLogica = new PedidosLogica();
            nuevoPago = new Pagos();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            dataListPagos.CellClick += dataListPagos_CellClick;
        }

        private void dataListPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnLimpiar.Enabled = true;
                LlenarCamposConPagosSeleccionada();
            }
        }

        private void LlenarCamposConPagosSeleccionada()
        {
            if (dataListPagos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataListPagos.SelectedRows[0];
                txtIDPago.Text = selectedRow.Cells["ID_pago"].Value.ToString();
                cbxIdPedido.SelectedValue = selectedRow.Cells["ID_pedido"].Value;
                txtMonto.Text = selectedRow.Cells["Monto"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells["Fecha_Pago"].Value);
                textMetodo.Text = selectedRow.Cells["Metodo_Pago"].Value.ToString();
            }
        }


        private void LimpiarCampos()
        {
            txtIDPago.Clear();
            cbxIdPedido.SelectedIndex = -1;
            txtMonto.Clear();
            textMetodo.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private int ObtenerPagoId()
        {
            if (dataListPagos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataListPagos.SelectedRows[0];
                return Convert.ToInt32(selectedRow.Cells["ID_pago"].Value);
            }
            else
            {
                MessageBox.Show("Por favor selecciona un pedido para eliminar.");
                return -1;
            }
        }

        private void InsertarPago()
        {
            try
            {
                if (int.TryParse(cbxIdPedido.SelectedValue.ToString(), out int idPedido) &&
                     double.TryParse(txtMonto.Text, out double monto) &&
                     !string.IsNullOrWhiteSpace(textMetodo.Text))
                {
                    nuevoPago.ID_pedido = idPedido;
                    nuevoPago.Fecha_Pago = Convert.ToDateTime(dateTimePicker1.Value);
                    nuevoPago.Monto = monto;
                    nuevoPago.Metodo_Pago = textMetodo.Text;

                    pagosLogica.InsertarPago(nuevoPago);
                    MessageBox.Show("Pago insertado correctamente");
                    ListarPagos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Por favor, revise los datos ingresados.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error al insertar el pago: " + ex.Message);
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

        private void ListarPagos()
        {
            try
            {
                dataListPagos.DataSource = pagosLogica.ListarPagos();
                dataListPagos.ClearSelection();
            }catch (Exception ex)
            {
                MessageBox.Show("Error al listar los pagos: " + ex.Message);
            }
        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            dataListPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListPagos.MultiSelect = false;
            datosCargados = true;
            ListarPagos();
            CargarPedidos();

            if (dataListPagos.Rows.Count > 0)
            {
                dataListPagos.ClearSelection();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idPago = ObtenerPagoId();
            if (idPago != -1)
            {
                try
                {
                    pagosLogica.EliminarPago(idPago);
                    MessageBox.Show("Pedido eliminado correctamente");

                    ListarPagos();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el pedido: " + ex.Message);
                }
            }
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            InsertarPago();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtIDPago.Text, out int idPago) &&
                    int.TryParse(cbxIdPedido.SelectedValue.ToString(), out int idPedido) &&
                    double.TryParse(txtMonto.Text, out double monto) &&
                    !string.IsNullOrWhiteSpace(textMetodo.Text))
                {
                    nuevoPago.ID_pago = idPago;
                    nuevoPago.ID_pedido = idPedido;
                    nuevoPago.Fecha_Pago = dateTimePicker1.Value;
                    nuevoPago.Monto = monto;
                    nuevoPago.Metodo_Pago = textMetodo.Text;

                    pagosLogica.ActualizarPago(nuevoPago);
                    MessageBox.Show("Pago actualizado correctamente");
                    ListarPagos();
                }
                else
                {
                    MessageBox.Show("Por favor, revise los datos ingresados.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el pago: " + ex.Message);
            }
        }
    }
}
