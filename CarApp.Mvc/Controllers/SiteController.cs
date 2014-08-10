using CarApp.Domain;
using CarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarApp.Mvc.Controllers
{
    public class SiteController : Controller
    {
        private readonly Func<IEntityAccess<Site>> _siteAccess;

        public SiteController(Func<IEntityAccess<Site>> siteAccess)
        {
            _siteAccess = siteAccess;
        }

        public ActionResult Index()
        {
            var sites = _siteAccess().List();
            return View(sites);
        }

        public ActionResult Details(Guid id)
        {
            var sites = _siteAccess().Get(id);
            return View(sites);
        }

        public ActionResult Create()
        {
            Site sites = new Site();

            return View(sites);
        }

        [HttpPost]
        public ActionResult Create(Site model)
        {
            if (!ModelState.IsValid || model.ZipCode == null)
                return View(model);

            _siteAccess().Save(model);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var site = _siteAccess().Get(id);
            return View(site);
        }

        [HttpPost]
        public ActionResult Edit(Site model)
        {
            if (!ModelState.IsValid || model.ZipCode == null || model.ZipCode == "")
                return View(model);

            _siteAccess().Update(model);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            _siteAccess().Delete(id);

            return new JsonResult() { Data = new { success = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
