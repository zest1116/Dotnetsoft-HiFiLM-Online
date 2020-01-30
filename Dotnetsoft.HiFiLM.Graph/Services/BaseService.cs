using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetsoft.HiFiLM.Graph.Services
{
    public class BaseService : IDisposable
    {
        protected GraphServiceClient graphClient;
        protected IList<Option> requestOptions;
        public BaseService(GraphServiceClient client)
        {
            graphClient = client;
            requestOptions = new List<Option>
            {
                new HeaderOption("Prefer", "outlook.timezone=\"" + TimeZoneInfo.Local.Id + "\"")
            };
        }

        public void Dispose()
        {
            if (graphClient != null) { graphClient = null; }
            if (requestOptions != null) { requestOptions = null; }
        }
    }
}
