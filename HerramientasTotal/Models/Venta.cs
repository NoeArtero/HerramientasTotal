using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerramientasTotal.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();
        public DateTime FechaVenta { get; set; }
        public string MetodoPago { get; set; } = "";
        public decimal Total { get; set; }

        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}


