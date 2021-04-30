using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Valorant.NET.Models.Exceptions;

namespace Valorant.NET.Handlers
{
    public class RiotApiResponseHandler : IRiotApiResponseHandler
    {
        public async Task Execute(HttpResponseMessage apiResponse)
        {
            if (!apiResponse.IsSuccessStatusCode) 
                throw new RiotApiException(apiResponse.StatusCode, await apiResponse.Content.ReadAsStringAsync());
        }
    }
}
