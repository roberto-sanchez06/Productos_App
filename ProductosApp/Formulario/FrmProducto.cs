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
using Domain.Enums;
using Domain.Entities;

namespace ProductosApp.Formulario
{
    public partial class FrmProducto : Form
    {
        public ProductoModel PModel { get; set; }
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            cmbUnidadMedida.Items.AddRange(Enum.GetValues(typeof(UnidadMedida)).Cast<object>().ToArray());
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

            Producto p;
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text) || cmbUnidadMedida.SelectedIndex == -1)
            {

                MessageBox.Show("Campos vacios", "Hay campos necesarios vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }
            
            else {

                 p = new Producto()
                {
                    Id = PModel.GetLastProductoID() + 1,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Cantidad = (int)nudExistencia.Value,
                    Precio = nudPrecio.Value,
                    Caducidad = dtpVencimiento.Value,
                    UnidadMedida = (UnidadMedida)cmbUnidadMedida.SelectedIndex
                };
                PModel.Add(p);
                Dispose();

            }
            
            
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
