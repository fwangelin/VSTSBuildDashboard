using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VSTSBuildDashboard.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> DeserializeJsonGetRequest<T>(this HttpClient httpClient, Uri uri) =>
            JsonConvert.DeserializeObject<T>(await httpClient.GetStringAsync(uri));
    }
}