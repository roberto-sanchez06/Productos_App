using Domain.Entities;
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
    public partial class FrmProductos : Form
    {
        private ProductoModel productoModel;
        public FrmProductos()
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
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.PModel = productoModel;
            frmProducto.ShowDialog();
            //esta linea fue para probar
            productoModel = frmProducto.PModel;
            //
           
            rtbProductView.Text = productoModel.ConvertAsJSON();
        }

        private void cmbFinderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFinderType.SelectedIndex)
            {
                //RANGO DE PRECIOS
                case 1:
                    lblPrecioFin.Visible = true;
                    lblPrecioIni.Visible = true;
                    txtFinder2.Visible = true;
                    break;
                //UNIDAD DE MEDIDA
                case 2:
                    break;
                //FECHA DE VENCIMIENTO
                case 3:
                    break;
                default:
                    
                    break;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            switch (cmbFinderType.SelectedIndex)
            {
                //ID
                case 0:
                    if (string.IsNullOrEmpty(txtFinder.Text))
                    {
                        MessageBox.Show("ERROR. Usted no ingresó ningun dato en la caja de texto", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(txtFinder.Text, out int codigo))
                    {
                        MessageBox.Show($"ERROR. El codigo {txtFinder.Text} no es valido", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Producto p = productoModel.GetProductoByID(codigo);
                    //falta agregar para que se muestre en pantalla
                    break;
                //RANGO DE PRECIOS
                case 1:
                    if (string.IsNullOrEmpty(txtFinder2.Text))
                    {
                        MessageBox.Show("ERROR. Usted no ingresó ningun dato en el precio inical", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!decimal.TryParse(txtFinder2.Text, out decimal precioIni))
                    {
                        MessageBox.Show($"ERROR. El precio inicial {txtFinder2.Text} no es valido", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (precioIni <= 0)
                    {
                        MessageBox.Show($"ERROR. El precio inicial {txtFinder2.Text} no puede ser menor o igual a 0", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrEmpty(txtFinder.Text))
                    {
                        MessageBox.Show("ERROR. Usted no ingresó ningun dato en el precio final", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!decimal.TryParse(txtFinder.Text, out decimal precioFin))
                    {
                        MessageBox.Show($"ERROR. El precio final  {txtFinder.Text} no es valido", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (precioFin <= 0)
                    {
                        MessageBox.Show($"ERROR. El precio final {txtFinder2.Text} no puede ser menor o igual a 0", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Producto[] productos = productoModel.GetProductosByRangoPrecio(precioIni, precioFin);
                    break;
                //UNIDAD DE MEDIDA
                case 2:
                    break;
                //FECHA DE VENCIMIENTO
                case 3:
                    break;
                default:

                    break;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmActualizar frmActualizar = new FrmActualizar();
            frmActualizar.PModel = productoModel;
            frmActualizar.ShowDialog();
            //esta linea fue para probar
            productoModel = frmActualizar.PModel;
            //

            rtbProductView.Text = productoModel.ConvertAsJSON();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminar frmEliminar = new frmEliminar();
            frmEliminar.PModel = productoModel;
            frmEliminar.ShowDialog();
            //esta linea fue para probar
            productoModel = frmEliminar.PModel;
            //

            rtbProductView.Text = productoModel.ConvertAsJSON();
        }
    }
}
