using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerramientasTotal.Models
{
    public class Cliente : Persona
    {
        public int IdCliente { get; set; } 
        public string ContactoEmergencia { get; set; } = "";
        public string Contacto { get; set; } = "";

    }
}
