using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prjSegundoCrud.Models
{
    public class Cliente
    {

        #region "Propiedades"

        [Key]
        public int Id { get; set; }

        [Required]
        public string Identificacion { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Direccion { get; set; }

        #endregion

    }
}
