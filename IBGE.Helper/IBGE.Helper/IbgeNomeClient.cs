using IBGE.Helper.Models.Nomes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IBGE.Helper
{

    public class IbgeNomeClient
    {
        private readonly HttpClient _httpClient;
        public IbgeNomeClient()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            _httpClient = new HttpClient(handler);
        }

        public async Task<IEnumerable<Nomes>> GetNamesAsync(List<string> names)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v2/censos/nomes/" + string.Join("|", names);

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Nomes>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Nomes>> GetNamesByRankingAsync()
        {
            var url = $"https://servicodados.ibge.gov.br/api/v2/censos/nomes/ranking";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Nomes>>(jsonResponse);
            }
        }
    }
}
