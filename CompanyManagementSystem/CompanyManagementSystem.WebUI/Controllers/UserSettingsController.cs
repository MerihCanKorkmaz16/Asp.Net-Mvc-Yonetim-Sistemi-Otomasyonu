using CompanyManagementSystem.Business.Abstract;
using CompanyManagementSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagementSystem.WebUI.Controllers
{
    [Authorize(Roles = "Management")]

    public class UserSettingsController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;
        public UserSettingsController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        UserSettingsModel userModel = new UserSettingsModel();
        List<SelectListItem> userRol = new List<SelectListItem>();

        public ActionResult Index()
        {
            userModel.Details = _userService.GetAllUserDetails();
            ViewBag.UserCount = userModel.Details.Count();
            DropdownrolDoldurma();
            return View(userModel);
        }


        //Kullanıcı ekleme
        public ActionResult KullanıcıEkle(UserSettingsModel model)
        {
            if (_userService.AddUserTransaction(model.User.Username))
            {
                TempData["Error"] = "Kullanıcı adına ait kayıtlı hesap bulunmaktadır!";
                return RedirectToAction("Index");
            }
            model.User.RoleId = Convert.ToInt32(model.RoleId);
            _userService.AddUser(model.User);
            TempData["Success"] = "Kullanıcı başarıyla eklendi";
            return RedirectToAction("Index");
        }
        //Kullanıcı silme
        public ActionResult KullanıcıSilme(int userId)
        {
            var deletedUser = _userService.GetUserId(userId);
            _userService.DeleteUser(deletedUser);
            System.Threading.Thread.Sleep(500);
            return RedirectToAction("Index");
        }
        //Kullanıcı güncelleme partial
        public ActionResult KullanıcıGüncelle(int id)
        {
            DropdownrolDoldurma();
            userModel.User = _userService.GetUserId(id);
            userModel.RoleId = userModel.User.RoleId.ToString();
            return PartialView(userModel);
        }
        public ActionResult KullanıcıGüncellePost(UserSettingsModel updatedModel)
        {
            _userService.UpdateUser(updatedModel.User);
            TempData["Success"] = "Kullanıcı başarıyla güncellendi";
            return RedirectToAction("Index");
        }
        //dropdown set role method
        private void DropdownrolDoldurma()
        {
            userModel.Roles = _roleService.GetAllRole();
            foreach (var item in userModel.Roles)
            {
                userRol.Add(new SelectListItem { Text = item.RoleName, Value = item.RoleId.ToString() });
            }
            
        }
    }
}