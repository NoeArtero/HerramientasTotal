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
    public partial class ProveedoresUC : UserControl
    {
        public ProveedoresUC()
        {
            InitializeComponent();
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            agregarProveedorUC agregarProveedorUC = new agregarProveedorUC();
            agregarProveedorUC.Show();
            this.Controls.Add(agregarProveedorUC);
            agregarProveedorUC.BringToFront();
            agregarProveedorUC.Location = new Point((this.Width - agregarProveedorUC.Width) / 2
                                                   , (this.Height - agregarProveedorUC.Height) / 2);

        }
    }
}
