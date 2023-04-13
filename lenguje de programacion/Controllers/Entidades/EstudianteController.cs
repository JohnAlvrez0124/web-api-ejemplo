using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lenguje_de_programacion.Controllers.Entidades
{

    [ApiController]
    [Route("api/Estudiante")]
    public class EstudianteController:ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Estudiante>>> Get()
        {
            return await context.Estudiante.ToListAsync();
        }

        private readonly ApplicationDbContext context;

        public EstudianteController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Estudiante estudiante)
        {
            context.Add(estudiante);
            await context.SaveChangesAsync();
            return Ok();


        }

        [HttpPut("{id:int}")] // api/maestro/1
        public async Task<ActionResult> Put(Estudiante estudiante, int id)
        {
            var existe = await context.Estudiante.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return BadRequest("El id no existe en la base de datos");
            }


            if (id != estudiante.id)
            {
                return BadRequest("El id del autor y el id de la ruta no coinciden");
            }

            context.Update(estudiante);
            await context.SaveChangesAsync();
            return Ok();


        }

        [HttpDelete("{id:int}")] //api/autores/1
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Estudiante.AnyAsync(x => x.id == id);

            if (!existe)
            {
                return BadRequest("El id no existe en la base de datos");
            }

            context.Remove(new Estudiante() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }





    }
}
