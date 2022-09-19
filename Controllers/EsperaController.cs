using APIDesafio.Data;
using APIDesafio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDesafio.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class EsperaController : ControllerBase {
        private readonly AppDbContext _context;
        public EsperaController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Espera>> GetListEs() {
            try {
                var esperas = _context.Esperas.AsNoTracking().Take(1).ToList();
                return esperas;
            }
            catch (Exception) {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }


        [HttpGet("{id:int}", Name = "ObterEspera")]
        public ActionResult<Espera> GetID(int id) {

            try {
                var espera = _context.Esperas.FirstOrDefault(e => e.ID == id);
                if (espera is null) {
                    return NotFound("Espera não encontrado...");
                }
                return espera;
            }
            catch (Exception) {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
            
        }

        [HttpPost]
        public ActionResult PostEs(Espera espera) {
            if (espera is null)
                return BadRequest();

            _context.Esperas.Add(espera);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterEspera",
                new { id = espera.ID }, espera);
        }

        [HttpPut("{id:int}")]
        public ActionResult PutEs(int id, Espera espera) {
            if (id != espera.ID) {
                return BadRequest();
            }

            _context.Entry(espera).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(espera);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteEs(int id) {
            var espera = _context.Esperas.FirstOrDefault(e => e.ID == id);

            if (espera is null) {
                return NotFound("EsperaID não localizado...");
            }
            _context.Esperas.Remove(espera);
            _context.SaveChanges();

            return Ok(espera);
        }
    }
}