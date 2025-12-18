using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerramientasTotal.Models
{

    public enum TipoMovimientoInventario
    {
        Entrada,
        Salida,
        Ajuste
    }
    public class MovimientoInventario
    {
        public int Id { get; set; }
        public ProductoRow Producto { get; set; } = new ProductoRow();

        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        // "Entrada" o "Salida"
        public TipoMovimientoInventario TipoMovimiento { get; set; }

        // para el stock

        public int stockAntes { get; set; }
        public int stockDespues { get; set; }

        // íngreso

        public string Usuario { get; set; } = "";   
    }
}
