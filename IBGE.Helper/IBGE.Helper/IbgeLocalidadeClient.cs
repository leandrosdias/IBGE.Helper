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
    public class IbgeLocalidadeClient
    {
        private readonly HttpClient _httpClient;
        public IbgeLocalidadeClient()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            _httpClient = new HttpClient(handler);
        }

        #region Mesorregiões 

        public async Task<IEnumerable<Mesorregiao>> GetMesorregiaoAsync()
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

        public async Task<IEnumerable<Municipio>> GetMunicipiosByMesorregiaoAsync(List<int> mesoIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/mesorregioes/{string.Join("|", mesoIds)}/municipios";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Municipio>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Municipio>> GetMunicipiosByMicrorregiaoAsync(List<int> microIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/microrregioes/{string.Join("|", microIds)}/municipios";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Municipio>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Municipio>> GetMunicipiosByRegionAsync(List<int> macroIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/regioes/{string.Join("|", macroIds)}/municipios";

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

        #region Regiões

        public async Task<IEnumerable<Regiao>> GetRegioesAsync()
        {

            var url = "https://servicodados.ibge.gov.br/api/v1/localidades/regioes";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Regiao>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Regiao>> GetRegioesByIdAsync(List<int> ids)
        {

            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/regioes/{string.Join(" | ", ids)}";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (ids.Count > 1)
                    return JsonConvert.DeserializeObject<List<Regiao>>(jsonResponse);
                else
                    return new List<Regiao> { JsonConvert.DeserializeObject<Regiao>(jsonResponse) };
            }
        }

        #endregion

        #region UF

        public async Task<IEnumerable<Uf>> GetUfsAsync()
        {
            var url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Uf>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Uf>> GetUfsByIdAsync(List<int> ids)
        {

            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{string.Join(" | ", ids)}";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (ids.Count > 1)
                    return JsonConvert.DeserializeObject<List<Uf>>(jsonResponse);
                else
                    return new List<Uf> { JsonConvert.DeserializeObject<Uf>(jsonResponse) };
            }
        }

        public async Task<IEnumerable<Uf>> GetUfsByRegionAsync(List<int> regionIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/regioes/{string.Join(" | ", regionIds)}/estados";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Uf>>(jsonResponse);
            }
        }

        #endregion

        #region Distrito

        public async Task<IEnumerable<Distrito>> GetDistritosAsync()
        {
            var url = "https://servicodados.ibge.gov.br/api/v1/localidades/distritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Distrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Distrito>> GetDistritosByIdAsync(List<int> ids)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/distritos/{string.Join(" | ", ids)}";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Distrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Distrito>> GetDistritosByUfsAsync(List<int> ufIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{string.Join("|", ufIds)}/distritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Distrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Distrito>> GetDistritosByMesorregiaoAsync(List<int> mesoIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/mesorregioes/{string.Join("|", mesoIds)}/distritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Distrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Distrito>> GetDistritosByMicrorregiaoAsync(List<int> microIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/microrregioes/{string.Join("|", microIds)}/distritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Distrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Distrito>> GetDistritosByMunicipiosAsync(List<int> municipiosIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/municipios/{string.Join("|", municipiosIds)}/distritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Distrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<Distrito>> GetDistritosByRegioesAsync(List<int> regioesIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/regioes/{string.Join("|", regioesIds)}/distritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Distrito>>(jsonResponse);
            }
        }

        #endregion

        #region SubDistritos

        public async Task<IEnumerable<SubDistrito>> GetSubDistritosAsync()
        {
            var url = "https://servicodados.ibge.gov.br/api/v1/localidades/subdistritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SubDistrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<SubDistrito>> GetSubDistritosByIdAsync(List<ulong> ids)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/subdistritos/{string.Join(" | ", ids)}";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SubDistrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<SubDistrito>> GetSubDistritosByUfsAsync(List<int> ufIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{string.Join("|", ufIds)}/subdistritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SubDistrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<SubDistrito>> GetSubDistritosByMesorregiaoAsync(List<int> mesoIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/mesorregioes/{string.Join("|", mesoIds)}/subdistritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SubDistrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<SubDistrito>> GetSubDistritosByMicrorregiaoAsync(List<int> microIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/microrregioes/{string.Join("|", microIds)}/subdistritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SubDistrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<SubDistrito>> GetSubDistritosByMunicipiosAsync(List<int> municipiosIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/municipios/{string.Join("|", municipiosIds)}/subdistritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SubDistrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<SubDistrito>> GetSubDistritosByRegioesAsync(List<int> regioesIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/regioes/{string.Join("|", regioesIds)}/subdistritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SubDistrito>>(jsonResponse);
            }
        }

        public async Task<IEnumerable<SubDistrito>> GetSubDistritosByDistritosAsync(List<int> distritoIds)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/distritos/{string.Join("|", distritoIds)}/subdistritos";

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SubDistrito>>(jsonResponse);
            }
        }
        #endregion
    }
}
