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
    [Authorize]
    public class OwnedDigitalItemController : Controller
    {
        private MKContext db = new MKContext();

        //
        // GET: /OwnedDigitalItem/

        public ActionResult Index(int ? page)
        {
            return View(db.GetUserProfile(User.Identity.Name).UserData.OwnedDigitalItems.ToPagedList(page ?? 1, ViewConfig.OwnedDigitalItemPageListCount));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}