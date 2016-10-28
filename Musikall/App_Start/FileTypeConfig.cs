using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musikall
{
    public class FileTypeConfig
    {
        static FileTypeConfig()
        {
            ImageType = new string[] { ".jpg", ".png" };
            AudioType = new string[] { ".mp3", ".flac" };
        }
        public static string[] ImageType { get; set; }

        public static string[] AudioType { get; set; }
    }
}