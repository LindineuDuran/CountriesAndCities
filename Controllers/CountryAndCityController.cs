using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CountriesAndCities.DAL;
using CountriesAndCities.Models;

namespace CountriesAndCities.Controllers
{
    public class CountryAndCityController : Controller
    {
        private CountryAndCityContext db = new CountryAndCityContext();

        // GET: CountryAndCity
        public ActionResult Index()
        {
            var countriesAndCities = db.CountriesAndCities.Include(c => c.City).Include(c => c.Country);
            return View(countriesAndCities.ToList());
        }

        // GET: CountryAndCity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryAndCity countryAndCity = db.CountriesAndCities.Find(id);
            if (countryAndCity == null)
            {
                return HttpNotFound();
            }
            return View(countryAndCity);
        }

        // GET: CountryAndCity/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name");
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name");
            return View();
        }

        // POST: CountryAndCity/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CityID,CountryID")] CountryAndCity countryAndCity)
        {
            if (ModelState.IsValid)
            {
                db.CountriesAndCities.Add(countryAndCity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", countryAndCity.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", countryAndCity.CountryID);
            return View(countryAndCity);
        }

        // GET: CountryAndCity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryAndCity countryAndCity = db.CountriesAndCities.Find(id);
            if (countryAndCity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", countryAndCity.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", countryAndCity.CountryID);
            return View(countryAndCity);
        }

        // POST: CountryAndCity/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CityID,CountryID")] CountryAndCity countryAndCity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryAndCity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", countryAndCity.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", countryAndCity.CountryID);
            return View(countryAndCity);
        }

        // GET: CountryAndCity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryAndCity countryAndCity = db.CountriesAndCities.Find(id);
            if (countryAndCity == null)
            {
                return HttpNotFound();
            }
            return View(countryAndCity);
        }

        // POST: CountryAndCity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryAndCity countryAndCity = db.CountriesAndCities.Find(id);
            db.CountriesAndCities.Remove(countryAndCity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
