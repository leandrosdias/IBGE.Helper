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

        public async Task<IEnumerable<Mesorregiao>> GetMesoregionAsync()
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

        public async Task<IEnumerable<Mesorregiao>> GetMesorregiaoByUfAsync(List<int> ufIds)
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

        public async Task<IEnumerable<Mesorregiao>> GetMesorregiaoByIdAsync(List<int> ids)
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

        public async Task<IEnumerable<Mesorregiao>> GetMesorregiaoByMacrorregiaoAsync(List<int> macroIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/regioes/{string.Join("|", macroIds)}/mesorregioes";

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

        #region Microrregiões

        public async Task<IEnumerable<Microrregiao>> GetMicrorregiaoAsync()
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/microrregioes";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Microrregiao>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Microrregiao>> GetMicrorregiaoByUfAsync(List<int> ufIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{string.Join("|", ufIds)}/microrregioes";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Microrregiao>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Microrregiao>> GetMicrorregiaoByMesorregiaoAsync(List<int> mesoIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/mesorregioes/{string.Join("|", mesoIds)}/microrregioes";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Microrregiao>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Microrregiao>> GetMicroregiaoByIdAsync(List<int> ids)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/microrregioes/{string.Join("|", ids)}";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (ids.Count > 1)
                    return JsonConvert.DeserializeObject<List<Microrregiao>>(jsonResponse);
                else
                    return new List<Microrregiao> { JsonConvert.DeserializeObject<Microrregiao>(jsonResponse) };
            }
        }

        public async Task<IEnumerable<Microrregiao>> GetMicroregiaoByMacrorregiaoAsync(List<int> macrosId)
        {

            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/regioes/{string.Join("|", macrosId)}/microrregioes";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Microrregiao>>(jsonResponse);
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

        public async Task<IEnumerable<Municipio>> GetMunicipiosByIdAsync(List<int> ids)
        {

            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/municipios/{string.Join(" | ", ids)}";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (ids.Count > 1)
                    return JsonConvert.DeserializeObject<List<Municipio>>(jsonResponse);
                else
                    return new List<Municipio> { JsonConvert.DeserializeObject<Municipio>(jsonResponse) };
            }
        }

        public async Task<IEnumerable<Municipio>> GetMunicipiosByUfAsync(List<int> ufList)
        {

            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{string.Join("|", ufList)}/municipios";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Municipio>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Municipio>> GetMunicipiosByMesorregiaoAsync(List<int> mesoIdList)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/mesorregioes/{string.Join("|", mesoIdList)}/municipios";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Municipio>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Municipio>> GetMunicipiosByMicrorregiaoAsync(List<int> microIdList)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/microrregioes/{string.Join("|", microIdList)}/municipios";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Municipio>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Municipio>> GetMunicipiosByRegionAsync(List<int> macroIdList)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/regioes/{string.Join("|", macroIdList)}/municipios";

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
