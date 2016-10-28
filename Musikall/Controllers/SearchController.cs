using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Musikall.Models;
using PagedList;

namespace Musikall.Controllers
{
    public class SearchController : Controller
    {
        private MKContext db = new MKContext();

        //
        // GET: /Search/
        /// <summary>
        /// 当single，album，artist任意一个参数为true时，page将起作用进行分页，且结果为参数最开始为true对应的类型
        /// </summary>
        /// <param name="key"></param>
        /// <param name="single"></param>
        /// <param name="album"></param>
        /// <param name="artist"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Keyword(string key, bool? single, bool? album, bool? artist, int? page)
        {
            if (string.IsNullOrEmpty(key))
            {
                return RedirectToAction("Index", "Home");
            }
            var keys = key.Split(' ');
            var items = db.Items.Include(i => i.Category).ToList().Where(i => IsMatch(keys, i.ItemName));

            if (single ?? false)
            {
                ViewBag.SingleResults = items.Where(i => i.IsSingle).ToPagedList(page ?? 1, ViewConfig.ItemPageListCount);
                return View();
            }

            if (album ?? false)
            {
                ViewBag.AlbumResults = items.Where(i => i.IsAlbum).ToPagedList(page ?? 1, ViewConfig.ItemPageListCount);
                return View();
            }

            if (artist ?? false)
            {
                ViewBag.ArtistResults = db.Artists.ToList().Where(i => IsMatch(keys, i.ArtistName)).ToPagedList(page ?? 1, ViewConfig.ItemPageListCount);
                return View();
            }

            ViewBag.SingleResults = items.Where(i => i.IsSingle).ToPagedList(1, ViewConfig.SearchPageListCount);
            ViewBag.AlbumResults = items.Where(i => i.IsAlbum).ToPagedList(1, ViewConfig.SearchPageListCount);
            ViewBag.ArtistResults = db.Artists.ToList().Where(i => IsMatch(keys, i.ArtistName)).ToPagedList(1, ViewConfig.SearchPageListCount);
            return View();
        }

        bool IsMatch(string[] key, string str)
        {
            foreach (var item in key)
            {
                if (str.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
