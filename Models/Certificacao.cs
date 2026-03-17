namespace RuanApi.Models
{
    public class Certificacao
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Instituicao { get; set; }

        public DateTime DataConclusao { get; set; }

        public string LinkCertificado { get; set; }
    }
}