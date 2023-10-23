using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTuristica.Shared.Entities
{
    public class SitiosRecorrido
    {
        public int Id { get; set; }

        public SitioTuristico SitioTuristico { get; set; }
        public int SitioTuristicoId { get; set; }

        public Recorrido Recorrido { get; set; }
        public int RecorridoId { get; set; }

    }
}
