using CompanyManagementSystem.Business.Abstract;
using CompanyManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CompanyManagementSystem.WebUI.Controllers
{
    [Authorize(Roles ="Management")]
    public class DuyurularController : Controller
    {
        private IDuyuruService _duyuruService;
        private static int userId;
        public DuyurularController(IDuyuruService duyuruService)
        {
            _duyuruService = duyuruService;       
        }
        public ActionResult Index()
        {
            GetUserId();
            return View(_duyuruService.AllGetDuyuru());
        }


        [ValidateAntiForgeryToken]
        public ActionResult DuyuruEkle(Duyuru duyuru)
        {
            duyuru.UserId = userId;
            duyuru.Durum = true;
            _duyuruService.AddDuyuru(duyuru);
            TempData["Success"] = "Duyuru başarıyla eklendi";
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int duyuruId)
        {
            var deletedDuyuru = _duyuruService.GetDuyuru(duyuruId);
            if (deletedDuyuru != null)
            {
                _duyuruService.DeleteDuyuru(deletedDuyuru);
                System.Threading.Thread.Sleep(500);
            }
            return RedirectToAction("Index");
        }
        public ActionResult AktifYap(int duyuruId)
        {
            var aktifDuyuru = _duyuruService.GetDuyuru(duyuruId);
            if (aktifDuyuru != null)
            {
                aktifDuyuru.Durum = true;
                _duyuruService.UpdateDuyuru(aktifDuyuru);
                TempData["Success"] = "Duyuru başarıyla aktif edildi";
            }
            return RedirectToAction("Index");
        }
        public ActionResult PasifYap(int duyuruId)
        {
            var pasifDuyuru = _duyuruService.GetDuyuru(duyuruId);
            if (pasifDuyuru != null)
            {
                pasifDuyuru.Durum = false;
                _duyuruService.UpdateDuyuru(pasifDuyuru);
                TempData["Success"] = "Duyuru başarıyla pasif edildi";
            }
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