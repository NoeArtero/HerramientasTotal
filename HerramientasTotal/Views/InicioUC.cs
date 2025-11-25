using Guna.Charts.WinForms;
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
        public InicioUC()
        {
            InitializeComponent();


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
            dsInv.DataPoints.Add("Martillos", 150);
            dsInv.DataPoints.Add("Martillos", 150);
            dsInv.DataPoints.Add("Martillos", 150);
            dsInv.DataPoints.Add("Martillos", 150);

            ChartInvDia.Datasets.Clear();
            ChartInvDia.Datasets.Add(dsInv);
            ChartInvDia.Update();

            // dataset de categorias
            var dsCat = new GunaPieDataset
            {
                Label = "Categorías de productos",
            };
            dsCat.DataPoints.Add("Pagado", 40);
            dsCat.DataPoints.Add("Eléctricas", 4);
            dsCat.DataPoints.Add("Eléctricas", 10);
            dsCat.DataPoints.Add("Eléctricas", 30);

            ChartCreAlDia.Datasets.Clear();
            ChartCreAlDia.Datasets.Add(dsCat);
            ChartCreAlDia.Update();

        }


       
    }
}
