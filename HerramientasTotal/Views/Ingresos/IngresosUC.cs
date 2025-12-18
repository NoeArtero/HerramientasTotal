using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Bogus;
using HerramientasTotal.Models;

namespace HerramientasTotal.Views.Ingresos
{
    public partial class IngresosUC : UserControl
    {
        private BindingList<IngresoRow> _ingresos;

        public IngresosUC()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarDatosProvisionales();
        }

        private void lblBuscarIngreso_TextChanged(object sender, EventArgs e)
        {
            // TODO: lógica de filtro por texto
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: lógica cuando cambie el combo (si lo necesitas)
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            // TODO: luego lo renombramos a btnEliminarIngreso_Click y agregamos lógica
        }

        private void ConfigurarGrid()
        {
            dgvIngresos.AutoGenerateColumns = false;
            dgvIngresos.ReadOnly = true;
            dgvIngresos.MultiSelect = false;
            dgvIngresos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngresos.AllowUserToAddRows = false;
            dgvIngresos.AllowUserToDeleteRows = false;
            dgvIngresos.RowHeadersVisible = false;
            dgvIngresos.RowTemplate.Height = 28;

            // Asigna las propiedades de enlace a cada columna
            // Asegúrate de que estos nombres coincidan con los Name de tus columnas en el diseñador
            dgvIngresos.Columns["colFecha"].DataPropertyName = "Fecha";
            dgvIngresos.Columns["colTipo"].DataPropertyName = "Tipo";
            dgvIngresos.Columns["colReferencia"].DataPropertyName = "Referencia";
            dgvIngresos.Columns["colCliente"].DataPropertyName = "Cliente";
            dgvIngresos.Columns["colOrigen"].DataPropertyName = "Origen";
            dgvIngresos.Columns["colMonto"].DataPropertyName = "Monto";
            dgvIngresos.Columns["colEstado"].DataPropertyName = "Estado";
            dgvIngresos.Columns["colRegistradoPor"].DataPropertyName = "RegistradoPor";
        }

        private void CargarDatosProvisionales()
        {
            var tipos = new[] { "Venta", "Cuota", "Pedido", "Otro" };
            var estados = new[] { "Registrado", "Pendiente", "Anulado" };

            var faker = new Faker<IngresoRow>("es")
                .RuleFor(x => x.Fecha, f => f.Date.Between(DateTime.Today.AddMonths(-2), DateTime.Today))
                .RuleFor(x => x.Tipo, f => f.PickRandom(tipos))
                .RuleFor(x => x.Referencia, f => $"F-{f.Random.Int(1000, 9999)}")
                .RuleFor(x => x.Cliente, f => f.Name.FullName())
                .RuleFor(x => x.Origen, (f, ingreso) =>
                {
                    switch (ingreso.Tipo)
                    {
                        case "Venta": return "Ventas";
                        case "Cuota": return "Cuotas";
                        case "Pedido": return "Pedidos";
                        default: return "Otros";
                    }
                })
                .RuleFor(x => x.Monto, f => Math.Round(f.Random.Decimal(10, 500), 2))
                .RuleFor(x => x.Estado, f => f.PickRandom(estados))
                .RuleFor(x => x.RegistradoPor, f => f.Internet.UserName());

            var lista = faker.Generate(40);
            _ingresos = new BindingList<IngresoRow>(lista);

            dgvIngresos.DataSource = _ingresos;
        }

        private void PanelBotonesAccion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
