namespace ProductosApp.Formulario
{
    partial class FrmProductos
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbFinderType = new System.Windows.Forms.ComboBox();
            this.rtbProductView = new System.Windows.Forms.RichTextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.cmbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.txtFinder = new System.Windows.Forms.TextBox();
            this.txtFinder2 = new System.Windows.Forms.TextBox();
            this.lblPrecioIni = new System.Windows.Forms.Label();
            this.lblPrecioFin = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar);
            this.flowLayoutPanel1.Controls.Add(this.btnModificar);
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(391, 399);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(495, 52);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(3, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(109, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 30);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(215, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 30);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Nuevo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ordenar por precio";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmbFinderType
            // 
            this.cmbFinderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFinderType.FormattingEnabled = true;
            this.cmbFinderType.Items.AddRange(new object[] {
            "ID",
            "Rango de precios",
            "Unidad de medida",
            "Fecha de vencimiento"});
            this.cmbFinderType.Location = new System.Drawing.Point(12, 24);
            this.cmbFinderType.Name = "cmbFinderType";
            this.cmbFinderType.Size = new System.Drawing.Size(251, 21);
            this.cmbFinderType.TabIndex = 1;
            this.cmbFinderType.SelectedIndexChanged += new System.EventHandler(this.cmbFinderType_SelectedIndexChanged);
            // 
            // rtbProductView
            // 
            this.rtbProductView.Location = new System.Drawing.Point(12, 61);
            this.rtbProductView.Name = "rtbProductView";
            this.rtbProductView.ReadOnly = true;
            this.rtbProductView.Size = new System.Drawing.Size(874, 325);
            this.rtbProductView.TabIndex = 4;
            this.rtbProductView.Text = "";
            this.rtbProductView.TextChanged += new System.EventHandler(this.RtbProductView_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(742, 22);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(141, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Buscar";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cmbUnidadMedida
            // 
            this.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadMedida.FormattingEnabled = true;
            this.cmbUnidadMedida.Location = new System.Drawing.Point(269, 24);
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Size = new System.Drawing.Size(218, 21);
            this.cmbUnidadMedida.TabIndex = 7;
            this.cmbUnidadMedida.Visible = false;
            // 
            // txtFinder
            // 
            this.txtFinder.Location = new System.Drawing.Point(500, 24);
            this.txtFinder.Name = "txtFinder";
            this.txtFinder.Size = new System.Drawing.Size(207, 20);
            this.txtFinder.TabIndex = 8;
            // 
            // txtFinder2
            // 
            this.txtFinder2.Location = new System.Drawing.Point(269, 24);
            this.txtFinder2.Name = "txtFinder2";
            this.txtFinder2.Size = new System.Drawing.Size(211, 20);
            this.txtFinder2.TabIndex = 9;
            this.txtFinder2.Visible = false;
            // 
            // lblPrecioIni
            // 
            this.lblPrecioIni.AutoSize = true;
            this.lblPrecioIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.lblPrecioIni.Location = new System.Drawing.Point(336, 6);
            this.lblPrecioIni.Name = "lblPrecioIni";
            this.lblPrecioIni.Size = new System.Drawing.Size(77, 15);
            this.lblPrecioIni.TabIndex = 10;
            this.lblPrecioIni.Text = "Precio Inicial";
            this.lblPrecioIni.Visible = false;
            // 
            // lblPrecioFin
            // 
            this.lblPrecioFin.AutoSize = true;
            this.lblPrecioFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.lblPrecioFin.Location = new System.Drawing.Point(564, 6);
            this.lblPrecioFin.Name = "lblPrecioFin";
            this.lblPrecioFin.Size = new System.Drawing.Size(68, 15);
            this.lblPrecioFin.TabIndex = 11;
            this.lblPrecioFin.Text = "Precio final";
            this.lblPrecioFin.Visible = false;
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 463);
            this.Controls.Add(this.lblPrecioFin);
            this.Controls.Add(this.lblPrecioIni);
            this.Controls.Add(this.txtFinder2);
            this.Controls.Add(this.txtFinder);
            this.Controls.Add(this.cmbUnidadMedida);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.rtbProductView);
            this.Controls.Add(this.cmbFinderType);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FrmProductos";
            this.Text = "Catalogo de productos";
            this.Load += new System.EventHandler(this.FmrProductos_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cmbFinderType;
        private System.Windows.Forms.RichTextBox rtbProductView;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cmbUnidadMedida;
        private System.Windows.Forms.TextBox txtFinder;
        private System.Windows.Forms.TextBox txtFinder2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPrecioIni;
        private System.Windows.Forms.Label lblPrecioFin;
    }
}