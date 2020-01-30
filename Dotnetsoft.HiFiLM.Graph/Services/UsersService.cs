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

        public async Task<IList<Dto.User>> GetUsers()
        {
            try
            {
                IGraphServiceUsersCollectionPage users = await graphClient.Users.Request(requestOptions).Select("displayName,userPrincipalName,userType,assignedLicenses").GetAsync();
                List<Dto.User> values = new List<Dto.User>();
                foreach(User user in users.CurrentPage)
                {
                    Dto.User value = new Dto.User()
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
    }
}
