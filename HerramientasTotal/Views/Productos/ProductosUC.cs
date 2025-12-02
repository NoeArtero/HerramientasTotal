using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bogus;
using HerramientasTotal.Models;




namespace HerramientasTotal.Views.Productos
{
    public partial class ProductosUC : UserControl
    {
        //conector con la clase ProductoRow
        private BindingList<ProductoRow> _data;
        public ProductosUC()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.RowTemplate.Height = 60; 
            CargarDatosProvisionales();



            // DATOS PROVICIONALES PARA LOS COMBOBOX
            cmbCategoriaProducto.DataSource = new List<string>
            {
                "Herramientas Manuales",
                "Herramientas Eléctricas",
                "Accesorios",
                "Equipos de Seguridad",
                "Todas"
            };
            cmbCategoriaProducto.SelectedIndex = 4;


            cmbBuscarProveedor.DataSource = new List<string>
            {
                "Proveedor A",
                "Proveedor B",
                "Proveedor C",
                "Proveedor D",
                "Todos"
            };
            cmbBuscarProveedor.SelectedIndex = 4;

            // FIN DATOS PROVICIONALES PARA LOS COMBOBOX
        }

        // valores provisionales para la tabla usando Bogus

        private void CargarDatosProvisionales()
        {
           string[] categorias = {"Herramientas Manuales", "Herramientas Eléctricas", "Accesorios", "Equipos de Seguridad"};
           string[] proveedores = {"Proveedor A", "Proveedor B", "Proveedor C", "Proveedor D"};

            var placeholder = new Bitmap(60, 60);
            using (var g = Graphics.FromImage(placeholder)) { g.Clear(Color.LightBlue); }

            var faker = new Faker<ProductoRow>()
                .RuleFor(p => p.Foto, f => placeholder)
                .RuleFor(p => p.Codigo, f => f.Random.Int(1,100))
                .RuleFor(p => p.Nombre, f => f.Commerce.ProductName())
                .RuleFor(p => p.Categoria, f => f.PickRandom(categorias))
                .RuleFor(p => p.Stock, f => f.Random.Int(0, 100))
                .RuleFor(p => p.PrecioVenta, f => decimal.Parse(f.Commerce.Price(10, 500)))
                .RuleFor(p => p.Costo, (f, p) => Math.Round(p.PrecioVenta * f.Random.Decimal(0.5m, 0.9m), 2))
                .RuleFor(p => p.Proveedor, f => f.PickRandom(proveedores))
                .RuleFor(p => p.FechaIngreso, f => f.Date.Past(2))
                .RuleFor(p => p.Estado, f => f.Random.Bool(0.8f));

            _data = new BindingList<ProductoRow>(faker.Generate(50));

            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = _data;

            lblTotalProductos.Text = $"Total de Productos: {_data.Count}";
        }
        

        // fin valores provisionales para la tabla usando Bogus
    }
}
