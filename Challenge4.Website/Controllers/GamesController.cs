﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Challenge4.Website.Models;
using Microsoft.AspNet.Identity;

namespace Challenge4.Website.Controllers
{
    public class GamesController : Controller
    {
        private Entities db = new Entities();

        // GET: Games
        public async Task<ActionResult> Index()
        {
            GamesViewModel viewModel = new GamesViewModel();
            AspNetUser currentUser;

            string userId = User.Identity.GetUserId();
            if (userId != null)
            {
                currentUser = db.AspNetUsers.SingleOrDefault(m => m.Id == userId);
            }
            else
            {
                currentUser = new AspNetUser();
                currentUser.EmailConfirmed = false;
            }

            viewModel.Games = await db.Games.Where(g => g.Date > DateTime.Today).ToListAsync();
            viewModel.AspNetUser = currentUser;

            return View(viewModel);
        }

        public async Task<ActionResult> PastGames()
        {
            GamesViewModel viewModel = new GamesViewModel();
            AspNetUser currentUser;

            string userId = User.Identity.GetUserId();
            if (userId != null)
            {
                currentUser = db.AspNetUsers.SingleOrDefault(m => m.Id == userId);
            }
            else
            {
                currentUser = new AspNetUser();
                currentUser.EmailConfirmed = false;
            }

            viewModel.Games = await db.Games.Where(g => g.Date < DateTime.Today).ToListAsync();
            viewModel.AspNetUser = currentUser;

            return View(viewModel);
        }

        // GET: Games/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Time,Date,Venue,CourtFee,WhoPaid")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Time,Date,Venue,CourtFee,WhoPaid")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Game game = await db.Games.FindAsync(id);
            db.Games.Remove(game);
            await db.SaveChangesAsync();
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
