using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace HiFiLM_Test_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfidentialClientApplication app;
            app = ConfidentialClientApplicationBuilder.Create("7d4d9e1e-5ce9-4bf8-97f0-bdf042668a12")
                                                      //.WithClientSecret(config.ClientSecret)
                                                      .WithAuthority(new Uri("https://login.microsoftonline.com/8fe7a70c-46a9-45e4-8ca5-59d10612167a"))
                                                      .Build();


        }
    }
}
