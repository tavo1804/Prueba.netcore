using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prjSegundoCrud.Models
{
    public class Rol
    {
        #region "Porpiedades"

        [Key]
        public int Id { get; set; }

        [Required]
        public string RolName { get; set; }

        #endregion
    }
}
