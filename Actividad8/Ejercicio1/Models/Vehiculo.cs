using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class Vehiculo 
    {
        public string Patente {  get; set; }
        public string Importe { get; set; }

        public Importar(string cadena)
        {
            if (Patente.Length == 6 || Patente.Length == 7)
            {
                Patente = p;
            }
            else
            {
                throw new PatenteException("Patente con formato incorrecto");
            }
            Importe = i;
        }

        public override string ToString()
        {
            return $"Patente {Patente} , importe {Importe}";
        }
    }
}
