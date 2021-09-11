using Domain.Entities;
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
    public partial class frmEliminar : Form
    {
        public ProductoModel PModel { get; set; }
        public frmEliminar()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto()
            {
                Id = (int)nudId.Value
            };
            PModel.Delete(p);

        }
    }
}
