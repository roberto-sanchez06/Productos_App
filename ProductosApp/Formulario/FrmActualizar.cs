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
            cmbUnidadMedida.Items.AddRange(Enum.GetValues(typeof(UnidadMedida)).Cast<object>().ToArray());
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Producto p;
          
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text)|| cmbUnidadMedida.SelectedIndex == -1)
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

                    try
                    {
                        PModel.Update(p);
                    }
                    catch (Exception ex)
                    {
                    MessageBox.Show("No encontrado", "El producto que desea actualizar no existe", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    
                    Dispose();
                }





     
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
