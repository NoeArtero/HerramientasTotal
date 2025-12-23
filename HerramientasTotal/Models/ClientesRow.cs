using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerramientasTotal.Models
{
    public class ClienteRow
    {
        public int Id { get; set; }              // N°
        public string Nombre { get; set; } = ""; // Nombre
        public string Telefono { get; set; } = "";// Teléfono
        public string Direccion { get; set; } = "";// Dirección
        public string Tipo { get; set; } = "";    // Contado / Crédito
        public string Estado { get; set; } = "";  // Activo / Inactivo / Bloqueado
    }
}

