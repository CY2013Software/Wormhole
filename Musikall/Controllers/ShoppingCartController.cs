using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Musikall.Models;
using Musikall.Filters;

namespace Musikall.Controllers
{
    [Authorize]
    [InitializeDatabase]
    public class ShoppingCartController : Controller
    {
        private MKContext db = new MKContext();

        //
        // GET: /ShoppingCart/

        public ActionResult Manage()
        {
            return View(db.GetUserProfile(User.Identity.Name).UserData.ShoppingCart);
        }

        public ActionResult DeleteItem(int id)
        {
            var sets = db.GetUserProfile(User.Identity.Name).UserData.ShoppingCart.ItemSets;
            var set = sets.Where(s => s.ItemId == id).FirstOrDefault();
            //从表中删除
            db.ItemSets.Remove(set);

            db.SaveChanges();
            return RedirectToAction("Manage");
        }

        public ActionResult AddItem(int id, bool isDigital, string returnUrl)
        {
            var sets = db.GetUserProfile(User.Identity.Name).UserData.ShoppingCart.ItemSets;
            //筛选出包含该商品的Set
            var selectedSets = sets.Where(s => s.ItemId == id).ToList();
            var item = db.Items.Find(id);
            //非法
            if ((!item.HasEntity && !isDigital) || (!item.HasDigital && isDigital))
            {
                return RedirectToAction("Manage");
            }
            //查找购物车数据中是否包含了该商品，如果是则增加数量，否则新建数据项（14种情况）
            while (true)
            {
                //2种情况v/x
                if (selectedSets.Count == 0)
                {
                    sets.Add(new ItemSet { Count = 1, ItemId = id, IsDigital = isDigital });
                    break;
                }
                //5种情况vv/vvv/vxv/xxv/xvv
                if ((selectedSets.Count == 1 && selectedSets[0].IsDigital && isDigital)/*1种情况*/ || (selectedSets.Count == 2 && isDigital/*4种情况*/))
                {
                    break;
                }
                //2种情况vx/xv
                if (selectedSets.Count == 1 && ((selectedSets[0].IsDigital && !isDigital) || (!selectedSets[0].IsDigital && isDigital)))
                {
                    sets.Add(new ItemSet { Count = 1, ItemId = id, IsDigital = isDigital });
                    break;
                }
                //3种情况xx/xxx/xvx
                if (!selectedSets[0].IsDigital && !isDigital)
                {
                    selectedSets[0].Count++;
                    break;
                }
                //2种情况vxx/xxx
                if (!selectedSets[1].IsDigital && !isDigital)
                {
                    selectedSets[1].Count++;
                    break;
                }
                return HttpNotFound();
            }
            db.SaveChanges();

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Manage");
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}