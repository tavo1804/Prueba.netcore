using Microsoft.EntityFrameworkCore;
using prjSegundoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjSegundoCrud.DataContex
{
    public class AplicationDbContext : DbContext
    {

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {


        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Rol> Rol { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

    }
}
