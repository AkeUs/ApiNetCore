using ApiNetCore.Contexts;
using ApiNetCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNetCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

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
        public async Task<ActionResult> Post([FromBody] AutorModelDTO autorModel) {
            var autor = mapper.Map<Autor>(autorModel);
            context.Autores.Add(autor);
            await context.SaveChangesAsync();
            var autorDTO = mapper.Map<AutorDTO>(autor);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autorDTO.Id }, autorDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AutorModelDTO autorActualizado) {
            var autor = mapper.Map<Autor>(autorActualizado);
            autor.Id = id;
            context.Entry(autor).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<AutorModelDTO> patchDocument) {
            if (patchDocument is null) {
                return BadRequest();
            }

            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autor is null) {
                return NotFound();
            }

            var autorDTO = mapper.Map<AutorModelDTO>(autor);
            patchDocument.ApplyTo(autorDTO, ModelState);
            var isValid = TryValidateModel(autor);

            if (!isValid) {
                return BadRequest(ModelState);
            }

            mapper.Map(autorDTO, autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Autor>> Delete(int id) {
            var autorId = context.Autores.Select(x => x.Id).FirstOrDefault(x => x == id);
            if(autorId == default(int)) {
                return NotFound();
            }
            context.Remove(new Autor { Id = autorId });
            await context.SaveChangesAsync();
            return Ok();

        }

    }
}
