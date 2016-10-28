using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
using System.Web.Mvc;  
using System.Data.Entity;
using Musikall.Models;
using WebMatrix.WebData;
using System.Text;  

namespace Musikall.Providers
{
    public class NotExistsDatabaseInitializer : CreateDatabaseIfNotExists<MKContext>
    {
        protected override void Seed(MKContext context)
        {
            ModelChangesDatabaseInitializer.DoSeed(context);
        }
    }

    public class ModelChangesDatabaseInitializer : DropCreateDatabaseIfModelChanges<MKContext>
    {
        public static void DoSeed(MKContext db)
        {
            var popCategory = new Category { CategoryName = "Pop" };
            db.Categories.Add(popCategory);
            var rockCategory = new Category { CategoryName = "Rock" };
            db.Categories.Add(rockCategory);
            var elecCategory = new Category { CategoryName = "Electronic" };
            db.Categories.Add(elecCategory);
            var classicalCategory = new Category { CategoryName = "Classical" };
            db.Categories.Add(classicalCategory);
            var othersCategory = new Category { CategoryName = "Others" };
            db.Categories.Add(othersCategory);
            db.SaveChanges();

            var xi = new Artist { ArtistName = "xi", Introduction = "Music game producer" };
            db.Artists.Add(xi);
            var deco27 = new Artist { ArtistName = "deco*27", Introduction = "Vocaloid producer" };
            db.Artists.Add(deco27);
            var cleanTears = new Artist { ArtistName = "Clean Tears", Introduction = "Vocaloid producer" };
            db.Artists.Add(cleanTears);
            var ketasyo = new Artist { ArtistName = "けーだっしゅ", Introduction = "Vocaloid producer" };
            db.Artists.Add(ketasyo);
            db.SaveChanges();

            var songCollection = new Item { ItemName = "SongCollection vol.1", Category = othersCategory, Artist = xi, Introduction = "Test Album", HasEntity = true, HasDigital = true, Price = 210, DigitalPrice = 120, ReleaseDate = new DateTime(2010, 5, 2) };
            db.Items.Add(songCollection);
            db.SaveChanges();
            db.Items.Add(new Item { ItemName = "Day Break", Category = elecCategory, Artist = xi, TrackId = 1, Album = songCollection, HasDigital = true, DigitalPrice = 25 });
            db.Items.Add(new Item { ItemName = "STORIA", Category = elecCategory, Artist = xi, TrackId = 2, Album = songCollection, HasDigital = true, DigitalPrice = 28 });
            db.Items.Add(new Item { ItemName = "ANiMA", Category = elecCategory, Artist = xi, TrackId = 3, Album = songCollection, HasDigital = true, DigitalPrice = 25 });
            db.Items.Add(new Item { ItemName = "Halcyon", Category = elecCategory, Artist = xi, TrackId = 4, Album = songCollection, HasDigital = true, DigitalPrice = 27 });

            db.Items.Add(new Item { ItemName = "Liar dance", Category = popCategory, Artist = deco27, TrackId = 5, Album = songCollection, HasDigital = true, DigitalPrice = 62 });

            var song = new Item { ItemName = "サンセットマーチ", Category = othersCategory, Artist = ketasyo, TrackId = 1, Introduction = "Single Album", HasDigital = true, DigitalPrice = 28, ReleaseDate = new DateTime(2016, 1, 22) };
            db.Items.Add(song);

            song = new Item { ItemName = "Niflheimr", Category = othersCategory, Artist = xi, TrackId = 1, Introduction = "Niflheimr", HasDigital = true, DigitalPrice = 38, ReleaseDate = new DateTime(2015, 1, 12) };
            db.Items.Add(song);

            song = new Item { ItemName = "FREEDOM DIVE", Category = elecCategory, Artist = xi, TrackId = 1, Introduction = "FREEDOM DIVE", HasDigital = true, DigitalPrice = 40, ReleaseDate = new DateTime(2016, 6, 27) };
            db.Items.Add(song);

            song = new Item { ItemName = "Aragami", Category = elecCategory, Artist = xi, TrackId = 1, Introduction = "Aragami", HasEntity = true, Price = 100, ReleaseDate = new DateTime(2015, 1, 6) };
            db.Items.Add(song);

            for (int i = 0; i < 50; i++)
            {
                song = new Item { ItemName = RandomString(r.Next(2, 5)), Category = rockCategory, Artist = xi, TrackId = 1, Introduction = RandomString(r.Next(100, 200)), HasEntity = true, Price = r.Next(50, 100), ReleaseDate = new DateTime(r.Next(1990, 2016), r.Next(1, 12), r.Next(1, 28)) };
                db.Items.Add(song);
            }
            db.SaveChanges();
            BankDataInitializer.Initialize(db);
        }

        static Random r = new Random();

        public static string RandomString(int length)
        {
            StringBuilder sb = new StringBuilder();
            string[] peer = new string[]{" Po","esuo", " Tu", "est", "u", " Gu", "zu", " Wi"," Ab","s"};
            for (int i = 0; i < length; i++)
            {
                sb.Append(peer[r.Next(peer.Length)]);
            }
            return sb.ToString();
        }

        protected override void Seed(MKContext context)
        {
            DoSeed(context);
        }
    }
}