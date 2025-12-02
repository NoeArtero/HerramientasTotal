using HerramientasTotal.Extras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerramientasTotal.Views.Productos
{
    public partial class agregarProductoUC : UserControl
    {
        public agregarProductoUC()
        {
            InitializeComponent();

        }

        private void btnCancelarAgregarProducto_Click(object sender, EventArgs e)
        {
            if (Mensajes.MostrarConfirmacion("¿Seguro que quiere cancelar esta acción?", "Cancelar") == DialogResult.Yes)
            {
                Parent.Controls.Remove(this);
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (Mensajes.MostrarConfirmacion("¿Seguro que quiere agregar este producto?", "") == DialogResult.Yes)
            {
                Parent.Controls.Remove(this);
                Mensajes.MostrarMensaje("Producto agregado con éxito.", "Producto agregado");
            }
        }
    }
}
