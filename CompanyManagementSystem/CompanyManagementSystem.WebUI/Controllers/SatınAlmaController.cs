using CompanyManagementSystem.Business.Abstract;
using CompanyManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation;
using CompanyManagementSystem.Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CompanyManagementSystem.WebUI.Controllers
{
    [Authorize]
    public class SatınAlmaController : Controller
    {
        private ISatınAlmaService _satınAlmaService;
        private static int userId;

        public SatınAlmaController(ISatınAlmaService satınAlmaService)
        {
            _satınAlmaService = satınAlmaService;
        }
        public ActionResult Index()
        {
            GetUserId();
            return View();
        }
        [ValidateAntiForgeryToken]
        public ActionResult ÜrünKaydet(HttpPostedFileBase files,Faturalar faturalar,AlımTablosu alımTablosu)
        {
            SatınAlmaValidation profilValidation = new SatınAlmaValidation();
            ValidationResult result = profilValidation.Validate(alımTablosu);
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
                String FileExt = Path.GetExtension(files.FileName).ToUpper();

                if (FileExt == ".PDF")
                {
                    Stream str = files.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                    faturalar.Fatura = FileDet;
                    _satınAlmaService.FaturaEkle(faturalar);
                    alımTablosu.FaturaId = faturalar.FaturaId;
                    alımTablosu.UserId = userId;
                    _satınAlmaService.SatınAlma(alımTablosu);
                    TempData["Success"] = "İşlem başarıyla kaydedildi";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["Success"] = "Geçersiz Format.Lütfen pdf seçiniz.";
                    return RedirectToAction("Index");
                }
               
            }
           

        }

        public ActionResult SatınAlmaGecmis()
        {
            GetUserId();
           var alımlarım = _satınAlmaService.GetAlım(userId);
           return View(alımlarım);
        }

        [HttpGet]
        public ActionResult DownloadFatura(int faturaıd)
        {
            var fatura = _satınAlmaService.GetFatura(faturaıd);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return File(fatura.Fatura,"application/pdf");
        }


        private void GetUserId()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticketInfo = FormsAuthentication.Decrypt(cookie.Value);
            var userdetails = ticketInfo.UserData.Split('|');
            userId = Convert.ToInt32(userdetails[4]);
        }

    }

}