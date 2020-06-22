using CompanyManagementSystem.Business.Abstract;
using CompanyManagementSystem.Business.CrossCuttingConcerns.Security.Web;
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
    [AllowAnonymous]
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(string username,string password,User user)
        {
            LoginValidation loginValidation = new LoginValidation();
            ValidationResult result = loginValidation.Validate(user);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(user);
            }
            else
            {
                var loginuser = _userService.CheckUser(username, password);
                if (loginuser != null)
                {
                    AuthenticationHelper.CreateAuthCookie(loginuser.UserId,loginuser.Username,loginuser.Email,DateTime.Now.AddDays(15),_userService.GetUserRole(username).Select(x=>x.RoleName).ToArray(),false,loginuser.FirstName,loginuser.LastName);
                    return RedirectToAction("Index", "AnaSayfa");
                }
                ViewBag.LoginError = "Kullanıcı adı veya şifre yanlış!";
                return View();

            }
           
        }
    }
}