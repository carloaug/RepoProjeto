using System.Linq;
using System.Web.Mvc;
using System;
using System.Drawing;
using System.Net;
using RSistema.Models;
using PagedList;

namespace RSistema.Controllers
{
    public class RestaurantesController : Controller
    {
        PratoDbContext db;
        public RestaurantesController()
        {
            db = new PratoDbContext();
        }


        public ActionResult Index(string texto)
        {
            if (texto == "RestauranteNome")
            {

                return View(db.Restaurantes.Where(model => model.RestauranteNome.Contains(texto)).OrderBy(model => model.RestauranteNome));

            }
            else
            {

                return View(db.Restaurantes.Where(model => model.RestauranteNome.StartsWith(texto) || texto == null).ToList());
            }

        }
        public ActionResult Create()
        {
            ViewBag.Restaurantes = db.Restaurantes;
            var model = new RestauranteViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestauranteViewModel model)
        {

            if (ModelState.IsValid)
            {
                var restaurante = new Restaurante();
                restaurante.RestauranteNome = model.RestauranteNome;
                restaurante.RestauranteId = model.RestauranteId;

                db.Restaurantes.Add(restaurante);
                db.SaveChanges();

                return RedirectToAction("Index");
            }


            ViewBag.Restaurantes = db.Restaurantes;
            return View(ViewBag.Restaurantes);

        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurantes = db.Restaurantes;
            return View(restaurante);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestauranteNome,RestauranteId")] Restaurante model)
        {
            if (ModelState.IsValid)
            {
                var restaurante = db.Restaurantes.Find(model.RestauranteId);
                if (restaurante == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                restaurante.RestauranteNome = model.RestauranteNome;

                restaurante.RestauranteId = model.RestauranteId;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Restaurante = db.Restaurantes;
            return View(ViewBag.Restaurantes);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurante = db.Restaurantes.Find(restaurante.RestauranteId).RestauranteNome;
            return View(restaurante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurante restaurante = db.Restaurantes.Find(id);
            db.Restaurantes.Remove(restaurante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

