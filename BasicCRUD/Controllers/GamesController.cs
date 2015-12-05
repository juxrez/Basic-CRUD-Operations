using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicCRUD.Models;
using System.Data.Entity;
namespace BasicCRUD.Controllers
{
    public class GamesController : Controller
    {
        gamesDBEntities db = new gamesDBEntities();
        // GET: Games
        public ActionResult Index()
        {
            
            return View(db.Games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int id)
        {
            Game _game = db.Games.FirstOrDefault(u => u.Id == id);
            return View(_game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Game postGame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Game newGame = new Game();
                    newGame.Name = postGame.Name;
                    newGame.Description = postGame.Description;
                    db.Games.Add(newGame);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Games.FirstOrDefault(g => g.Id == id));
        }

        // POST: Games/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Game postGame)
        {
            try
            {
                // TODO: Add update logic here
                if(ModelState.IsValid)
                {
                    db.Entry(postGame).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Games.FirstOrDefault(g => g.Id == id));
        }

        // POST: Games/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Game postGame)
        {
            try
            {
                // TODO: Add delete logic here
                if(ModelState.IsValid)
                {
                    Game game = db.Games.Find(id);
                    db.Games.Remove(game);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
