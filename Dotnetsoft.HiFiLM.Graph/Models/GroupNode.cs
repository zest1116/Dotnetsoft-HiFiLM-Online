using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetsoft.HiFiLM.Graph.Models
{
    public class GroupNode
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags {get;set;}
    }
}
