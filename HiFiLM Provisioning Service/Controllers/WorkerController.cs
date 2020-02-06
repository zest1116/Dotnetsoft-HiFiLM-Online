using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HiFiLM_Provisioning_Service.Controllers
{
    public class WorkerController : ApiController
    {
        public string Start()
        {
            Task.Run(() => WriteLog());

            return "Job started!";
        }

        private void WriteLog()
        {
            System.Threading.Thread.Sleep(10000);
            if (!EventLog.SourceExists("HiFiLM"))
            {
                EventLog.CreateEventSource("HiFiLM", "CallApi");
            }

            EventLog eventLog = new EventLog();
            eventLog.Source = "HiFiLM";
            eventLog.WriteEntry("Job started!", EventLogEntryType.Information);

        }

    }
}
