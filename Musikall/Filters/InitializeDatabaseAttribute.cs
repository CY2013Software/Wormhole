using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using Musikall.Models;
using System.Web.Security;

namespace Musikall.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeDatabaseAttribute : ActionFilterAttribute
    {
        private static DatabaseInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 确保每次启动应用程序时只初始化一次 ASP.NET Simple Membership
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class DatabaseInitializer
        {
            public DatabaseInitializer()
            {
                try
                {
                    using (var context = new MKContext())
                    {
                        if (context.GetUserProfile("meno") == null)
                        {
                            var user = new UserProfile(context) { Email = "meno@meno.com", UserName = "meno" };
                            context.SaveChanges();

                            if (!WebSecurity.Initialized)
                            {
                                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "Id", "UserName", autoCreateTables: true);
                            }
                            WebSecurity.CreateAccount(user.UserName, "111111");

                            Roles.CreateRole("Admin");
                            Roles.CreateRole("Master");

                            Roles.AddUserToRoles(user.UserName, Roles.GetAllRoles());

                            user = new UserProfile(context) { Email = "yuhi@yuhi.com", UserName = "yuhi" };
                            context.SaveChanges();
                            WebSecurity.CreateAccount(user.UserName, "111111");
                            Roles.AddUserToRole(user.UserName, "admin");
                        }

                        if (!context.Database.Exists())
                        {
                            // 创建不包含 Entity Framework 迁移架构的 SimpleMembership 数据库
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    if (!WebSecurity.Initialized)
                    {
                        WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "Id", "UserName", autoCreateTables: true);
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("无法初始化 ASP.NET 数据库。有关详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
