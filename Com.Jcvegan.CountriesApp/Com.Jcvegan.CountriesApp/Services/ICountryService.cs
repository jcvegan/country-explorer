using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Jcvegan.CountriesApp.Models;

namespace Com.Jcvegan.CountriesApp.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryModel>> GetCountriesAsync(string name = null);

        Task<CountryFullModel> GetCountryInfoAsync(string alpha3Code = null);
    }
}