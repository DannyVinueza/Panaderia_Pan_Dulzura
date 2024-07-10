using Panaderia_AccesoDatos.Entidades;
using Panaderia_LogicaNegocio;
using System;
using System.Windows.Forms;

namespace Panaderia_Presentacion
{
    public partial class FrmUsuarios : Form
    {
        private UsuariosLogica usuarioLogica;
        private Usuarios nuevoUsuario;
        public FrmUsuarios()
        {
            InitializeComponent();
            usuarioLogica = new UsuariosLogica();
            nuevoUsuario = new Usuarios();
            FormHelper.InitializeComboBoxAndButton(this, cbxVentanas, btnIrPagina, "FrmUsuarios");
        }

        private void insertarUsuario()
        {
            nuevoUsuario.Nombre = txtNombre.Text;
            nuevoUsuario.Direccion = txtDireccion.Text;
            nuevoUsuario.Telefono = txtTelefono.Text;
            nuevoUsuario.Correo_Electronico = txtEmail.Text;
            nuevoUsuario.Contrasena = txtContrasenia.Text;
            usuarioLogica.InsertarUsuario(nuevoUsuario);
            ListarUsuarios();
        }

        public void ListarUsuarios()
        {
            dataListUsuarios.DataSource = usuarioLogica.ListarUsuarios();
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            insertarUsuario();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }
    }
}
