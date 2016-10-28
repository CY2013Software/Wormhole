using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musikall
{
    public class ViewConfig
    {
        static ViewConfig()
        {
            ItemPageListCount = 36;
            DataTroublePageListCount = 20;
            ArtistPageAlbumListCount = 4;
            ArtistPageSingleListCount = 20;
            OrderPageListCount = 10;
            SearchPageListCount = 10;
            UserPageListCount = 10;
            OwnedDigitalItemPageListCount = 10;
        }

        public static int ItemPageListCount { get; set; }
        public static int DataTroublePageListCount { get; set; }
        public static int ArtistPageAlbumListCount { get; set; }
        public static int ArtistPageSingleListCount { get; set; }
        public static int OrderPageListCount { get; set; }
        public static int SearchPageListCount { get; set; }
        public static int UserPageListCount { get; set; }
        public static int OwnedDigitalItemPageListCount { get; set; }
    }
}