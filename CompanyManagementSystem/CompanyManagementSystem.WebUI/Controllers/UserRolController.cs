using CompanyManagementSystem.Business.Abstract;
using CompanyManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagementSystem.WebUI.Controllers
{
    [Authorize(Roles = "Management")]
    public class UserRolController : Controller
    {
        private IRoleService _roleService;
        public UserRolController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public ActionResult Index()
        {
            var Allrole = _roleService.GetAllRole();
            ViewBag.RoleCount = Allrole.Count();
            return View(Allrole);
        }
        [HttpPost]
        public ActionResult Index(UserRole userRole)
        {
            _roleService.AddRole(userRole);
            TempData["Success"] = "Kullanıcı yetkisi başarıyla eklendi";
            return RedirectToAction("Index");
        }

        //Role Silme
        public ActionResult RolSilme(int rolıd)
        {
            var deletedRole = _roleService.GetRole(rolıd);
            if (deletedRole != null)
            {
                _roleService.DeleteRol(deletedRole);
                TempData["Success"] = "Kullanıcı yetkisi başarıyla silindi";
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}