using lenguje_de_programacion.Controllers.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lenguje_de_programacion.Controllers
{

    [ApiController]
    [Route("api/maestro")]
    public class MaestroController: ControllerBase  
    {
        [HttpGet]
        public async Task<ActionResult<List<Maestro>>> Get()
        {
            return await context.Maestro.ToListAsync();
        }

        private readonly ApplicationDbContext context;

        public MaestroController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Maestro maestro)
        {
            context.Add(maestro);
            await context.SaveChangesAsync();
            return Ok();


        }

        [HttpPut("{id:int}")] // api/maestro/1
        public async Task<ActionResult> Put(Maestro maestro, int id)
        {
            var existe = await context.Maestro.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return BadRequest("El id no existe en la base de datos");
            }


            if (id != maestro.id)
            {
                return BadRequest("El id del autor y el id de la ruta no coinciden");
            }

            context.Update(maestro);
            await context.SaveChangesAsync();
            return Ok();


        }

        [HttpDelete("{id:int}")] //api/autores/1
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Maestro.AnyAsync(x => x.id == id);

            if (!existe)
            {
                return BadRequest("El id no existe en la base de datos");
            }

            context.Remove(new Maestro() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }








    }
}
