using System.Linq;
using System.Web.Mvc;
using System;
using System.Drawing;
using System.Net;
using RSistema.Models;



namespace RSistema.Controllers
{
    public class PratosController : Controller
    {
        PratoDbContext db;
        public PratosController()
        {
            db = new PratoDbContext();
        }
        // GET: Pratos
        public ActionResult Index()
        {
            var pratos = db.Pratos.ToList();
            return View(pratos);
        }
        public ActionResult Create()
        {
            ViewBag.Restaurantes = db.Restaurantes;
            var model = new PratoViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PratoViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                var prato = new Prato();
                prato.PratoNome = model.PratoNome;
                prato.PratoPreco = model.PratoPreco;
                prato.RestauranteId = model.RestauranteId;

                db.Pratos.Add(prato);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // Caso houver erro retorna a pagina inicial
           
            ViewBag.Restaurantes = db.Restaurantes;
            return View(ViewBag.Restaurantes);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurantes = db.Restaurantes;
            return View(prato);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PratoId,PratoNome,PratoPreco,RestauranteId")] Prato model)
        {
            if (ModelState.IsValid)
            {
                var prato = db.Pratos.Find(model.PratoId);
                if (prato == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                prato.PratoNome = model.PratoNome;
                prato.PratoPreco = model.PratoPreco;
                prato.RestauranteId = model.RestauranteId;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Restaurante = db.Restaurantes;
            return View(ViewBag.Restaurante);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurante = db.Restaurantes.Find(prato.RestauranteId).RestauranteNome;
            return View(prato);
        }

        // POST: Pratos/Delete/

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prato prato = db.Pratos.Find(id);
            db.Pratos.Remove(prato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}