using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HiFiLM_Provisioning_Service.Controllers
{
    public class NotifyApiController : ApiController
    {
        public async Task Post()
        {
            // Create an event with 'event2' and additional data
            await this.NotifyAsync("event2", new { P1 = "p1" });
        }
    }
}
