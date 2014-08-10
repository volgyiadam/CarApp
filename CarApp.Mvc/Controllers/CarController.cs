using System;
using System.Web.Mvc;
using CarApp.Domain;
using CarApp.Domain.Entities;
using System.Linq;

namespace CarApp.Mvc.Controllers
{
    public class CarController : Controller
    {
        private readonly Func<IEntityAccess<Car>> _carAccess;
        private readonly Func<IEntityAccess<Site>> _siteAccess;

        public CarController(Func<IEntityAccess<Car>> carAccess, Func<IEntityAccess<Site>> siteAccess)
        {
            _carAccess = carAccess;
            _siteAccess = siteAccess;
        }

        //public ActionResult Test()
        //{
        //    _carAccess().Save(new Car { LicencePlate = "ABC-123" });

        //    return RedirectToAction("Index");
        //}

        public ActionResult Index()
        {
            var cars = _carAccess().List();

            return View(cars);
        }

        public ActionResult Details(Guid id)
        {
            var model = _carAccess().Get(id);

            return View(model);
        }

        public ActionResult Create()
        {
            Car model = new Car();


            return View(model);

        }

        [HttpPost]

        public ActionResult Create(Car model)
        {
            if (!ModelState.IsValid || model.LicencePlate == null)
                return View(model);

            _carAccess().Save(model);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid? id)
        {

            Car model = _carAccess().Get(id.Value);
            TelephelyekLista();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Car model)
        {
            if (!ModelState.IsValid || model.LicencePlate == null)
                return View(model);

            _carAccess().Update(model);


            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            _carAccess().Delete(id);

            return new JsonResult() { Data = new { success = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        private void TelephelyekLista()
        {
            ViewBag.Telephelyek = _siteAccess().List().Select(y => new SelectListItem { Text = y.Address, Value = y.Id.ToString() });
        }
    }
}
