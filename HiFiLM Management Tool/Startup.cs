using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Dotnetsoft.HiFiLM.Management.Tool.Startup))]

namespace Dotnetsoft.HiFiLM.Management.Tool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
