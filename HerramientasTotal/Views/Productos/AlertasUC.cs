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
    public partial class AlertasUC : UserControl
    {
        public AlertasUC()
        {
            InitializeComponent();
            dgvProductosAlert.DataBindingComplete += dgvProductosAlert_DataBindingComplete;
            dgvProductosAlert.AutoGenerateColumns = false;
            dgvProductosAlert.RowTemplate.Height = 60;
            CargarDatosProvisionales();
            dgvProductosAlert.ClearSelection();
            

            //datos para los COMBO BOXES

            cmbBuscarEstadoAlert.Items.AddRange(new string[]
            {
                "Todos",
                "Suficiente",
                "Bajo",
                "Crítico",
                "Agotado"
            });
            cmbBuscarEstadoAlert.SelectedIndex = 0;

            cmbCategoriaAlert.Items.AddRange(new string[]
            {
                "Todas",
                "Herramientas Manuales",
                "Herramientas Eléctricas",
                "Accesorios",
                "Equipos de Seguridad"
            });
            cmbCategoriaAlert.SelectedIndex = 0;

            cmbFiltrarAlert.Items.AddRange(new string[]
            {
                "Todos",
                "Solo suficientes",
                "Solo Bajos",
                "Solo críticos",
                "Solo agotados"
            });
            cmbFiltrarAlert.SelectedIndex = 0;

            // fin datos para los COMBO BOXES
        }


        // valores provisionales para la tabla usando Bogus
        public void CargarDatosProvisionales()
        {
            string[] categorias =
   {
        "Herramientas Manuales", "Herramientas Eléctricas", "Accesorios", "Equipos de Seguridad"
    };

            string[] proveedores = { "Proveedor A", "Proveedor B", "Proveedor C", "Proveedor D" };

            var faker = new Faker<ProductoRow>("es")
                .RuleFor(p => p.Codigo, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.Nombre, f => f.Commerce.ProductName())
                .RuleFor(p => p.Categoria, f => f.PickRandom(categorias))
                .RuleFor(p => p.Proveedor, f => f.PickRandom(proveedores))
                .RuleFor(p => p.Stock, f => f.Random.Int(0, 40))
                .RuleFor(p => p.FechaIngreso, f => f.Date.Past(1))
                .RuleFor(p => p.Foto, f => CrearFoto(f))
                .FinishWith((f, p) => p.EstadoStock = CalcularEstadoStock(p.Stock));

            var lista = faker.Generate(50);

            dgvProductosAlert.AutoGenerateColumns = false;

            var prioridad = new Dictionary<string, int>
            {
                ["Agotado"] = 0,
                ["Crítico"] = 1,
                ["Bajo"] = 2,
                ["Suficiente"] = 3
            };

           lista = lista
                .OrderBy(p => prioridad[p.EstadoStock])
                .ThenBy(p => p.Nombre)
                .ToList();

            dgvProductosAlert.DataSource = lista;
            dgvProductosAlert.ClearSelection();
        }
        private string CalcularEstadoStock(int stock)
        {
            if (stock <= 0) return "Agotado";
            if (stock <= 3) return "Crítico";
            if (stock <= 10) return "Bajo";
            return "Suficiente";
        }

        private Image CrearFoto(Faker f)
        {
            var bmp = new Bitmap(48, 48);
            using var g = Graphics.FromImage(bmp);

            var color = Color.FromArgb(255, f.Random.Int(40, 200), f.Random.Int(40, 200), f.Random.Int(40, 200));
            g.Clear(color);

            using var font = new Font("Bahnschrift", 16, FontStyle.Bold);
            using var brush = new SolidBrush(Color.White);
            g.DrawString("HT", font, brush, new PointF(6, 10));

            return bmp;
        }

        // fin valores provisionales para la tabla usando Bogus

        //pintar el dgv segun el estado del stock
        private void dgvProductosAlert_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            RefrescarColoresYcontadores();
        }

        private void RefrescarColoresYcontadores()
        {
            int suficientes = 0, bajos = 0, criticos = 0, agotados = 0;

            foreach (DataGridViewRow row in dgvProductosAlert.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.DataBoundItem is not ProductoRow p) continue;

                switch (p.EstadoStock)
                {
                    case "Suficiente": suficientes++; break;
                    case "Bajo": bajos++; break;
                    case "Crítico": criticos++; break;
                    case "Agotado": agotados++; break;
                }

                Color back = p.EstadoStock switch
                {
                    "Suficiente" => Color.FromArgb(208, 255, 211), // verde suave
                    "Bajo" => Color.FromArgb(251, 236, 93), // amarillo suave
                    "Crítico" => Color.FromArgb(242, 185, 73), // naranja suave
                    "Agotado" => Color.FromArgb(255, 116, 108), // rojo suave
                    _ => Color.White
                };

                row.DefaultCellStyle.BackColor = back;
                row.DefaultCellStyle.SelectionBackColor = back;
            }

            lblSuficiente.Text = $"Suficientes: {suficientes}";
            lblBajos.Text = $"Bajos: {bajos}";
            lblCriticos.Text = $"Críticos: {criticos}";
            lblAgotados.Text = $"Agotados: {agotados}";
            lblTotal.Text = $"Total: {suficientes + bajos + criticos + agotados}";

        }
    }


}
