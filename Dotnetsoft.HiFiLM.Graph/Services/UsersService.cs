using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dotnetsoft.HiFiLM.Graph.Services
{
    public class UsersService : BaseService
    {

        public UsersService(GraphServiceClient client) : base(client)
        {
        }

        public async Task<IList<Models.User>> GetUsersAsync()
        {
            try
            {
                IGraphServiceUsersCollectionPage users = await graphClient.Users.Request(requestOptions).Top(20)
                    .Select(e => new { e.DisplayName, e.UserPrincipalName, e.UserType, e.AssignedLicenses})
                    .GetAsync();
                List<Models.User> values = new List<Models.User>();
                foreach(User user in users.CurrentPage)
                {
                    Models.User value = new Models.User()
                    {
                        ObjectId = user.Id,
                        UserName = user.DisplayName,
                        UserPrincipalName = user.UserPrincipalName,
                        UserType = user.UserType
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

        public async Task<Results.UsersResult> SearchUsersAsync(string keyword)
        {
            return await SearchUsersAsync(null, keyword);
        }

        public async Task<Results.UsersResult> SearchUsersAsync(IGraphServiceUsersCollectionRequest request, string keyword)
        {
            try
            {
                Results.UsersResult usersResult = new Results.UsersResult();
                string query = string.Format("startswith(displayName,'{0}') or startswith(userPrincipalName,'{0}')", keyword);
                IGraphServiceUsersCollectionPage users;
                if (request == null)
                    users = await graphClient.Users.Request(requestOptions).Top(4)
                        .Filter(query)
                        .Select(e => new { e.DisplayName, e.UserPrincipalName, e.UserType, e.AssignedLicenses })
                        .GetAsync();
                else
                    users = await request.GetAsync();

                usersResult.NextPageRequest = users.NextPageRequest;

                List<Models.User> values = new List<Models.User>();
                foreach (User user in users.CurrentPage)
                {
                    Models.User value = new Models.User()
                    {
                        ObjectId = user.Id,
                        UserName = user.DisplayName,
                        UserPrincipalName = user.UserPrincipalName,
                        UserType = user.UserType
                    };
                    values.Add(value);
                }

                usersResult.Users = values;

                return usersResult;
            }
            catch
            {
                throw;
            }
        }
    }
}
