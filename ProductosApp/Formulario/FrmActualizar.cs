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
    public partial class FrmActualizar : Form
    {
        public ProductoModel PModel { get; set; }
        public FrmActualizar()
        {
            InitializeComponent();
        }

        private void FrmActualizar_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Producto p;
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
            {

                MessageBox.Show("Campos vacios", "Hay campos necesarios vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            else
            {

                p = new Producto()
                {
                    Id = (int)nudId.Value,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Cantidad = (int)nudExistencia.Value,
                    Precio = nudPrecio.Value,
                    Caducidad = dtpVencimiento.Value,
                    UnidadMedida = (UnidadMedida)cmbUnidadMedida.SelectedIndex
                };
                PModel.Update(p);
                Dispose();

            }
        }
    }
}
