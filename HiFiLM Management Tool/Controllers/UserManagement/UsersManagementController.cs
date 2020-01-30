using Dotnetsoft.HiFiLM.Graph.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Dotnetsoft.HiFiLM.Management.Tool.Controllers.UserManagement
{
    public class UsersManagementController : BaseController
    {
        // GET: UsersManagement
        public async Task<ActionResult> AllUsers()
        {
            using (UsersService service = new UsersService(Helpers.GraphHelper.GetAuthenticatedClient()))
            {
                var users = await service.GetUsers();
                return View(users);
            }
        }
    }
}