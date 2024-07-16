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
    public partial class FrmPrincipalPanaderia : Form
    {
        private int childFormNumber = 0;

        public FrmPrincipalPanaderia()
        {
            InitializeComponent();
        }

        private void abrirProductoNuevo()
        {
            FrmProducto nuevofrmProducto = new FrmProducto();
            nuevofrmProducto.MdiParent = this;
            nuevofrmProducto.Show();
        }

        private void abrirCategoriaNuevo()
        {
            FrmCategoria nuevofrmCategoria = new FrmCategoria();
            nuevofrmCategoria.MdiParent = this;
            nuevofrmCategoria.Show();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            abrirProductoNuevo();
        }

        private void newToolStripButtonOpenFile(object sender, EventArgs e)
        {
            abrirProductoNuevo();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirProductoNuevo();
        }

        private void FrmPrincipalPanaderia_Load(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            abrirProductoNuevo();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCategoriaNuevo();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            abrirCategoriaNuevo();
        }
    }
}
