using Dotnetsoft.HiFiLM.Graph.Models;
using Dotnetsoft.HiFiLM.Graph.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Dotnetsoft.HiFiLM.Management.Tool.Controllers
{
    public class UsersManagementController : BaseController
    {
        public async Task<ActionResult> AllUsers()
        {
            using (UsersService service = new UsersService(Helpers.GraphHelper.GetAuthenticatedClient()))
            {
                var users = await service.GetUsersAsync().ConfigureAwait(false);
                return View(users);
            }
        }

        [HttpGet]
        public async Task<ActionResult> EntryUser()
        {

            return View();
            //if (Request.IsAjaxRequest())
            //{
            //    using (CommonService service = new CommonService(Helpers.GraphHelper.GetAuthenticatedClient()))
            //    {
            //        var domains = await service.GetDomainsAsync().ConfigureAwait(false);
            //        ViewData["Domains"] = domains;
            //        return PartialView("_PartialUserEntry", new User());
            //    }
            //}
            //return PartialView("_PartialUserEntry", new User());
        }

        public async Task<EmptyResult> CreateExtensions()
        {
            using (AdminService service = new AdminService(Helpers.GraphHelper.GetAuthenticatedClient()))
            {
                await service.UpdateGroupExtensions();
            }

            return new EmptyResult();
        }

        public async Task<JsonResult> SearchUsers(string keyword)
        {
            using (UsersService service = new UsersService(Helpers.GraphHelper.GetAuthenticatedClient()))
            {
                Graph.Results.UsersResult usersResult;
                if (TempData["GraphRequest"] == null)
                    usersResult = await service.SearchUsersAsync(keyword);
                else
                    usersResult = await service.SearchUsersAsync((Microsoft.Graph.IGraphServiceUsersCollectionRequest)TempData["GraphRequest"], keyword);

                TempData["GraphRequest"] = usersResult.NextPageRequest;

                return Json(usersResult.Users, JsonRequestBehavior.AllowGet);
            }
        }
    }
}