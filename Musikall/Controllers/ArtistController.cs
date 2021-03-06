﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Musikall.Models;
using System.IO;

namespace Musikall.Controllers
{
    public class ArtistController : Controller
    {
        private MKContext db = new MKContext();

        //
        // GET: /Artist/

        public ActionResult Index()
        {
            return View(db.Artists.ToList());
        }

        //
        // GET: /Artist/Details/5

        public ActionResult Details(int id = 0)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // GET: /Artist/Create

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Artist/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Artist artist, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                this.SaveFile(image, artist.Id, "Image/Artist");
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        //
        // GET: /Artist/Edit/5

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /Artist/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Artist artist, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                this.SaveFile(image, artist.Id, "Image/Artist");
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        //
        // GET: /Artist/Delete/5

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}