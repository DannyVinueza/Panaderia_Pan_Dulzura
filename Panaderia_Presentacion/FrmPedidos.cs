﻿using Panaderia_AccesoDatos.Entidades;
using Panaderia_LogicaNegocio;
using System;
using System.Windows.Forms;

namespace Panaderia_Presentacion
{
    public partial class FrmPedidos : Form
    {
        private PedidosLogica pedidosLogica;
        private Pedidos nuevoPedido;

        public FrmPedidos()
        {
            InitializeComponent();
            pedidosLogica = new PedidosLogica();
            nuevoPedido = new Pedidos();
            dateTimeFechaEntrega.Format = DateTimePickerFormat.Custom;
            dateTimeFechaEntrega.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            dateTimeFechaPedido.Format = DateTimePickerFormat.Custom;
            dateTimeFechaPedido.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            FormHelper.InitializeComboBoxAndButton(this, cbxVentanas, btnIrPagina, "FrmPedidos");
        }

        private void InsertarPedido()
        {
            try
            {
                nuevoPedido.ID_usuario = Convert.ToInt32(txtIDUsuario.Text);
                nuevoPedido.Fecha_Pedido = Convert.ToDateTime(dateTimeFechaPedido.Value);
                nuevoPedido.Fecha_Entrega = Convert.ToDateTime(dateTimeFechaEntrega.Value);
                nuevoPedido.Estado = txtEstado.Text;
                pedidosLogica.InsertarPedido(nuevoPedido);
                MessageBox.Show("Pedido insertado correctamente");
                ListarPedidos();
            }
            catch (Exception ex) {
                MessageBox.Show("Error al insertar el pedido: " + ex.Message);
            }
        }

        private void ListarPedidos()
        {
            try
            {
                dataListPedidos.DataSource = pedidosLogica.ListarPedidos();
            }catch (Exception ex)
            {
                MessageBox.Show("Error al listar los pedidos: " + ex.Message);
            }
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            InsertarPedido();
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            ListarPedidos();
        }
    }
}
