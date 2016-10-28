using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Musikall.Models
{
    public class MKContext : DbContext
    {
        public MKContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<CardDetails> CardDetailsSet { get; set; }

        public DbSet<AddressBook> AddressBooks { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemRecord> ItemRecords { get; set; }

        public DbSet<ItemSet> ItemSets { get; set; }

        public DbSet<ItemRecordSet> ItemRecordSets { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<UserData> UserDataSet { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<OwnedDigitalItem> OwnedDigitalItems { get; set; }

        public DbSet<PageView> PageViews { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<TroubleData> TroubleDataSet { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<City> Cities { get; set; }
    }


    public static class MKContextHelper
    {
        public static UserProfile GetUserProfile(this MKContext db, string name)
        {
            var user = db.UserProfiles.Where(u => u.UserName == name).FirstOrDefault();
            if (user == null)
            {
                if (WebMatrix.WebData.WebSecurity.Initialized)
                {
                    WebMatrix.WebData.WebSecurity.Logout();
                }
            }
            return user;
        }

        public static UserProfile GetUserProfile(this System.Security.Principal.IIdentity iidentity)
        {
            using (var db = new MKContext())
            {
                return db.UserProfiles.Where(u => u.UserName == iidentity.Name).FirstOrDefault();
            }
        }

        public static string NoData = "No Data";

//         public static void AddItem(this MKContext db, Item item)
//         {
//             db.Items.Add(item);
//             if (item.IsAlbum)
//             {
//                 db.ItemMetaSet.Where("");
//             }
//         }

        public static int GetAllPageViewCount(this MKContext db)
        {
            return db.PageViews.Count() == 0 ? 0 : db.PageViews.Sum(p => p.VisitCount);
        }

        public static int GetPageViewCount(this MKContext db, Item item)
        {
            var pv = item.PageView;
            if (pv == null)
            {
                pv = new PageView { Item = item };
                db.PageViews.Add(pv);
                db.SaveChanges();
            }
            return pv.VisitCount;
        }

        public static void IncPageView(this MKContext db, Item item)
        {
            var pv = item.PageView;
            if (pv == null)
            {
                pv = new PageView { Item = item };
                db.PageViews.Add(pv);
            }
            pv.VisitCount++;
            db.SaveChanges();
        }
    }
}