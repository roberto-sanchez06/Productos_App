using Domain.Enums;
using Infraestructura.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosApp.Formulario
{
    public partial class FmrProductos : Form
    {
        private ProductoModel productoModel;
        public FmrProductos()
        {
            productoModel = new ProductoModel();
            InitializeComponent();
        }

        private void RtbProductView_TextChanged(object sender, EventArgs e)
        {

        }

        private void FmrProductos_Load(object sender, EventArgs e)
        {
            cmbUnidadMedida.Items.AddRange(Enum.GetValues(typeof(UnidadMedida)).Cast<object>().ToArray());
        }

        private void TxtFinder_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmProductos frmProducto = new FrmProductos();
            frmProducto.PModel = productoModel;
            frmProducto.ShowDialog();

            rtbProductView.Text = productoModel.ConvertAsJSON();
            Dispose();
        }
    }
}
