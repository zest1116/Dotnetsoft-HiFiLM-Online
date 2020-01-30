using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetsoft.HiFiLM.Graph.Dto
{
    public class User
    {
        public string ObjectId { get; set; }

        public string UserName { get; set; }

        public string UserPrincipalName { get; set; }

        public string UserType { get; set; }

        public string AssignedLicenses { get; set; }
    }
}
