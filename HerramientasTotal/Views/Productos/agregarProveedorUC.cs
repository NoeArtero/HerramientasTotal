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
    public partial class agregarProveedorUC : UserControl
    {
        public agregarProveedorUC()
        {
            InitializeComponent();
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            if (Mensajes.MostrarConfirmacion("¿Seguro que quiere guardar este proveedor?", "Agregar proveedor") == DialogResult.Yes)
            {
                Parent.Controls.Remove(this);
                Mensajes.MostrarMensaje("Proveedor agregado con éxito.", "Proveedor agregado");
            }
        }

        private void btnCancelarAgregarProveedor_Click(object sender, EventArgs e)
        {
            if (Mensajes.MostrarConfirmacion("¿Seguro que quiere cancelar esta acción?", "") == DialogResult.Yes)
            {
                Parent.Controls.Remove(this);
            }
        }

        private void btnElegirImagenProveedor_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog.FileName;
                imgAgregarProveedor.Image = Image.FromFile(rutaImagen);
                imgAgregarProveedor.SizeMode = PictureBoxSizeMode.StretchImage;
            }


        }
    }
}
