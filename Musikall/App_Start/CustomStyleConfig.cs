using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musikall
{
    public class CustomStyleConfig
    {
        public static PagedListRenderOptions customPage = new PagedListRenderOptions
            {
                LinkToFirstPageFormat = "«",
                LinkToLastPageFormat = "»",
                LinkToPreviousPageFormat = "Previous",
                LinkToNextPageFormat = "Next",
                DisplayLinkToFirstPage = PagedListDisplayMode.Always,
                DisplayLinkToLastPage = PagedListDisplayMode.Always,
                DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
                DisplayLinkToNextPage = PagedListDisplayMode.Always,
                MaximumPageNumbersToDisplay = 5,
                EllipsesFormat = "..."
            };
    }
}