using IBGE.Helper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IBGE.Helper
{
    public class IbgeClient
    {
        private HttpClient _httpClient;
        public IbgeClient()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            _httpClient = new HttpClient(handler);
        }

        public async Task<IEnumerable<Municipio>> GetMunicipiosAsync()
        {
           
            var url = "https://servicodados.ibge.gov.br/api/v1/localidades/municipios"; ;

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Municipio>>(jsonResponse);
            }
        }
    }
}
