using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerramientasTotal.Models
{
    public class IngresoRow
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }           // Venta, Cuota, Pedido, Otro
        public string Referencia { get; set; }     // Nº de factura, pedido, etc.
        public string Cliente { get; set; }
        public string Origen { get; set; }         // Ventas, Cuotas, Pedidos, Otro
        public decimal Monto { get; set; }
        public string Estado { get; set; }         // Registrado, Pendiente, Anulado
        public string RegistradoPor { get; set; }
    }
}
