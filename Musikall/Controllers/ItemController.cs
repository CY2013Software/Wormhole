using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Musikall.Models;
using Musikall.Filters;
using System.IO;
using PagedList;

namespace Musikall.Controllers
{
    public class ItemController : Controller
    {
        private MKContext db = new MKContext();

        //
        // GET: /Item/

        public ActionResult Index(int? page, string category = "")
        {
            var items = db.Items.Include(i => i.Album).Include(i => i.Artist).Include(i => i.Category).ToList().Where(i => i.IsAlbum);
            if (!string.IsNullOrEmpty(category))
            {
                ViewBag.Category = category;
                items = items.Where(i => i.Category.CategoryName == category);
            }
            return View(items.ToPagedList(page ?? 1, ViewConfig.ItemPageListCount));
        }

        //
        // GET: /Item/Details/5

        public ActionResult Details(int id = 0)
        {
            Item item = db.Items.Find(id);
            if (item == null || !item.IsAlbum)
            {
                return HttpNotFound();
            }
            db.IncPageView(item);
            return View(item);
        }

        //
        // GET: /Item/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Items, "Id", "ItemName");
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "ArtistName");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        //
        // POST: /Item/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Item item, HttpPostedFileBase image, HttpPostedFileBase audition, HttpPostedFileBase download)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                SaveDataEx(item, image, audition, download);
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Items, "Id", "ItemName", item.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "ArtistName", item.ArtistId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", item.CategoryId);
            return View(item);
        }

        //
        // GET: /Item/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Items, "Id", "ItemName", item.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "ArtistName", item.ArtistId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", item.CategoryId);
            return View(item);
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Item item, HttpPostedFileBase image, HttpPostedFileBase audition, HttpPostedFileBase download)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                SaveDataEx(item, image, audition, download);
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Items, "Id", "ItemName", item.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "ArtistName", item.ArtistId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", item.CategoryId);
            return View(item);
        }

        //
        // GET: /Item/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 添加评论未完成
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddComment(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return Details(id);
        }
        /// <summary>
        /// 未完成
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Download(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            if(db.GetUserProfile(User.Identity.Name).UserData.OwnedDigitalItems.Any(i => i.ItemId == id))
            {
                if (item.IsAlbum)
                {
                    return RedirectToAction("Details", new { id = id });
                }
                else
                {
                    if (item.DLUrl != MKContextHelper.NoData)
                    {
                        //application/octet-stream 二进制数据流
                        return File(item.DLUrl, "application/octet-stream", string.Format("{0}-{1}{2}", item.Album.ItemName, item.ItemName, Path.GetExtension(item.DLUrl)));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "The download server has some trouble.";
                        ModelState.AddModelError("", ViewBag.ErrorMessage);
                        return View();
                    }
                }
            }
            return RedirectToAction("Index", "OwnedDigitalItem");
        }

        public void SaveDataEx(Item item, HttpPostedFileBase image, HttpPostedFileBase audition, HttpPostedFileBase download)
        {
            this.SaveFile(image, item.Id, "Image/Cover");
            this.SaveFile(audition, item.Id, "Audio/Audition");
            this.SaveFile(download, item.Id, "Audio/Download");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}