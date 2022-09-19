using APIDesafio.Data;
using APIDesafio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDesafio.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase {
        private readonly AppDbContext _context;
        public AtendimentoController(AppDbContext context) {
            _context = context;
        }
      
        [HttpGet]
        public ActionResult<IEnumerable<Atendimento>> GetListAt() {
            try {
                var atendimentos = _context.Atendimentos.AsNoTracking().ToList();
                if (atendimentos is null) {
                    return NotFound();
                }
                return atendimentos;
            }
            catch (Exception) {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar sua solicitação.");
            }
            
        }

        [HttpGet("{id:int}", Name = "ObterAtendimento")]
        public ActionResult<Atendimento> GetID(int id) {
            try {
                var atendimento = _context.Atendimentos.FirstOrDefault(p => p.ID == id);
                if (atendimento is null) {
                    return NotFound("Atendimento não encontrado...");
                }
                return Ok(atendimento);
            }
            catch (Exception) {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar sua solicitação.");
            }
            
        }

        [HttpPost]
        public ActionResult PostAt(Atendimento atendimento) {
            if (atendimento is null)
                return BadRequest();

            _context.Atendimentos.Add(atendimento);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterAtendimento",
                new { id = atendimento.ID }, atendimento);
        }

        [HttpPut("{id:int}")]
        public ActionResult PutAt(int id, Atendimento atendimento) {
            if (id != atendimento.ID) {
                return BadRequest();
            }

            _context.Entry(atendimento).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(atendimento);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteAt(int id) {
            var atendimento = _context.Atendimentos.FirstOrDefault(p => p.ID == id);
            //var atendimento = _context.Atendimentos.Find(id);

            if (atendimento is null) {
                return NotFound("Atendimento não localizado...");
            }
            _context.Atendimentos.Remove(atendimento);
            _context.SaveChanges();

            return Ok(atendimento);
        }
    }
}
