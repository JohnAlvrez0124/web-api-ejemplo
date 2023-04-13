using Microsoft.EntityFrameworkCore;

namespace lenguje_de_programacion.Controllers.Entidades
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Maestro> Maestro { get; set; }

        public DbSet<Estudiante> Estudiante{ get; set; }



    }
}
