using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchMod.Models.General;

namespace WebCat7.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();

            var rolelist = context.Roles.OrderBy(r => r.RoleName).ToList().Select(rr =>
            new SelectListItem { Value = rr.RoleName.ToString(), Text = rr.RoleName }).ToList();
            ViewBag.Roles = rolelist;

            var userlist = context.Employees.OrderBy(u => u.FullName).ToList().Select(uu =>
            new SelectListItem { Value = uu.FullName.ToString(), Text = uu.FullName }).ToList();
            ViewBag.Users = userlist;

            ViewBag.Message = "";

            return View();

        }

        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }


        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(Role role)
        {

            try
            {
                var context = new AppDbContext();
                context.Roles.Add(role);
                context.SaveChanges();
                ViewBag.Message = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(string RoleName)
        {
            var context = new ApplicationDbContext();
            var thisRole = context.Roles.Where(r => r.RoleName.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        //
        // GET: /Roles/Edit/5
        public ActionResult Edit(string roleName)
        {
            var context = new ApplicationDbContext();
            var thisRole = context.Roles.Where(r => r.RoleName.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }


        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            try
            {
                var context = new ApplicationDbContext();
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //  Adding Roles to a user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            var context = new ApplicationDbContext();

            if (context == null)
            {
                throw new ArgumentNullException("context", "Context must not be null.");
            }

            Employee user = context.Employees.Where(u => u.FullName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            Role role = context.Roles.Where(u => u.RoleName.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            AssignUserRole assignUserRole = new AssignUserRole
            {
                EmployeeId = user.EmployeeID,
                RoleId = role.RoleID
            };

            var EmpRoleToAdd = (from emprole in context.AssignUserRoles

                                where emprole.EmployeeId == user.EmployeeID && emprole.RoleId == role.RoleID

                                select emprole).FirstOrDefault();
            if (EmpRoleToAdd == null)
            {
                context.AssignUserRoles.Add(assignUserRole);
                context.SaveChanges();
                ViewBag.Message = "Role created successfully !";
            }
            else
            {
                ViewBag.Message = " This Role already exists for this user !";
            }

            // Repopulate Dropdown Lists
            var rolelist = context.Roles.OrderBy(r => r.RoleName).ToList().Select(rr => new SelectListItem { Value = rr.RoleName.ToString(), Text = rr.RoleName }).ToList();
            ViewBag.Roles = rolelist;
            var userlist = context.Employees.OrderBy(u => u.FullName).ToList().Select(uu =>
            new SelectListItem { Value = uu.FullName.ToString(), Text = uu.FullName }).ToList();
            ViewBag.Users = userlist;

            return View("Index");
        }


        //Getting a List of Roles for a User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                var context = new ApplicationDbContext();
                Employee user = context.Employees.Where(u => u.FullName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var roles = user.AssignUserRoles.Select(u => u.Role).Select(u => u.RoleName).ToArray();

                ViewBag.RolesForThisUser = roles;


                // Repopulate Dropdown Lists
                var rolelist = context.Roles.OrderBy(r => r.RoleName).ToList().Select(rr => new SelectListItem { Value = rr.RoleName.ToString(), Text = rr.RoleName }).ToList();
                ViewBag.Roles = rolelist;
                var userlist = context.Employees.OrderBy(u => u.FullName).ToList().Select(uu =>
                new SelectListItem { Value = uu.FullName.ToString(), Text = uu.FullName }).ToList();
                ViewBag.Users = userlist;
                ViewBag.Message = "Roles retrieved successfully !";
            }

            return View("Index");
        }


        //Deleting a User from A Role
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            var context = new ApplicationDbContext();
            Employee user = context.Employees.Where(u => u.FullName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            Role role = context.Roles.Where(u => u.RoleName.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var EmpRoleToDelete = (from emprole in context.AssignUserRoles

                                   where emprole.EmployeeId == user.EmployeeID && emprole.RoleId == role.RoleID

                                   select emprole).FirstOrDefault();

            if (EmpRoleToDelete != null)
            {
                context.AssignUserRoles.Remove(EmpRoleToDelete);
                context.SaveChanges();
                ViewBag.Message = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.Message = "This user doesn't belong to selected role.";
            }

            // Repopulate Dropdown Lists
            var rolelist = context.Roles.OrderBy(r => r.RoleName).ToList().Select(rr => new SelectListItem { Value = rr.RoleName.ToString(), Text = rr.RoleName }).ToList();
            ViewBag.Roles = rolelist;
            var userlist = context.Employees.OrderBy(u => u.FullName).ToList().Select(uu =>
            new SelectListItem { Value = uu.FullName.ToString(), Text = uu.FullName }).ToList();
            ViewBag.Users = userlist;

            return View("Index");
        }


    }
}