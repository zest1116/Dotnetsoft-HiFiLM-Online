using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.SelfHost;
using System.Web.Http.Routing;
using System.Web.Http;

namespace HiFiLM_Provisioning_Service
{
    public partial class HiFiLMService : ServiceBase
    {
        public HiFiLMService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartWebApiHost().GetAwaiter().GetResult();
        }

        private async Task StartWebApiHost()
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");
            
            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.InitializeCustomWebHooks();
            config.InitializeCustomWebHooksApis();

            HttpSelfHostServer httpSelfHostServer = new HttpSelfHostServer(config);
            await httpSelfHostServer.OpenAsync();
        }

        protected override void OnStop()
        {
        }
    }
}
