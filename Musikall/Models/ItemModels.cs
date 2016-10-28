using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace Musikall.Models
{
    /// <summary>
    /// 一组对音乐风格的分类
    /// </summary>
//     public enum MusicStyle
//     {
//         Pop, Rock, Electronic, Classical, Others
//     }

    /// <summary>
    /// 艺术家
    /// </summary>
    [Table("Artist")]
    public class Artist
    {
        public Artist()
        {
            Items = new List<Item>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Artist")]
        public string ArtistName { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "About")]
        public string About { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// 画像Url
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public string ImageUrl
        {
            get
            {
                foreach (var item in FileTypeConfig.ImageType)
                {
                    string path = string.Format("~/Images/Cover/{0}{1}", Id, item);
                    if (File.Exists(HttpContext.Current.Server.MapPath(path)))
                    {
                        return path;
                    }
                }
                return MKContextHelper.NoData;
            }
        }

        /// <summary>
        /// 是否拥有专辑
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public bool HasAlbum { get { return Items.Any(i => i.IsAlbum); } }

        /// <summary>
        /// 是否拥有单曲
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public bool HasSingle { get { return Items.Any(i => i.IsSingle); } }

        /// <summary>
        ///关联单曲（一对多）
        /// </summary>
        public virtual ICollection<Item> Items { get; set; }
    }

    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Style")]
        public string CategoryName { get; set; }

        /// <summary>
        ///关联单曲或者专辑（一对多）
        /// </summary>
        public virtual ICollection<Item> Items { get; set; }
    }


    [Table("Item")]
    public class Item
    {
        public Item()
        {
            AddedDate = DateTime.Now;
            SongList = new List<Item>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ItemName { get; set; }

        [Range(0, float.MaxValue)]
        [Display(Name = "Price")]
        public float Price { get; set; }

        [Range(0, float.MaxValue)]
        [Display(Name = "Digital Price")]
        public float DigitalPrice { get; set; }

        [Range(1,int.MaxValue)]
        public int? TrackId { get; set; }

        public bool HasDigital { get; set; }

        public bool HasEntity { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Introduction")]
        public string Introduction { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }

        /// <summary>
        /// 封面Url
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public string ImageUrl
        {
            get
            {
                if (!IsAlbum)
                {
                    return MKContextHelper.NoData;
                }
                foreach (var item in FileTypeConfig.ImageType)
                {
                    string path = string.Format("~/Images/Cover/{0}{1}", Id, item);
                    if (File.Exists(HttpContext.Current.Server.MapPath(path)))
                    {
                        return path;
                    }
                }
                return MKContextHelper.NoData;
            }
        }

        /// <summary>
        /// 试听Url
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public string AuditionUrl
        {
            get
            {
                if (IsAlbum)
                {
                    return MKContextHelper.NoData;
                }
                foreach (var item in FileTypeConfig.AudioType)
                {
                    string path = string.Format("~/Audio/Audition/{0}{1}", Id, item);
                    if (File.Exists(HttpContext.Current.Server.MapPath(path)))
                    {
                        return path;
                    }
                }
                return MKContextHelper.NoData;
            }
        }

        /// <summary>
        /// 试听Url
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public string DLUrl
        {
            get
            {
                if (IsAlbum)
                {
                    return MKContextHelper.NoData;
                }
                foreach (var item in FileTypeConfig.AudioType)
                {
                    string path = string.Format("~/Audio/Download/{0}{1}", Id, item);
                    if (File.Exists(HttpContext.Current.Server.MapPath(path)))
                    {
                        return path;
                    }
                }
                return MKContextHelper.NoData;
            }
        }

        /// <summary>
        /// 关联专辑（一对多自反）
        /// </summary>
        public virtual Item Album { get; set; }
        public int? AlbumId { get; set; }

        /// <summary>
        /// 是否专辑
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public bool IsAlbum { get { return AlbumId == null; } }

        /// <summary>
        /// 是否单行曲专辑
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public bool IsSingleAlbum { get { return IsAlbum && SongList.Count == 0; } }

        /// <summary>
        /// 是否单曲
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public bool IsSingle { get { return !IsAlbum || IsSingleAlbum; } }

        /// <summary>
        /// 关联专辑所有曲目（一对多自反）
        /// </summary>
        public virtual ICollection<Item> SongList { get; set; }

        /// <summary>
        /// 关联艺术家（一对多）
        /// </summary>
        public virtual Artist Artist { get; set; }
        public int ArtistId { get; set; }

        /// <summary>
        /// 关联分类即音乐风格
        /// </summary>
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        /// <summary>
        /// 关联浏览量
        /// </summary>
        public virtual PageView PageView { get; set; }

        /// <summary>
        /// 关联评论（一对多）
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// 关联历史记录（一对多）
        /// </summary>
        public virtual ICollection<ItemRecord> ItemRecords { get; set; }
    }


    [Table("ItemRecord")]
    public class ItemRecord
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 关联商品（一对多）
        /// </summary>
        public virtual Item Item { get; set; }
        public virtual int ItemId { get; set; }

        public bool IsDigital { get; set; }

        [Range(0.01, float.MaxValue)]
        [Display(Name = "History Price")]
        public float HistoryPrice { get; set; }
    }


    [Table("ItemSet")]
    public class ItemSet
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Count")]
        public int Count { get; set; }

        [Display(Name = "Total Price")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public float TotalPrice { get { return Price * Count; } }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public float Price { get { return IsDigital ? Item.DigitalPrice : Item.Price; } }

        public bool IsDigital { get; set; }

        /// <summary>
        /// 关联商品（一对多）
        /// </summary>
        public virtual Item Item { get; set; }
        public virtual int ItemId { get; set; }
    }


    [Table("ItemRecordSet")]
    public class ItemRecordSet
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Count")]
        public int Count { get; set; }

        [Display(Name = "Total Price")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public float TotalPrice { get { return ItemRecord.HistoryPrice * Count; } }

        /// <summary>
        /// 关联商品历史（一对多）
        /// </summary>
        public virtual ItemRecord ItemRecord { get; set; }
        public virtual int ItemRecordId { get; set; }
    }
}