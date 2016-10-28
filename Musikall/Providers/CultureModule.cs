using Musikall.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Musikall.Providers
{
    public static class CultureHelper
    {
        static StringBuilder sb = new StringBuilder();
        public static string Local(this HtmlHelper html, string key)
        {
            sb.Clear();
            var splits = key.Split(' ');
            for (int i = 0; i < splits.Length; i++)
            {
                sb.Append(Resources.Strings.ResourceManager.GetString(splits[i]));
                if (i != splits.Length - 1)
                {
                    sb.Append(Strings.Blank);
                }
            }
            return sb.ToString();
        }

        public static string Link(this string str, string s)
        {
            return string.Concat(str, Strings.Blank, s);
        }
    }

    public class CultureModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += SetCurrentCulture;
            context.EndRequest += RecoverCulture;
        }

        private void SetCurrentCulture(object sender, EventArgs args)
        {
            HttpContextBase contextWrapper = new HttpContextWrapper(HttpContext.Current);
            RouteData routeData = RouteTable.Routes.GetRouteData(contextWrapper);
            if (routeData == null)
            {
                return;
            }
            object culture;
            if (routeData.Values.TryGetValue("lang", out culture) && !string.IsNullOrEmpty(culture.ToString()))
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(culture.ToString());
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture.ToString());
                }
                catch
                { }
            }
            else
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                }
                catch
                { }
            }
        }
        private void RecoverCulture(object sender, EventArgs args)
        {
        }
    }
}