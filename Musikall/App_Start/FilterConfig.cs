using System.Web;
using System.Web.Mvc;
using Musikall.Filters;

namespace Musikall
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new InitializeDatabaseAttribute());
        }
    }
}