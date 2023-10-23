using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTuristica.Shared.Entities
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        public string Fecha { get; set; }
        public string Hora { get; set; }

        [Required]
        public string Estado{ get; set; }

        [Required]
        public string PagoInicial{ get; set;}

        [Required]
        public string PagoFinal { get; set;}

        public Recorrido Recorrido { get; set; }
        public int RecorridoId { get; set; }

        public Guia Guia { get; set; }
        public int GuiaId { get; set;}

        public Cliente Cliente { get; set; }
        public int ClienteId { get;set; }
    }
}
