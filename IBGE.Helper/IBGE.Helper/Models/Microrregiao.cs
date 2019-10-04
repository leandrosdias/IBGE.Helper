namespace IBGE.Helper.Models
{
    public class Microrregiao
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public Mesorregiao Mesorregiao { get; set; }
    }
}
