using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dotnetsoft.HiFiLM.Graph.Services
{
    public class CommonService : BaseService
    {
        public CommonService(GraphServiceClient client) : base(client)
        {
        }

        public async Task<List<Models.Domain>> GetDomainsAsync()
        {
            try
            {
                IGraphServiceDomainsCollectionPage domains = await graphClient.Domains.Request().GetAsync();
                List<Models.Domain> values = new List<Models.Domain>();
                foreach (Domain domain in domains.CurrentPage)
                {
                    Models.Domain value = new Models.Domain()
                    {
                        Id = domain.Id,
                        IsDefault = domain.IsDefault.HasValue ? domain.IsDefault.Value : false
                    };
                    values.Add(value);
                }
                return values;
            }
            catch
            {
                throw;
            }
        }
    }
}
