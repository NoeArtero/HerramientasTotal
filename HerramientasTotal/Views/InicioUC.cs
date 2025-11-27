using Guna.Charts.WinForms;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HerramientasTotal.Extras;

namespace HerramientasTotal.Views
{
    public partial class InicioUC : UserControl
    {
        private readonly System.Windows.Forms.Timer clockTimer;
        public InicioUC()
        {
            InitializeComponent();

            clockTimer = new System.Windows.Forms.Timer(); 
            clockTimer.Interval = 1000;
            clockTimer.Tick += (_, __) => UpdateClock();
            clockTimer.Start();

            components?.Add(clockTimer);



            //SOLO SIGNIFICATIVO (AÚN NO ES OFICIAL QUE ESTE ES EL CÓDIGO)
            //// Dataset de línea de ventas diarias
            var ds = new GunaLineDataset
            {
                Label = "Ventas ($)",
            };

            ds.DataPoints.Add("08:00", 120);
            ds.DataPoints.Add("10:00", 240);
            ds.DataPoints.Add("12:00", 380);
            ds.DataPoints.Add("14:00", 450);
            ds.DataPoints.Add("16:00", 520);
            ds.DataPoints.Add("18:00", 610);

            ChartVentasDia.Datasets.Clear();
            ChartVentasDia.Datasets.Add(ds);
            ChartVentasDia.Update();

            // Dataset de barras para inventario
            var dsInv = new GunaBarDataset
            {
                Label = "Unidades en stock",

            };
            dsInv.DataPoints.Add("Martillos", 150);
            dsInv.DataPoints.Add("Taladros", 87);
            dsInv.DataPoints.Add("Pulidoras", 50);
            dsInv.DataPoints.Add("Lavadoras", 78);
            dsInv.DataPoints.Add("Combo 1", 63);

            ChartInvDia.Datasets.Clear();
            ChartInvDia.Datasets.Add(dsInv);
            ChartInvDia.Update();

            // dataset de pagos
            var dsCat = new GunaPieDataset
            {
                Label = "Estado de pagos",

            };
            dsCat.DataPoints.Add("Pagados: 40", 40);
            dsCat.DataPoints.Add("Pendientes: 4", 4);
            dsCat.DataPoints.Add("Cancelados: 10", 10);
            dsCat.DataPoints.Add("Parciales: 30", 30);

            ChartCreAlDia.Datasets.Clear();
            ChartCreAlDia.Datasets.Add(dsCat);
            ChartCreAlDia.Update();


            //datos para el grid PROVISIONALES
            dgvResumen.Rows.Add("001", "Victor", "Pagado", "$15.00", "2024-06-01", "2024-06-01");
            dgvResumen.Rows.Add("002", "Antonio", "Pendiente", "$15.00", "2024-06-01", "2024-06-01");
            dgvResumen.Rows.Add("003", "Marcos", "Parcial", "$15.00", "2024-06-01", "2024-06-01");
            dgvResumen.Rows.Add("004", "Atilio", "Pagado", "$15.00", "2024-06-01", "2024-06-01");
            dgvResumen.Rows.Add("005", "Julio", "Cancelado", "$15.00", "2024-06-01", "2024-06-01");
            dgvResumen.Rows.Add("006", "Orlando", "Pendiente", "$15.00", "2024-06-01", "2024-06-01");
            dgvResumen.Rows.Add("007", "Manuel", "Pagado", "$15.00", "2024-06-01", "2024-06-01");
            dgvResumen.Rows.Add("008", "Osvaldo", "Parcial", "$15.00", "2024-06-01", "2024-06-01");

            /////////////////////SOLO SIGNIFICATIVO ///////////////////////
        }

        //////////////////////METODOS Y EVENTOS ///////////////////////

        private void UpdateClock()
        {
            var now = DateTime.Now;

            lblFecha.Text = now.ToString("dddd dd 'de' MMMM yyyy", new CultureInfo("es-ES"));
            lblHora.Text = now.ToString("HH:mm:ss");
        }


        ////////////////////////FIN METODOS Y EVENTOS ///////////////////////
    }
}
