using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerramientasTotal.Models
{

    public enum EstadoPago
    {
        Pagado,
        Pendiente,
        Atrasado,
        Parciales
    }

    public class Pago
    {


        public int Id { get; set; }

        // Cliente asociado al pago
        public Cliente Cliente { get; set; } = new Cliente();

        // Información del pago
        public decimal MontoCuota { get; set; }
        public decimal MontoPagado { get; set; }

        // Estados del pago
        public EstadoPago EstadoDePago { get; set; }

        public DateTime FechaPago { get; set; }

    }
}