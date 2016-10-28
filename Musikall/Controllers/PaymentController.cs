using Musikall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Musikall.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/
        private MKContext db = new MKContext();

        public ActionResult Pay()
        {
            var cart = db.GetUserProfile(User.Identity.Name).UserData.ShoppingCart;
            if (cart.ItemSets.Count == 0)
            {
                return RedirectToAction("Manage", "ShoppingCart");
            }

            if (cart.UserData.UserProfile.DefaultAddress == null && cart.UserData.UserProfile.AddressBooks.Count == 0)
            {
                return RedirectToAction("AddAddress", "Account", new { returnUrl = Request.Url.AbsolutePath });
            }

            if (cart.UserData.UserProfile.DefaultCard == null)
            {
                if (cart.UserData.UserProfile.CardDetailsSet.Count == 0)
                {
                    return RedirectToAction("AddCard", "Account", new { returnUrl = Request.Url.AbsolutePath });
                }
            }
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmPay(int? addressId, int? cardId)
        {
            var cart = db.GetUserProfile(User.Identity.Name).UserData.ShoppingCart;
            //新建订单
            var order = new Order() { CreateDate = DateTime.Now, UserData = cart.UserData, ItemRecordSets = new List<ItemRecordSet>() };
            db.Orders.Add(order);
            //将购物车数据添加到订单并生成历史记录
            foreach (var set in cart.ItemSets)
            {
                var r = new ItemRecord { Item = set.Item, HistoryPrice = set.Price, IsDigital = set.IsDigital };
                var rset = new ItemRecordSet { ItemRecord = r, Count = set.Count };
                order.ItemRecordSets.Add(rset);
            }
            //查找是否数字版，添加到个人拥有的数字列表
            foreach (var set in cart.ItemSets)
            {
                if (set.IsDigital)
                {
                    cart.UserData.OwnedDigitalItems.Add(new OwnedDigitalItem { Item = set.Item, UserData = cart.UserData });
                }
            }
            //清空购物车数据
            var list = cart.ItemSets.ToList();
            foreach (var item in list)
            {
                db.ItemSets.Remove(item);
            }

            db.SaveChanges();

            return RedirectToAction("Details", "Order", new { id = order.Id });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
