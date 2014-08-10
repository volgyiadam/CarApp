using System;
using System.Web.Mvc;
using CarApp.Domain;
using CarApp.Domain.Entities;

namespace CarApp.Mvc.Controllers
{
    public class CarController : Controller
    {
        private readonly Func<IEntityAccess<Car>> _carAccess;

        public CarController(Func<IEntityAccess<Car>> carAccess)
        {
            _carAccess = carAccess;
        }

        public ActionResult Test()
        {
            _carAccess().Save(new Car { LicencePlate = "ABC-123" });
            
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var cars = _carAccess().List();

            return View(cars);
        }

        public ActionResult Details(Guid id)
        {
            object model = null; // TODO: model lekérése

            return View(model);
        }

        public ActionResult Edit(Guid? id)
        {
            object model = null; // TODO: model lekérése

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(object model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // TODO: adatok mentése

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            // TODO: törlés

            return new JsonResult() { Data = new { success = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
