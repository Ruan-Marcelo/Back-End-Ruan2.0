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

        public CertificacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Certificacoes.ToList());
        }

        [HttpPost]
        public IActionResult Post(Certificacao cert)
        {
            _context.Certificacoes.Add(cert);
            _context.SaveChanges();
            return Ok(cert);
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