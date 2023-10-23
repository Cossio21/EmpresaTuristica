using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTuristica.Shared.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Cedula { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string Celular { get; set; }
    }
}
