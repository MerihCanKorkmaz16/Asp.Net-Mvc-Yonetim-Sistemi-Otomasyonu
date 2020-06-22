using CompanyManagementSystem.Business.Abstract;
using CompanyManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation;
using CompanyManagementSystem.Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CompanyManagementSystem.WebUI.Controllers
{
    [Authorize]

    public class ProfilController : Controller
    {
        private static int userId;
        private static string mevcutpassword;
        private IUserService _userService;
        public ProfilController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            GetUserId();
            var profildetail = _userService.GetUserId(userId);
            mevcutpassword = profildetail.Password;
            return View(profildetail);
        }

        //Profil güncelleme işlemleri
        public ActionResult ProfilGüncelle(User user)
        {
            ProfilBilgileriValidation profilValidation = new ProfilBilgileriValidation();
            ValidationResult result = profilValidation.Validate(user);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View("Index");
            }
            else
            {
                _userService.UpdateUser(user);
                TempData["SuccessAlert"] = "Profil bilgileriniz başarıyla güncellendi";
                return RedirectToAction("Index");
            }
        }

        //Profil Şifre işlemleri
        public ActionResult ProfilSifreGüncelle(string inputpassword,string Password,string ConfirmPassword,User user)
        {
            if (inputpassword != mevcutpassword)
            {
                ModelState.AddModelError("PassError", "Mevcut Şifreniz yanlış");
                return View("Index");
            }
            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmError", "Şifreler birbiri ile uyuşmuyor");
                return View("Index");
            }
            SifreValidation sifreValidation = new SifreValidation();
            ValidationResult result = sifreValidation.Validate(user);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View("Index");
            }
            user.Password = Password;
            _userService.UpdateUser(user);
            TempData["SuccessAlert2"] = "Şifreniz başarıyla güncellendi";
            return RedirectToAction("Index");

        }

        //Kullanıcı ıd alma metodu
        private void GetUserId()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticketInfo = FormsAuthentication.Decrypt(cookie.Value);
            var userdetails = ticketInfo.UserData.Split('|');
            userId = Convert.ToInt32(userdetails[4]);
        }
    }
}