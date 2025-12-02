using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerramientasTotal.Models
{
    public class MovimientoInventario
    {
        public int Id { get; set; }
        public ProductoRow Producto { get; set; } = new ProductoRow();

        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        // "Entrada" o "Salida"
        public string TipoMovimiento { get; set; } = "";
    }
}
