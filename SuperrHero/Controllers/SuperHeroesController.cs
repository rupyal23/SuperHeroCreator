using SuperrHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperrHero.Controllers
{
    public class SuperHeroesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: SuperHeroes
        public ActionResult Index()
        {
            return View(db.SuperHeroes);
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            return View(db.SuperHeroes.Where(a => a.Id == id).Single());
        }
        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        public ActionResult Create(SuperHero Hero)
        {
            try
            {
                // TODO: Add insert logic here
                //Done - Working
                db.SuperHeroes.Add(Hero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.SuperHeroes.Where(c => c.Id == id).Single());
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SuperHero Hero)
        {
            try
            {
                // TODO: Add update logic here
                //Done - Working
                var superHeroFromDb = db.SuperHeroes.Where(c => c.Id == id).Single();
                superHeroFromDb.Name = Hero.Name;
                superHeroFromDb.AlterEgo = Hero.AlterEgo;
                superHeroFromDb.PrimaryAbility = Hero.PrimaryAbility;
                superHeroFromDb.SecondaryAbility = Hero.SecondaryAbility;
                superHeroFromDb.Catchphrase = Hero.Catchphrase;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.SuperHeroes.Find(id));
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHero Hero)
        {
            try
            {
                // TODO: Add delete logic here
                var superHeroFromDb = db.SuperHeroes.Find(id);
                db.SuperHeroes.Remove(superHeroFromDb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
