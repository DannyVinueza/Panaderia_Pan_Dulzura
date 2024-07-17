namespace Panaderia_Presentacion
{
    partial class FrmPedidos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxUsuarios = new System.Windows.Forms.ComboBox();
            this.dateTimeFechaPedido = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtIDPedido = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.lblFechaPedido = new System.Windows.Forms.Label();
            this.lblIDUsuario = new System.Windows.Forms.Label();
            this.lblIDPedido = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.butAceptar = new System.Windows.Forms.Button();
            this.dataListPedidos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxUsuarios);
            this.groupBox1.Controls.Add(this.dateTimeFechaPedido);
            this.groupBox1.Controls.Add(this.dateTimeFechaEntrega);
            this.groupBox1.Controls.Add(this.txtEstado);
            this.groupBox1.Controls.Add(this.txtIDPedido);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.lblFechaEntrega);
            this.groupBox1.Controls.Add(this.lblFechaPedido);
            this.groupBox1.Controls.Add(this.lblIDUsuario);
            this.groupBox1.Controls.Add(this.lblIDPedido);
            this.groupBox1.Location = new System.Drawing.Point(83, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 188);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // cbxUsuarios
            // 
            this.cbxUsuarios.FormattingEnabled = true;
            this.cbxUsuarios.Location = new System.Drawing.Point(394, 60);
            this.cbxUsuarios.Name = "cbxUsuarios";
            this.cbxUsuarios.Size = new System.Drawing.Size(121, 24);
            this.cbxUsuarios.TabIndex = 21;
            // 
            // dateTimeFechaPedido
            // 
            this.dateTimeFechaPedido.Location = new System.Drawing.Point(394, 90);
            this.dateTimeFechaPedido.Name = "dateTimeFechaPedido";
            this.dateTimeFechaPedido.Size = new System.Drawing.Size(261, 22);
            this.dateTimeFechaPedido.TabIndex = 20;
            this.dateTimeFechaPedido.Value = new System.DateTime(2024, 7, 9, 21, 37, 29, 0);
            // 
            // dateTimeFechaEntrega
            // 
            this.dateTimeFechaEntrega.Location = new System.Drawing.Point(394, 122);
            this.dateTimeFechaEntrega.Name = "dateTimeFechaEntrega";
            this.dateTimeFechaEntrega.Size = new System.Drawing.Size(261, 22);
            this.dateTimeFechaEntrega.TabIndex = 19;
            this.dateTimeFechaEntrega.Value = new System.DateTime(2024, 7, 9, 21, 37, 29, 0);
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(394, 156);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(261, 22);
            this.txtEstado.TabIndex = 18;
            // 
            // txtIDPedido
            // 
            this.txtIDPedido.Enabled = false;
            this.txtIDPedido.Location = new System.Drawing.Point(394, 26);
            this.txtIDPedido.Name = "txtIDPedido";
            this.txtIDPedido.Size = new System.Drawing.Size(100, 22);
            this.txtIDPedido.TabIndex = 16;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(252, 156);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(50, 16);
            this.lblEstado.TabIndex = 15;
            this.lblEstado.Text = "Estado";
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Location = new System.Drawing.Point(252, 127);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(114, 16);
            this.lblFechaEntrega.TabIndex = 14;
            this.lblFechaEntrega.Text = "Fecha de Entrega";
            // 
            // lblFechaPedido
            // 
            this.lblFechaPedido.AutoSize = true;
            this.lblFechaPedido.Location = new System.Drawing.Point(252, 95);
            this.lblFechaPedido.Name = "lblFechaPedido";
            this.lblFechaPedido.Size = new System.Drawing.Size(114, 16);
            this.lblFechaPedido.TabIndex = 13;
            this.lblFechaPedido.Text = "Fecha del Pedido";
            // 
            // lblIDUsuario
            // 
            this.lblIDUsuario.AutoSize = true;
            this.lblIDUsuario.Location = new System.Drawing.Point(252, 63);
            this.lblIDUsuario.Name = "lblIDUsuario";
            this.lblIDUsuario.Size = new System.Drawing.Size(67, 16);
            this.lblIDUsuario.TabIndex = 12;
            this.lblIDUsuario.Text = "IDUsuario";
            // 
            // lblIDPedido
            // 
            this.lblIDPedido.AutoSize = true;
            this.lblIDPedido.Location = new System.Drawing.Point(252, 32);
            this.lblIDPedido.Name = "lblIDPedido";
            this.lblIDPedido.Size = new System.Drawing.Size(64, 16);
            this.lblIDPedido.TabIndex = 11;
            this.lblIDPedido.Text = "IDPedido";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnActualizar);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.butAceptar);
            this.groupBox2.Location = new System.Drawing.Point(83, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(915, 58);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(693, 15);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(102, 37);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(472, 15);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(102, 37);
            this.btnActualizar.TabIndex = 17;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(255, 15);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(102, 37);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // butAceptar
            // 
            this.butAceptar.Location = new System.Drawing.Point(40, 15);
            this.butAceptar.Name = "butAceptar";
            this.butAceptar.Size = new System.Drawing.Size(102, 37);
            this.butAceptar.TabIndex = 15;
            this.butAceptar.Text = "Aceptar";
            this.butAceptar.UseVisualStyleBackColor = true;
            this.butAceptar.Click += new System.EventHandler(this.butAceptar_Click);
            // 
            // dataListPedidos
            // 
            this.dataListPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListPedidos.Location = new System.Drawing.Point(83, 324);
            this.dataListPedidos.Name = "dataListPedidos";
            this.dataListPedidos.RowHeadersWidth = 51;
            this.dataListPedidos.RowTemplate.Height = 24;
            this.dataListPedidos.Size = new System.Drawing.Size(915, 199);
            this.dataListPedidos.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(490, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "PEDIDOS";
            // 
            // FrmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 545);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataListPedidos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPedidos";
            this.Text = "FrmPedidos";
            this.Load += new System.EventHandler(this.FrmPedidos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimeFechaPedido;
        private System.Windows.Forms.DateTimePicker dateTimeFechaEntrega;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtIDPedido;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.Label lblFechaPedido;
        private System.Windows.Forms.Label lblIDUsuario;
        private System.Windows.Forms.Label lblIDPedido;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button butAceptar;
        private System.Windows.Forms.DataGridView dataListPedidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxUsuarios;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
    }
}