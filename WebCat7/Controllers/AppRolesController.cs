using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCat7.Data;
using WebCat7.Models;
using WebCat7.Models.ViewModel;

namespace WebCat7.Controllers
{
    public class AppRolesController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly AppDbContext _context;

        public AppRolesController(RoleManager<AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        // GET: AppRoles
        public async Task<IActionResult> Index()
        {
            List<AppRoleListViewModel> model = new List<AppRoleListViewModel>();
            model = roleManager.Roles.Select(r => new AppRoleListViewModel
            {
                RoleName = r.Name,
                Id = r.Id.ToString(),
                Description = r.Description,
                
                //NumberOfUsers = r..Count
            }).ToList();
            return View(model);

            //return View(await _context.AppRole.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> AddEditAppRole(Guid id)
        {
            AppRoleViewModel model = new AppRoleViewModel();
                AppRole appRole = await roleManager.FindByIdAsync(id.ToString() );
                if (appRole != null)
                {
                    model.Id = appRole.Id.ToString();
                    model.RoleName = appRole.Name;
                    model.Description = appRole.Description;
                }
            return PartialView("_AddEditAppRole", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditAppRole(Guid id, AppRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isExist = !String.IsNullOrEmpty(id.ToString());
                AppRole appRole = isExist ? await roleManager.FindByIdAsync(id.ToString()) :
               new AppRole
               {
                   CreatedDate = DateTime.UtcNow
               };
                appRole.Name = model.RoleName;
                appRole.Description = model.Description;
                appRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IdentityResult roleRuslt = isExist ? await roleManager.UpdateAsync(appRole)
                                                    : await roleManager.CreateAsync(appRole);
                if (roleRuslt.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        #region MyRegion

        // GET: AppRoles/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appRole = await _context.AppRole
                .SingleOrDefaultAsync(m => m.Id == id);
            if (appRole == null)
            {
                return NotFound();
            }

            return View(appRole);
        }

        // GET: AppRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Users,Description,CreatedDate,IPAddress,Id,Name,NormalizedName,ConcurrencyStamp")] AppRole appRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appRole);
        }

        #endregion

    }
}
