using Microsoft.AspNetCore.Mvc;
using RuanApi.Data;
using RuanApi.Models;

namespace RuanApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Construtor
        public CertificacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var certs = _context.Certificacoes.ToList();
            return Ok(certs);
        }

        [HttpPost]
        public IActionResult Create(Certificacao c)
        {
            _context.Certificacoes.Add(c);
            _context.SaveChanges();
            return Ok(c);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cert = _context.Certificacoes.Find(id);
            if (cert == null) return NotFound();

            _context.Certificacoes.Remove(cert);
            _context.SaveChanges();
            return Ok();
        }
    }
}