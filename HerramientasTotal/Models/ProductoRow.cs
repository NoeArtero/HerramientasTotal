using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerramientasTotal.Models
{
    public class ProductoRow
    {
        public Image Foto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Costo { get; set; }
        public string Proveedor { get; set; } 
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }


        public decimal Ganancia => Math.Max(0, PrecioVenta - Costo);
        
    }
}
