using CompanyManagementSystem.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CompanyManagementSystem.WebUI.Controllers
{
    [Authorize]
    public class AnaSayfaController : Controller
    {
        private IDuyuruService _duyuruService;
        public AnaSayfaController(IDuyuruService duyuruService)
        {
            _duyuruService = duyuruService;
        }
        public ActionResult Index()
        {
            var duyuru = _duyuruService.AllGetDuyuru();
            return View(duyuru);
        }
    }
}