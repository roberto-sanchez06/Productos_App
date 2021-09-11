using Domain.Entities;
using Domain.Enums;
using Infraestructura.Productos;
using Newtonsoft.Json;
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
                //ID
                case 0:
                    pnlRangoPrecios.Visible = false;
                    cmbUnidadMedida.Visible = false;
                    dtpCaducidad.Visible = false;
                    txtFinder.Visible = true;
                    break;
                //RANGO DE PRECIOS
                case 1:
                    pnlRangoPrecios.Visible = true;
                    cmbUnidadMedida.Visible = false;
                    dtpCaducidad.Visible = false;
                    txtFinder.Visible = false;
                    break;
                //UNIDAD DE MEDIDA
                case 2:
                    pnlRangoPrecios.Visible = false;
                    cmbUnidadMedida.Visible = true;
                    dtpCaducidad.Visible = false;
                    txtFinder.Visible = false;
                    break;
                //CADUCIDAD
                case 3:
                    pnlRangoPrecios.Visible = false;
                    cmbUnidadMedida.Visible = false;
                    dtpCaducidad.Visible = true;
                    txtFinder.Visible = false;
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
                        txtFinder.Text = string.Empty;
                        return;
                    }
                    Producto p = productoModel.GetProductoByID(codigo);
                    rtbProductView.Text= JsonConvert.SerializeObject(p);
                    //falta agregar para que se muestre en pantalla
                    break;
                //RANGO DE PRECIOS
                case 1:
                    if (nudPrecioFin.Value < nudPrecioIni.Value)
                    {
                        MessageBox.Show("ERROR. El precio inicial no puede ser menor al final","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        nudPrecioFin.Value = nudPrecioFin.Minimum;
                        nudPrecioIni.Value = nudPrecioIni.Minimum;
                        return;
                    }
                    Producto[] productos = productoModel.GetProductosByRangoPrecio(nudPrecioIni.Value, nudPrecioFin.Value);
                    rtbProductView.Text = productoModel.ConvertASJSON(productos);
                    break;
                //UNIDAD DE MEDIDA
                case 2:
                    switch (cmbUnidadMedida.SelectedIndex)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                            productos = productoModel.GetProductosByUnidadMedida((UnidadMedida) cmbUnidadMedida.SelectedIndex);
                            rtbProductView.Text = productoModel.ConvertASJSON(productos);
                            break;
                        default:
                            MessageBox.Show("ERROR. Usted no ha seleccionado ninguna unidad de medida", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }
                    break;
                //FECHA DE VENCIMIENTO
                case 3:
                    DateTime dt = dtpCaducidad.Value;
                    productos = productoModel.GetProductosByFechaVencimiento(dt);
                    rtbProductView.Text = productoModel.ConvertASJSON(productos);
                    break;
                default:
                    MessageBox.Show("ERROR. Usted no ha seleccionado ninguna opcion de busqueda", "Mensaje de error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
            }
        }
    }
}
