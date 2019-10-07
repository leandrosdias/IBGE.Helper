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
        private readonly HttpClient _httpClient;
        public IbgeClient()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            _httpClient = new HttpClient(handler);
        }

        #region Mesorregiões 

        public async Task<IEnumerable<Mesorregiao>> GetMesoregiaoAsync()
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/mesorregioes";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Mesorregiao>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Mesorregiao>> GetMesoregiaoByUfAsync(List<int> ufIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{string.Join("|", ufIds)}/microrregioes";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Mesorregiao>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Mesorregiao>> GetMesoregiaoByIdAsync(List<int> ids)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/mesorregioes/{string.Join("|", ids)}";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (ids.Count > 1)
                    return JsonConvert.DeserializeObject<List<Mesorregiao>>(jsonResponse);
                else
                    return new List<Mesorregiao> { JsonConvert.DeserializeObject<Mesorregiao>(jsonResponse) };
            }
        }

        public async Task<IEnumerable<Mesorregiao>> GetMesoregiaoByMacroregiao(List<int> ids)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/regioes/{string.Join("|", ids)}/mesorregioes";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Mesorregiao>>(jsonResponse);
            }
        }
        
        #endregion

        #region Municipio

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
        
        #endregion

    }
}
