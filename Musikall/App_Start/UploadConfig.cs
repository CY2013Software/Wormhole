using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Musikall
{
    public class UploadConfig
    {
        static UploadConfig()
        {
            Enable = false;
        }
        public static bool Enable { get; set; }
    }

    public static class UploadHelper
    {
        public static bool Empty(this HttpPostedFileBase file)
        {
            return file == null || file.ContentLength == 0;
        }

        public static void SaveFile(this Controller ctr, HttpPostedFileBase file, int id, string path)
        {
            if (!file.Empty())
            {
                string localPath = string.Format("~/{0}/{1}{2}", path, id, Path.GetExtension(file.FileName));
                if (UploadConfig.Enable)
                {
                    file.SaveAs(ctr.Server.MapPath(localPath));
                }
            }
        }
    }
}