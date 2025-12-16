using Bogus;
using HerramientasTotal.Models;
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
    public partial class MovimientosProductosUC : UserControl
    {
        //conector con la clase ProductoRow
        private BindingList<ProductoRow> _data;
        public MovimientosProductosUC()
        {
            InitializeComponent();
            dgvProductosMovimientos.AutoGenerateColumns = false;
            dgvProductosMovimientos.RowTemplate.Height = 60;
            CargarDatosProvisionales();


            cmbCategoriaProductoMovimientos.DataSource = new List<string>
            {

               "Herramientas Manuales",
                "Herramientas Eléctricas",
                "Accesorios",
                "Equipos de Seguridad",
                "Todas"
            };
            cmbCategoriaProductoMovimientos.SelectedIndex = 4;

            cmbBuscarProveedorMovimiento.DataSource = new List<string>
            {
                "Proveedor A",
                "Proveedor B",
                "Proveedor C",
                "Proveedor D",
                "Todos"
            };
            cmbBuscarProveedorMovimiento.SelectedIndex = 4;
        }


        private void CargarDatosProvisionales()
        {
            string[] categorias = { "Herramientas Manuales", "Herramientas Eléctricas", "Accesorios", "Equipos de Seguridad" };
            string[] proveedores = { "Proveedor A", "Proveedor B", "Proveedor C", "Proveedor D" };

            var placeholder = new Bitmap(60, 60);
            using (var g = Graphics.FromImage(placeholder)) { g.Clear(Color.LightBlue); }

            var faker = new Faker<ProductoRow>()
                .RuleFor(p => p.Foto, f => placeholder)
                .RuleFor(p => p.Codigo, f => f.Random.Int(1, 100))
                .RuleFor(p => p.Nombre, f => f.Commerce.ProductName())
                .RuleFor(p => p.Categoria, f => f.PickRandom(categorias))
                .RuleFor(p => p.PrecioVenta, f => decimal.Parse(f.Commerce.Price(10, 500)))
                .RuleFor(p => p.Costo, (f, p) => Math.Round(p.PrecioVenta * f.Random.Decimal(0.5m, 0.9m), 2))
                .RuleFor(p => p.Proveedor, f => f.PickRandom(proveedores))
                .RuleFor(p => p.FechaIngreso, f => f.Date.Past(2));

            _data = new BindingList<ProductoRow>(faker.Generate(50));

            dgvProductosMovimientos.AutoGenerateColumns = false;
            dgvProductosMovimientos.DataSource = _data;

        }

    }
}
