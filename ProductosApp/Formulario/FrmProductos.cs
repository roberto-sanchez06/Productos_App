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

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.PModel = productoModel;
            frmProducto.ShowDialog();
            if (productoModel.GetAll()!=null)
            {
                Array.Sort(productoModel.GetAll(), new Producto.ProductoIDCompare());
            }
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
                    ValoresPorDefecto();
                    break;
                //UNIDAD DE MEDIDA
                case 2:
                    pnlRangoPrecios.Visible = false;
                    cmbUnidadMedida.Visible = true;
                    dtpCaducidad.Visible = false;
                    txtFinder.Visible = false;
                    ValoresPorDefecto();
                    break;
                //CADUCIDAD
                case 3:
                    pnlRangoPrecios.Visible = false;
                    cmbUnidadMedida.Visible = false;
                    dtpCaducidad.Visible = true;
                    txtFinder.Visible = false;
                    ValoresPorDefecto();
                    break;
                //TODOS
                case 4:
                    pnlRangoPrecios.Visible = false;
                    cmbUnidadMedida.Visible = false;
                    dtpCaducidad.Visible = false;
                    txtFinder.Visible = false;
                    ValoresPorDefecto();
                    break;
            }
        }
        public void ValoresPorDefecto()
        {
            cmbUnidadMedida.SelectedIndex = -1;
            txtFinder.Text = string.Empty;
            nudPrecioFin.Value = nudPrecioFin.Minimum;
            nudPrecioIni.Value = nudPrecioIni.Minimum;
            dtpCaducidad.Value = DateTime.Now;
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
                    if (p != null)
                    {
                        rtbProductView.Text=$"El producto con ID: {codigo} es: \n";
                        rtbProductView.Text += JsonConvert.SerializeObject(p);
                        txtFinder.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado un producto con ese codigo","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
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
                    if (productos != null)
                    {
                        rtbProductView.Text = $"Los productos con precio entre {nudPrecioIni.Value} y {nudPrecioFin.Value} son: \n";
                        rtbProductView.Text+= productoModel.ConvertASJSON(productos);
                    }
                    else
                    {
                        MessageBox.Show("No se han encontrado productos con dichas caracteristicas", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                //UNIDAD DE MEDIDA
                case 2:
                    if (cmbUnidadMedida.SelectedIndex >= 0)
                    {
                        productos = productoModel.GetProductosByUnidadMedida((UnidadMedida)cmbUnidadMedida.SelectedIndex);
                        if (productos != null)
                        {
                            rtbProductView.Text = $"Los productos con unidad de medida: {(UnidadMedida)cmbUnidadMedida.SelectedIndex} son: \n";
                            rtbProductView.Text += productoModel.ConvertASJSON(productos);
                        }
                        else
                        {
                            MessageBox.Show("No se han encontrado productos con dichas caracteristicas", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR. Usted no ha seleccionado ninguna unidad de medida", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                //FECHA DE VENCIMIENTO
                case 3:
                    DateTime dt = dtpCaducidad.Value;
                    productos = productoModel.GetProductosByFechaVencimiento(dt);
                    if (productos != null)
                    {
                        rtbProductView.Text = $"Los productos con caducidad anterior o igual a: {dt} son: \n";
                        rtbProductView.Text += productoModel.ConvertASJSON(productos);
                    }
                    else
                    {
                        MessageBox.Show("No se han encontrado productos con dichas caracteristicas", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case 4:
                    if (productoModel.GetAll() != null)
                    {
                        rtbProductView.Text = $"Todos los productos en existencia son: \n";
                        Array.Sort(productoModel.GetAll(),new Producto.ProductoIDCompare());
                        rtbProductView.Text += productoModel.ConvertAsJSON();
                    }
                    else
                    {
                        MessageBox.Show("Todavia no hay productos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                default:
                    MessageBox.Show("ERROR. Usted no ha seleccionado ninguna opcion de busqueda", "Mensaje de error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (productoModel.GetAll() != null)
            {
                FrmActualizar frmActualizar = new FrmActualizar();
                frmActualizar.PModel = productoModel;
                frmActualizar.ShowDialog();
                rtbProductView.Text = productoModel.ConvertAsJSON();
            }
            else
            {
                MessageBox.Show("No hay productos para actualizar", "Mensaje de error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (productoModel.GetAll()!=null)
            {
                frmEliminar frmEliminar = new frmEliminar();
                frmEliminar.PModel = productoModel;
                frmEliminar.ShowDialog();
                rtbProductView.Text = productoModel.ConvertAsJSON();
            }
            else
            {
                MessageBox.Show("No hay productos para eliminar", "Mensaje de error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                productoModel.GetProductosOrderByPrecio();
                rtbProductView.Text = "Los productos ordenados por su precio son: \n";
                rtbProductView.Text += productoModel.ConvertAsJSON();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensaje de error ",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
