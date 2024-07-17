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
        private bool datosCargados = false;

        public FrmUsuarios()
        {
            InitializeComponent();
            usuarioLogica = new UsuariosLogica();
            nuevoUsuario = new Usuarios();
            dataListUsuarios.CellClick += dataListUsuarios_CellClick;
        }

        private void dataListUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                btnLimpiar.Enabled = true;
                LlenarCamposConUsuarioSeleccionado();
            }
        }

        private void LlenarCamposConUsuarioSeleccionado()
        {
            if (!datosCargados || dataListUsuarios.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dataListUsuarios.SelectedRows[0];
            txtIdUsuario.Text = selectedRow.Cells["ID_usuario"].Value.ToString();
            txtNombre.Text = selectedRow.Cells["Nombre"].Value.ToString();
            txtDireccion.Text = selectedRow.Cells["Direccion"].Value.ToString();
            txtTelefono.Text = selectedRow.Cells["Telefono"].Value.ToString();
            txtEmail.Text = selectedRow.Cells["Correo_Electronico"].Value.ToString();
            txtContrasenia.Text = selectedRow.Cells["Contrasena"].Value.ToString();
        }

        private int ObtenerUsuarioId()
        {
            if (dataListUsuarios.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataListUsuarios.SelectedRows[0];
                return Convert.ToInt32(selectedRow.Cells["ID_usuario"].Value);
            }
            else
            {
                MessageBox.Show("Por favor selecciona un usuario para eliminar.");
                return -1;
            }
        }

        private void LimpiarCampos()
        {
            txtIdUsuario.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContrasenia.Text = string.Empty;
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
                dataListUsuarios.ClearSelection();
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
            dataListUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListUsuarios.MultiSelect = false;

            ListarUsuarios();
            datosCargados = true;

            if(dataListUsuarios.Rows.Count > 0)
            {
                dataListUsuarios.ClearSelection();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idUsuario = ObtenerUsuarioId();

            if(idUsuario != -1)
            {
                try
                {
                    usuarioLogica.EliminarUsuario(idUsuario);
                    MessageBox.Show("Usuario eliminado correctamente.");

                    ListarUsuarios();
                    LimpiarCampos();
                }catch(Exception ex)
                {
                    MessageBox.Show("Error al eliminar al usuario: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios actualizarUsuario = new Usuarios();
                actualizarUsuario.ID_usuario = Convert.ToInt32(txtIdUsuario.Text);
                actualizarUsuario.Nombre = txtNombre.Text;
                actualizarUsuario.Direccion = txtDireccion.Text;
                actualizarUsuario.Telefono = txtTelefono.Text;
                actualizarUsuario.Correo_Electronico = txtEmail.Text;
                actualizarUsuario.Contrasena = txtContrasenia.Text;

                usuarioLogica.ActualizarUsuario(actualizarUsuario);
                MessageBox.Show("Usuario actualizado correctamente.");
                ListarUsuarios();
                LimpiarCampos();
                dataListUsuarios.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar al usuario: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
