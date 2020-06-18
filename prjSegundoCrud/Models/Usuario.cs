using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prjSegundoCrud.Models
{
    public class Usuario
    {
        #region "Propiedades"

        [Key]
        public int Id { get; set; }

        [Required]
        public string Identificacion { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        [Display(Name ="Usuario")]
        public string User { get; set; }

        [Required]
        [Display(Name = "Clave")]
        public string Password { get; set; }

        public int IdRol { get; set; }
        [ForeignKey("IdRol")]

        public Rol Rol { get; set; }
        #endregion
    }
}
