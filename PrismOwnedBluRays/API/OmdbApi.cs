using Newtonsoft.Json;
using PrismOwnedBluRays.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PrismOwnedBluRays.API
{
    public class OmdbApi
    {
        public static async Task<BluRay> GetBluRayTitle(string searchTerm)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            var responseMessage = await httpClient.GetAsync(string.Format("https://www.omdbapi.com/?t={0}&apikey=f40cfcaa", searchTerm));

            if (!responseMessage.IsSuccessStatusCode) return null;

            var jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            var blurays = JsonConvert.DeserializeObject<BluRay>(jsonResult);

            return blurays;
        }
    }
}