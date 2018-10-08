using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebCat7.Models;
using WebCat7.Models.ViewModel;

namespace WebCat7.Controllers
{
    public class ApplicationRoleController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;

        public ApplicationRoleController(RoleManager<AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<AppRoleListViewModel> model = new List<AppRoleListViewModel>();
            model = roleManager.Roles.Select(r => new AppRoleListViewModel
            {
                RoleName = r.Name,
                Id = r.Id,
                Description = r.Description,
                //NumberOfUsers = r.Users.Count
            }).ToList();
            return View(model);
        }
    }
}