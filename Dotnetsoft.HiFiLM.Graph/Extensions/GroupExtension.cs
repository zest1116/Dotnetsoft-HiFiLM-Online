using Microsoft.Graph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetsoft.HiFiLM.Graph.Extensions
{
    public class GroupExtension : Extension
    {
        [JsonProperty("DeptId")]
        public string DeptId { get; set; }

        [JsonProperty("ParentDeptId")]
        public string ParentDeptId { get; set; }
    }
}
