using System.Threading.Tasks;

namespace bedste_boligoverblik.core.Helpers
{
    public interface IHttpClientHelper
    {
        Task<string> GetAsync(string requestUrl);
        Task<T> GetAsync<T>(string requestUrl) where T : new();
        Task<string> PostAsync<T>(string url, T body);
        Task<TOut> PostAsync<TIn, TOut>(string requestUrl, TIn body) where TOut : new();
    }
}