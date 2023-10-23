using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTuristica.Shared.Entities
{
    public class SitioTuristico
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        public Ciudad Ciudad { get; set; }
        public int CiudadId { get; set; }

        public Actividad Actividad { get; set; }
        public int ActividadId { get; set; }

        public ICollection<SitiosRecorrido> SitiosRecorridos { get; set; }
    }
}
