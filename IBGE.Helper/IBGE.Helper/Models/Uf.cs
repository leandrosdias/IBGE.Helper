namespace IBGE.Helper.Models
{
    public class Uf
    {
        public string Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public Regiao Regiao { get; set; }
    }
}
