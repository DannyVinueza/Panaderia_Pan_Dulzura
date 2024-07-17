using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panaderia_Presentacion
{
    public static class FormHelper
    {
        public static void InitializeComboBoxAndButton(Form formAntiguo, ComboBox comboBox, Button button, string formPredetermindao)
        {
            comboBox.Items.Add("FrmUsuarios");
            comboBox.Items.Add("FrmProducto");
            comboBox.Items.Add("FrmPedidos");
            comboBox.Items.Add("FrmCategoria");
            comboBox.Items.Add("FrmNotificaciones");
            comboBox.Items.Add("FrmPAgos");
            comboBox.Items.Add("FrmDetallePedido");

            comboBox.SelectedItem = formPredetermindao;

            button.Text = "Ir a ventana";
            button.Click += (sender, e) =>
            {
                string formularioSeleccionado = comboBox.SelectedItem?.ToString();

                Form formularios = null;

                switch (formularioSeleccionado)
                {
                    case "FrmUsuarios":
                        formularios = new FrmUsuarios();
                        break;
                    case "FrmProducto":
                        formularios = new FrmProducto();
                        break;
                    case "FrmPedidos":
                        formularios = new FrmPedidos();
                        break;
                    case "FrmCategoria":
                        formularios = new FrmCategoria();
                        break;
                    case "FrmNotificaciones":
                        formularios = new Panaderia_presentacion.FrmNotificaciones();
                        break;
                    case "FrmPAgos":
                        formularios = new FrmPagos();
                        break;
                    case "FrmDetallePedido":
                        formularios = new FrmDetallePedido();
                        break;
                }

                if (formularios != null)
                {
                    formAntiguo.Hide();
                    formularios.ShowDialog();
                    formAntiguo.Show();
                }
            };
        }
    }
}
