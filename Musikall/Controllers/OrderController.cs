using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Musikall.Models;
using Musikall.Filters;
using PagedList;

namespace Musikall.Controllers
{
    [Authorize]
    [InitializeDatabase]
    public class OrderController : Controller
    {
        private MKContext db = new MKContext();

        //
        // GET: /Order/

        public ActionResult List(int ? page)
        {
            return View(db.GetUserProfile(User.Identity.Name).UserData.Orders.ToPagedList(page ?? 1, ViewConfig.OrderPageListCount));
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id = 0)
        {
            var userId = db.GetUserProfile(User.Identity.Name).Id;
            Order order = db.Orders.Where(o => o.UserData.Id == userId && o.Id == id).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ManageDetails(int id, int userId)
        {
            var userd = db.UserDataSet.Where(d => d.Id == userId).FirstOrDefault();
            if (userd == null)
            {
                return HttpNotFound();
            }
            Order order = userd.Orders.Where(o => o.Id == id).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(Tuple.Create(userd,order));
        }

        public ActionResult Delete(int id = 0)
        {
            var userId = db.GetUserProfile(User.Identity.Name).Id;
            Order order = db.Orders.Where(o => o.UserData.Id == userId && o.Id == id).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            else
            {
                //删除对应的购买数量组信息，但保留历史价格记录以便进行统计
                var list = order.ItemRecordSets.ToList();
                foreach (var item in list)
                {
                    db.ItemRecordSets.Remove(item);
                }
                //删除订单
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}