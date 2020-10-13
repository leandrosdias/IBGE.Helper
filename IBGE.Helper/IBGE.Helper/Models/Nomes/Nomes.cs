using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBGE.Helper.Models.Nomes
{
    public class Nomes
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("sexo")]
        public string Genero { get; set; }
        [JsonProperty("localidade")]
        public string Localidade { get; set; }
        [JsonProperty("res")]
        public Result[] Result { get; set; }
    }

    public class Result
    {
        [JsonProperty("periodo")]
        public string Periodo { get; set; }
        [JsonProperty("frequencia")]
        public int Frequencia { get; set; }
    }

    public class NameFrequency
    {
        public string Name { get; set; }
        public string Genero { get; set; }
        public string Localidade { get; set; }
        public int InitialYear { get; set; }
        public int FinalYear { get; set; }
        public int Frequency { get; set; }
    }

}