using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Monitor.Helpers
{
    public class Requesters
    {
        public static async Task<HttpStatusCode> GetStatusFromUrl(string url)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                return httpResponseMessage.StatusCode;
            }
            catch(HttpRequestException)
            {
                return HttpStatusCode.NotFound;
            }
        }
    }
}