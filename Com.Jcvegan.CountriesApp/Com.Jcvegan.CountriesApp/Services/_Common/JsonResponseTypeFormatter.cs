using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Com.Jcvegan.CountriesApp.Services._Common
{
    public class JsonResponseTypeFormatter : IResponseTypeFormatter
    {
        public async Task<TResponseType> GetResponseAsync<TResponseType>(HttpResponseMessage message)
        {
            var content = message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponseType>(await content);
        }
    }
}