using System.ComponentModel.DataAnnotations;

namespace RuanApi.Models
{
    public class Certificacao
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = null!;

        [Required]
        public string Instituicao { get; set; } = null!;

        public DateTime DataConclusao { get; set; }

        [Required]
        public string LinkCertificado { get; set; } = null!;
    }
}