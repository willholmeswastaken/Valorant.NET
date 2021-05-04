using System;
using System.Threading.Tasks;

namespace Valorant.NET.Clients
{
    public interface IRiotHttpClient : IDisposable
    {
        Task<T> GetAsync<T>(Uri uri) where T : class;
    }
}
