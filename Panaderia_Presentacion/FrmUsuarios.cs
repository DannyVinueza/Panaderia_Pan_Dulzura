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
            try
            {
                nuevoUsuario.Nombre = txtNombre.Text;
                nuevoUsuario.Direccion = txtDireccion.Text;
                nuevoUsuario.Telefono = txtTelefono.Text;
                nuevoUsuario.Correo_Electronico = txtEmail.Text;
                nuevoUsuario.Contrasena = txtContrasenia.Text;
                usuarioLogica.InsertarUsuario(nuevoUsuario);
                MessageBox.Show("Usuario insertado correctamente");
                ListarUsuarios();
            }
            catch (Exception ex) {
                MessageBox.Show("Error al insertar el usuario: " + ex.Message);
            }
        }

        public void ListarUsuarios()
        {
            try
            {
                dataListUsuarios.DataSource = usuarioLogica.ListarUsuarios();
            }
            catch (Exception ex) {
                MessageBox.Show("Error al listar los usuarios: " + ex.Message);
            }
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
