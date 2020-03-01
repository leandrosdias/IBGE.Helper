namespace IBGE.Helper.Models
{
    public class SubDistrito
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public Distrito Distrito { get; set; }
    }
}
