using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBGE.Helper.Models.Nomes
{
    public class UtilsNames
    {
        public static List<NameFrequency> GetNameFrequencies(Nomes nome)
        {
            var result = new List<NameFrequency>();

            foreach (var frequency in nome.Result)
            {
                var nameFrequency = new NameFrequency
                {
                    Name = nome.Nome,
                    Genero = nome.Genero,
                    Localidade = nome.Localidade,
                };

                var yearsStr = frequency.Periodo.Split(',');
                if (yearsStr.Length == 1)
                {
                    nameFrequency.InitialYear = DateTime.MinValue.Year;
                    nameFrequency.FinalYear = Convert.ToInt32(yearsStr[0].Replace("[", ""));
                    nameFrequency.Frequency = frequency.Frequencia;
                }

                if (yearsStr.Length == 2)
                {
                    nameFrequency.InitialYear = Convert.ToInt32(yearsStr[0].Replace("[", ""));
                    nameFrequency.FinalYear = Convert.ToInt32(yearsStr[1].Replace("[", ""));
                    nameFrequency.Frequency = frequency.Frequencia;
                }

                result.Add(nameFrequency);
            }

            return result;
        }
    }
}
