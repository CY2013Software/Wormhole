using Musikall.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;

namespace Musikall.Controllers
{
    public class UserController : Controller
    {
        private MKContext db = new MKContext();
        // GET: /User/
        [Authorize(Roles = "Admin")]
        public ActionResult Index(int ? page)
        {
            return View(db.UserProfiles.OrderBy(s => s.Id).ToPagedList(page ?? 1, ViewConfig.UserPageListCount));
        }

        //
        // GET: /Item/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            var user = db.UserProfiles.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(new UserEditModel{ User = user, IsAdmin = Roles.IsUserInRole(user.UserName, "Admin")});
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model.User).State = EntityState.Modified;
                db.SaveChanges();
                if (model.IsAdmin)
                {
                    if (!Roles.IsUserInRole(model.User.UserName,"Admin"))
                    {
                        Roles.AddUserToRole(model.User.UserName, "Admin");
                    }
                }
                else
                {
                    if (Roles.IsUserInRole(model.User.UserName, "Admin"))
                    {
                        Roles.RemoveUserFromRole(model.User.UserName, "Admin");
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles = "Master")]
        public ActionResult Delete(int id = 0)
        {
            var user = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(user);
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
