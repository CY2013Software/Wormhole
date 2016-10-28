using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Musikall.Filters;
using Musikall.Models;
using System.IO;

namespace Musikall.Controllers
{
    [Authorize]
    [InitializeDatabase]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string realName = model.UserName;
                //判断输入的用户名是否邮箱
                if (new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(model.UserName))
                {
                    //从数据库查找用户名
                    using (var db = new MKContext())
                    {
                        var user = db.UserProfiles.Where(u => u.Email == model.UserName).FirstOrDefault();
                        if (user != null)
                        {
                            realName = user.UserName;
                        }
                    }
                }
                if (WebSecurity.Login(realName, model.Password, persistCookie: model.RememberMe))
                {
                    return RedirectToLocal(returnUrl);
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            ViewBag.ErrorMessage = "Username or password error";
            ModelState.AddModelError("", ViewBag.ErrorMessage);
            return View(model);
        }

        //
        // POST: /Account/LogOff

//         [HttpPost]
//         [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                while (true)
                {
                    using (var db = new MKContext())
                    {
                        var user = db.UserProfiles.Where(u => u.UserName == model.UserName || u.Email == model.Email).FirstOrDefault();
                        if (user != null)
                        {
                            ViewBag.ErrorMessage = "Email or username is already exist";
                            ModelState.AddModelError("", ViewBag.ErrorMessage);
                            break;
                        }
                        model.AddUserProfile(db);
                        db.SaveChanges();
                    }
                    // 尝试注册用户
                    try
                    {
                        WebSecurity.CreateAccount(model.UserName, model.Password);
                        WebSecurity.Login(model.UserName, model.Password);
                        return RedirectToAction("Index", "Home");
                    }
                    catch (MembershipCreateUserException e)
                    {
                        ViewBag.ErrorMessage = ErrorCodeToString(e.StatusCode);
                        ModelState.AddModelError("", ViewBag.ErrorMessage);
                    }
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        public ActionResult Overall()
        {
            using (var db = new MKContext())
            {
                var user = db.UserProfiles.Include(p => p.CardDetailsSet).Include(p => p.AddressBooks).Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                return View(user);
            }
        }

        //--------------------------------------

        public ActionResult AddAddress(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            using (var db = new MKContext())
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAddress(AddressBook model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new MKContext())
            {
                var user = db.GetUserProfile(User.Identity.Name);
                user.AddressBooks.Add(model);
                model.UserProfile = user;
                //先保存数据，model的Id会进行更改
                db.SaveChanges();
                if (user.DefaultAddress == null)
                {
                    user.DefaultAddressId = model.Id;
                }
                db.SaveChanges();
            }
            return RedirectToLocal(returnUrl);
        }

        public ActionResult ModifyAddress(int id, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            using (var db = new MKContext())
            {
                var address = db.AddressBooks.Find(id);
                if (address == null)
                {
                    return HttpNotFound();
                }
                //非法访问
                if (!db.GetUserProfile(User.Identity.Name).AddressBooks.Any(i => i.Id == id))
                {
                    return HttpNotFound();
                }
                return View(address);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifyAddress(AddressBook model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new MKContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToLocal(returnUrl);
        }

        public ActionResult SetDefaultAddress(int id, string returnUrl)
        {
            using (var db = new MKContext())
            {
                var address = db.AddressBooks.Find(id);
                if (address == null)
                {
                    return HttpNotFound();
                }
                var user = db.GetUserProfile(User.Identity.Name);
                //非法访问
                if (!user.AddressBooks.Any(i => i.Id == id))
                {
                    return HttpNotFound();
                }
                user.DefaultAddressId = address.Id;
                db.SaveChanges();
            }
            return RedirectToLocal(returnUrl);
        }

        public ActionResult DeleteAddress(int id, string returnUrl)
        {
            using (var db = new MKContext())
            {
                var user = db.GetUserProfile(User.Identity.Name);
                var address = db.AddressBooks.Find(id);
                if (address == null)
                {
                    return HttpNotFound();
                }
                if (!user.AddressBooks.Any(i => i.Id == id))
                {
                    return HttpNotFound();
                }
                db.AddressBooks.Remove(address);
                db.SaveChanges();
                if (user.DefaultAddressId == id)
                {
                    if (db.AddressBooks.Count() != 0)
                    {
                        user.DefaultAddressId = db.AddressBooks.First().Id;
                    }
                    else
                    {
                        user.DefaultAddressId = null;
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToLocal(returnUrl);
        }

        //-----------------------------

        public ActionResult AddCard(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            using (var db = new MKContext())
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCard(CardDetails model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new MKContext())
            {
                var user = db.GetUserProfile(User.Identity.Name);
                user.CardDetailsSet.Add(model);
                model.UserProfile = user;
                //先保存数据，model的Id会进行更改
                db.SaveChanges();
                if (user.DefaultCard == null)
                {
                    user.DefaultCardId = model.Id;
                }
                db.SaveChanges();
            }
            return RedirectToLocal(returnUrl);
        }

        public ActionResult SetDefaultCard(int id, string returnUrl)
        {
            using (var db = new MKContext())
            {
                var card = db.CardDetailsSet.Find(id);
                if (card == null)
                {
                    return HttpNotFound();
                }
                var user = db.GetUserProfile(User.Identity.Name);
                //非法访问
                if (!user.CardDetailsSet.Any(i => i.Id == id))
                {
                    return HttpNotFound();
                }
                user.DefaultCardId = card.Id;
                db.SaveChanges();
            }
            return RedirectToLocal(returnUrl);
        }

        public ActionResult DeleteCard(int id, string returnUrl)
        {
            using (var db = new MKContext())
            {
                var user = db.GetUserProfile(User.Identity.Name);
                var card = db.CardDetailsSet.Find(id);
                if (card == null)
                {
                    return HttpNotFound();
                }
                if (!user.CardDetailsSet.Any(i => i.Id == id))
                {
                    return HttpNotFound();
                }
                db.CardDetailsSet.Remove(card);
                db.SaveChanges();
                if (user.DefaultCardId == id)
                {
                    if (db.CardDetailsSet.Count() != 0)
                    {
                        user.DefaultCardId = db.CardDetailsSet.First().Id;
                    }
                    else
                    {
                        user.DefaultCardId = null;
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToLocal(returnUrl);
        }

        //-----------------------------

        public ActionResult ModifyAvatar(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            using (var db = new MKContext())
            {
                ViewBag.AvatarUrl = db.GetUserProfile(User.Identity.Name).AvatarUrl;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifyAvatar(HttpPostedFileBase image, string returnUrl)
        {
            if (image.Empty())
            {
                ViewBag.ErrorMessage = "No image upload.";
                ModelState.AddModelError("", ViewBag.ErrorMessage);
                return ModifyAvatar(returnUrl);
            }
            //保存图片
            using (var db = new MKContext())
            {
                this.SaveFile(image, db.GetUserProfile(User.Identity.Name).Id, "Image/Avatar");
            }

            return RedirectToLocal(returnUrl);
        }

        #region 帮助程序
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // 请参见 http://go.microsoft.com/fwlink/?LinkID=177550 以查看
            // 状态代码的完整列表。
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "用户名已存在。请输入其他用户名。";

                case MembershipCreateStatus.DuplicateEmail:
                    return "该电子邮件地址的用户名已存在。请输入其他电子邮件地址。";

                case MembershipCreateStatus.InvalidPassword:
                    return "提供的密码无效。请输入有效的密码值。";

                case MembershipCreateStatus.InvalidEmail:
                    return "提供的电子邮件地址无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidAnswer:
                    return "提供的密码取回答案无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidQuestion:
                    return "提供的密码取回问题无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidUserName:
                    return "提供的用户名无效。请检查该值并重试。";

                case MembershipCreateStatus.ProviderError:
                    return "身份验证提供程序返回了错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";

                case MembershipCreateStatus.UserRejected:
                    return "已取消用户创建请求。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";

                default:
                    return "发生未知错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";
            }
        }
        #endregion
    }
}
