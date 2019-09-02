using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Com.Jcvegan.CountriesApp.Models;
using Com.Jcvegan.CountriesApp.Services._Common;

namespace Com.Jcvegan.CountriesApp.Services
{
    public class CountryService : ICountryService
    {
        private readonly IResponseTypeFormatter _responseFormatter;
        private readonly HttpClient _httpClient;
        public CountryService(IResponseTypeFormatter responseFormatter)
        {
            _responseFormatter = responseFormatter;
            _httpClient = new HttpClient();
        }
        public async Task<IEnumerable<CountryModel>> GetCountriesAsync(string name = null)
        {
            var url = string.Empty;
            if (string.IsNullOrEmpty(name))
                url = "https://restcountries.eu/rest/v2/all?fields=name;population;region;flag;alpha3Code";
            else
                url = $"https://restcountries.eu/rest/v2/name/{name}?fields=name;population;region;flag;alpha3Code";
            try
            {
                var httpResponse = _httpClient.GetAsync(url).GetAwaiter().GetResult();
                var response = httpResponse.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                    return null;
                return await _responseFormatter.GetResponseAsync<IEnumerable<CountryModel>>(response);
            }
            catch (Exception exc)
            {
                return null;
            }
            
        }

        public async Task<CountryFullModel> GetCountryInfoAsync(string alpha3Code = null)
        {
            if (string.IsNullOrEmpty(alpha3Code))
                return null;
            try
            {
                var url = $"https://restcountries.eu/rest/v2/alpha/{alpha3Code}";
                var httpResponse = _httpClient.GetAsync(url).GetAwaiter().GetResult();
                var response = httpResponse.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                    return null;
                return await _responseFormatter.GetResponseAsync<CountryFullModel>(response);
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}