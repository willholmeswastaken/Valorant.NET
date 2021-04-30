using System.Net.Http;
using System.Threading.Tasks;

namespace Valorant.NET.Handlers
{
    /// <summary>
    /// This is responsible for parsing the potential status codes and handling behaviour
    /// </summary>
    public interface IRiotApiResponseHandler
    {
        /// <summary>
        /// Ensures the response was valid to progress.
        /// </summary>
        /// <param name="apiResponse">Response from the api call.</param>
        Task Execute(HttpResponseMessage apiResponse);
    }
}
