namespace Panaderia_Presentacion
{
    partial class FrmPagos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnIrPagina = new System.Windows.Forms.Button();
            this.cbxVentanas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataListPagos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.butAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textMetodo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtIDPedido = new System.Windows.Forms.TextBox();
            this.txtIDPago = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblFechaPago = new System.Windows.Forms.Label();
            this.lblIDUsuario = new System.Windows.Forms.Label();
            this.lblIDPago = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListPagos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnIrPagina);
            this.groupBox3.Controls.Add(this.cbxVentanas);
            this.groupBox3.Location = new System.Drawing.Point(884, 338);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(169, 121);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            // 
            // btnIrPagina
            // 
            this.btnIrPagina.Location = new System.Drawing.Point(25, 74);
            this.btnIrPagina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIrPagina.Name = "btnIrPagina";
            this.btnIrPagina.Size = new System.Drawing.Size(121, 25);
            this.btnIrPagina.TabIndex = 1;
            this.btnIrPagina.Text = "Ir a la página seleccionada";
            this.btnIrPagina.UseVisualStyleBackColor = true;
            // 
            // cbxVentanas
            // 
            this.cbxVentanas.FormattingEnabled = true;
            this.cbxVentanas.Location = new System.Drawing.Point(25, 32);
            this.cbxVentanas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxVentanas.Name = "cbxVentanas";
            this.cbxVentanas.Size = new System.Drawing.Size(121, 24);
            this.cbxVentanas.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(481, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "PAGOS";
            // 
            // dataListPagos
            // 
            this.dataListPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListPagos.Location = new System.Drawing.Point(91, 306);
            this.dataListPagos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataListPagos.Name = "dataListPagos";
            this.dataListPagos.RowHeadersWidth = 51;
            this.dataListPagos.RowTemplate.Height = 24;
            this.dataListPagos.Size = new System.Drawing.Size(787, 185);
            this.dataListPagos.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.butAceptar);
            this.groupBox2.Location = new System.Drawing.Point(933, 119);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(136, 111);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(36, 78);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 28);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(36, 49);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // butAceptar
            // 
            this.butAceptar.Location = new System.Drawing.Point(36, 21);
            this.butAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butAceptar.Name = "butAceptar";
            this.butAceptar.Size = new System.Drawing.Size(75, 23);
            this.butAceptar.TabIndex = 15;
            this.butAceptar.Text = "Aceptar";
            this.butAceptar.UseVisualStyleBackColor = true;
            this.butAceptar.Click += new System.EventHandler(this.butAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textMetodo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtMonto);
            this.groupBox1.Controls.Add(this.txtIDPedido);
            this.groupBox1.Controls.Add(this.txtIDPago);
            this.groupBox1.Controls.Add(this.lblMonto);
            this.groupBox1.Controls.Add(this.lblFechaPago);
            this.groupBox1.Controls.Add(this.lblIDUsuario);
            this.groupBox1.Controls.Add(this.lblIDPago);
            this.groupBox1.Location = new System.Drawing.Point(-3, 70);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(891, 187);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // textMetodo
            // 
            this.textMetodo.Location = new System.Drawing.Point(605, 79);
            this.textMetodo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textMetodo.Name = "textMetodo";
            this.textMetodo.Size = new System.Drawing.Size(261, 22);
            this.textMetodo.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(676, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Método de pago";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(183, 87);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(183, 126);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(261, 22);
            this.txtMonto.TabIndex = 18;
            // 
            // txtIDPedido
            // 
            this.txtIDPedido.Location = new System.Drawing.Point(181, 49);
            this.txtIDPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDPedido.Name = "txtIDPedido";
            this.txtIDPedido.Size = new System.Drawing.Size(100, 22);
            this.txtIDPedido.TabIndex = 17;
            // 
            // txtIDPago
            // 
            this.txtIDPago.Location = new System.Drawing.Point(181, 18);
            this.txtIDPago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDPago.Name = "txtIDPago";
            this.txtIDPago.Size = new System.Drawing.Size(100, 22);
            this.txtIDPago.TabIndex = 16;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(40, 129);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(44, 16);
            this.lblMonto.TabIndex = 15;
            this.lblMonto.Text = "Monto";
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.Location = new System.Drawing.Point(40, 87);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(103, 16);
            this.lblFechaPago.TabIndex = 13;
            this.lblFechaPago.Text = "Fecha del Pago";
            // 
            // lblIDUsuario
            // 
            this.lblIDUsuario.AutoSize = true;
            this.lblIDUsuario.Location = new System.Drawing.Point(40, 55);
            this.lblIDUsuario.Name = "lblIDUsuario";
            this.lblIDUsuario.Size = new System.Drawing.Size(64, 16);
            this.lblIDUsuario.TabIndex = 12;
            this.lblIDUsuario.Text = "IDPedido";
            // 
            // lblIDPago
            // 
            this.lblIDPago.AutoSize = true;
            this.lblIDPago.Location = new System.Drawing.Point(40, 25);
            this.lblIDPago.Name = "lblIDPago";
            this.lblIDPago.Size = new System.Drawing.Size(58, 16);
            this.lblIDPago.TabIndex = 11;
            this.lblIDPago.Text = "IDPAGO";
            // 
            // FrmPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataListPagos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPagos";
            this.Text = "FrmPAgos";
            this.Load += new System.EventHandler(this.FrmPagos_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListPagos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnIrPagina;
        private System.Windows.Forms.ComboBox cbxVentanas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataListPagos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button butAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtIDPedido;
        private System.Windows.Forms.TextBox txtIDPago;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblFechaPago;
        private System.Windows.Forms.Label lblIDUsuario;
        private System.Windows.Forms.Label lblIDPago;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textMetodo;
        private System.Windows.Forms.Label label1;
    }
}