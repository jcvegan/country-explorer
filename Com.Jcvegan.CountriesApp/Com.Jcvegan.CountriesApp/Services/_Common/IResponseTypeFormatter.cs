using System.Net.Http;
using System.Threading.Tasks;

namespace Com.Jcvegan.CountriesApp.Services._Common
{
    public interface IResponseTypeFormatter
    {
        Task<TResponseType> GetResponseAsync<TResponseType>(HttpResponseMessage message);
    }
}