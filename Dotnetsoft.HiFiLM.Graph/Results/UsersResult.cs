using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetsoft.HiFiLM.Graph.Results
{
    public class UsersResult
    {
        public IGraphServiceUsersCollectionRequest NextPageRequest { get; set; }

        public IList<Models.User> Users { get; set; }
    }
}
