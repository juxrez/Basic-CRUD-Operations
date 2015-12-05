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
        //AJ 05/12/15 
        //Hello Barry, if you are reading dis comments, its because probably something went very wrong, and i failed.
        //You deserve the best, Barry, thats why im gonna give you what you most want in dis world. This project.
        /* 
         At this controller all magic comes up, All ActionResult methods are called from the view
         
         */
        //With dis, you deposite all your models on your db into a variable for use it in this file
        gamesDBEntities db = new gamesDBEntities();
        // GET: Games
        public ActionResult Index()
        {
            //Look up for all registers in table games, and convert it to a list
            //send the list to the view
            return View(db.Games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int id)
        {
            //search register in table by id and send it to the view
            //FirstOrDefault Return first value SQL find, and if not, return a empty object
            Game _game = db.Games.FirstOrDefault(u => u.Id == id);
            return View(_game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            //get methods just calls the view
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Game postGame)
        {//post methods recieve data
            try
            {
                if (ModelState.IsValid)
                {//if model isnt corrupt on data (validations that you choose when create database like, type, length, etc)
                    Game newGame = new Game();
                    //create a new object and copy propierties of post object you recied
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
                    //entry look for diffs in objects
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
