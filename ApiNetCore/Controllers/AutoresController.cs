using ApiNetCore.Contexts;
using ApiNetCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNetCore.Models;
using AutoMapper;

namespace ApiNetCore.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDTO>>> Get() {
            var autores = await context.Autores.Include(x => x.Libros).ToListAsync();
            var autoresDTO = mapper.Map<List<AutorDTO>>(autores);
            return autoresDTO;
        }

        [HttpGet("{id}", Name = "ObtenerAutor")]
        public async Task<ActionResult<AutorDTO>> Get(int id) {
            var autor = await context.Autores.Include(x => x.Libros).FirstOrDefaultAsync(x => x.Id == id);
            if (autor is null) {
                return NotFound();
            }

            var autorDTO = mapper.Map<AutorDTO>(autor);
            return autorDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutorNuevoDTO autorNuevo) {
            var autor = mapper.Map<Autor>(autorNuevo);
            context.Autores.Add(autor);
            await context.SaveChangesAsync();
            var autorDTO = mapper.Map<AutorDTO>(autor);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autorDTO.Id }, autorDTO);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor value) {
            if(id != value.Id) {
                return BadRequest();
            }
            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id) {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);
            if(autor is null) {
                return NotFound();
            }
            context.Autores.Remove(autor);
            context.SaveChanges();
            return autor;

        }

    }
}
