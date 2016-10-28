using Musikall.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Musikall.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        private MKContext db = new MKContext();
        //
        // GET: /Report/

        public ActionResult Index()
        {
            var rep = new ReportModel();
            rep.StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            rep.TimeSpan = DateTime.Now - rep.StartTime;

            var orders = db.Orders.Where(o => o.CreateDate.Month == rep.StartTime.Month).ToList();

            rep.OrderCount = orders.Count();

            rep.Sales = orders.Sum(o => o.TotalPrice);

            rep.Count = orders.Sum(o => o.TotalCount);

            rep.DigitalSales = orders.Sum(o => o.TotalDigitalPrice);

            rep.DigitalCount = orders.Sum(o => o.TotalDigitalCount);

            rep.NewAlbum = db.Items.ToList().Where(i => i.IsAlbum && i.AddedDate.Month == rep.StartTime.Month).Count();

            rep.UserCount = orders.Select(o => o.UserData).Distinct().Count();

            rep.TotalPV = db.GetAllPageViewCount();

            return View(rep);
        }

        public ActionResult RefreshDataCheck()
        {
            foreach (var item in db.TroubleDataSet.ToList())
            {
                db.TroubleDataSet.Remove(item);
            }

            foreach (var item in db.Artists)
            {
                if (string.IsNullOrEmpty(item.Introduction))
                {
                    db.TroubleDataSet.Add(TroubleData.Create(item, "Introduction：艺术家建议拥有介绍"));
                }
                if (string.IsNullOrEmpty(item.About))
                {
                    db.TroubleDataSet.Add(TroubleData.Create(item, "Introduction：艺术家建议拥有About"));
                }
                if (item.ImageUrl == MKContextHelper.NoData)
                {
                    db.TroubleDataSet.Add(TroubleData.Create(item, "Introduction：艺术家建议拥有Image"));
                }
            }
            foreach (var item in db.Items.ToList())
            {
                if (!item.HasDigital && !item.HasEntity)
                {
                    db.TroubleDataSet.Add(TroubleData.Create(item,"Edition：至少拥有数字版或者实体版"));
                }
                if (!item.HasDigital && item.DigitalPrice != 0)
                {
                    db.TroubleDataSet.Add(TroubleData.Create(item,"Edition：不拥有数字版的商品价格应该为0"));
                }
                if (!item.HasEntity && item.Price != 0)
                {
                    db.TroubleDataSet.Add(TroubleData.Create(item,"Edition：不拥有实体版的商品价格应该为0"));
                }
                if (item.HasEntity && !item.IsAlbum)
                {
                    db.TroubleDataSet.Add(TroubleData.Create(item, "Edition：单曲不能拥有实体版"));
                }
                //-----------------------------
                if (item.IsSingle)
                {
                    if (item.TrackId == null)
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item,"TrackId：单曲应该拥有音轨号"));
                    }
                }
                else
                {
                    if (item.TrackId != null)
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item,"TrackId：非单行曲的专辑不应该拥有音轨号"));
                    }
                }
                //-----------------------------
                if (item.IsAlbum)
                {
                    if (item.ReleaseDate == null)
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item,"ReleaseDate：专辑应该拥有发行日期"));
                    }
                }
                else
                {
                    if (item.ReleaseDate != null)
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item,"ReleaseDate：不应该拥有发行日期"));
                    }
                }
                //-----------------------------
                if (item.IsAlbum)
                {
                    if (string.IsNullOrEmpty(item.Introduction))
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item,"Introduction：专辑建议拥有介绍"));
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(item.Introduction))
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item,"Introduction：不建议拥有介绍"));
                    }
                }
                //-----------------------------
                if (item.IsAlbum && !item.IsSingleAlbum)
                {
                    if (item.SongList.Where(s => s.TrackId != null).Select(s => s.TrackId.Value).Distinct().Count() != item.SongList.Count)
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item,"Album：专辑有重复TrackId"));
                    }
                    if (item.SongList.Max(s => s.TrackId) != item.SongList.Count)
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item,"Album：Track有缺失"));
                    }
                }
                //-----------------------------
                if (item.IsSingle)
                {
                    if (item.AuditionUrl == MKContextHelper.NoData)
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item,"Audition：单曲建议拥有Audition"));
                    }
                }
                else
                {
                    if (item.AuditionUrl != MKContextHelper.NoData)
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item,"Audition：不建议拥有Audition"));
                    }
                }
                //-----------------------------
                if (item.IsAlbum)
                {
                    if (item.ImageUrl == MKContextHelper.NoData)
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item, "Cover：专辑建议拥有Cover"));
                    }
                }
                else
                {
                    if (item.ImageUrl != MKContextHelper.NoData)
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item, "Cover：不建议拥有Cover"));
                    }
                }
                //-----------------------------
                if (item.IsSingle && item.HasDigital)
                {
                    if (item.DLUrl == MKContextHelper.NoData)
                        db.TroubleDataSet.Add(TroubleData.Create(item,"DL：数字版单曲应该拥有DL"));
                }
                else
                {
                    if (item.DLUrl != MKContextHelper.NoData)
                        db.TroubleDataSet.Add(TroubleData.Create(item,"DL：不应该拥有DL"));
                }
                //------------
                if (!item.IsAlbum)
                {
                    if (!item.Album.IsAlbum)
                    {
                        db.TroubleDataSet.Add(TroubleData.Create(item,"Album：单曲的专辑不是专辑"));
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("DataCheck");
        }

        public ActionResult DataCheck(int? page)
        {
            return View(db.TroubleDataSet.OrderBy(s => s.Id).ToPagedList(page ?? 1, ViewConfig.DataTroublePageListCount));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
