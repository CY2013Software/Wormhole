using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Musikall.Models
{

    [Table("UserData")]
    public class UserData
    {
        public UserData()
        {
        }

        public UserData(MKContext db)
        {
            db.ShoppingCarts.Add(new ShoppingCart { UserData = this });
        }

        [Key]
        [ForeignKey("UserProfile")]
        public int Id { get; set; }

        /// <summary>
        ///关联用户信息（一对一）
        /// </summary>
        public virtual UserProfile UserProfile { get; set; }

        /// <summary>
        ///关联购物车（一对一）
        /// </summary>
        public virtual ShoppingCart ShoppingCart { get; set; }

        /// <summary>
        ///关联拥有的数字音乐（一对多）
        /// </summary>
        public virtual ICollection<OwnedDigitalItem> OwnedDigitalItems { get; set; }

        /// <summary>
        ///关联订单（一对多）
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    }

    public class OwnedDigitalItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        ///关联用户数据（一对多）
        /// </summary>
        public virtual UserData UserData { get; set; }

        /// <summary>
        /// 关联商品（一对多）
        /// </summary>
        public virtual Item Item { get; set; }
        public int ItemId { get; set; }
    }

    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        [Key]
        [ForeignKey("UserData")]
        public int Id { get; set; }

        [Display(Name = "Total Price")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public float TotalPrice { get { return ItemSets.Sum(r => r.TotalPrice); } }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public bool ContainsDigitalItem { get { return ItemSets.Any(set => set.IsDigital); } }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public bool ContainsEntityItem { get { return ItemSets.Any(set => !set.IsDigital); } }

        /// <summary>
        ///关联用户数据（一对一）
        /// </summary>
        public virtual UserData UserData { get; set; }

        /// <summary>
        ///关联商品组（一对多）
        /// </summary>
        public virtual ICollection<ItemSet> ItemSets { get; set; }
    }

    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Order Id")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public string OrderId { get { return string.Format("MSK{0}", Id.ToString("000000000")); } }

        [Display(Name = "Total Price")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public float TotalPrice { get { return ItemRecordSets.Sum(r => r.TotalPrice); } }

        [Display(Name = "Total Count")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public int TotalCount { get { return ItemRecordSets.Sum(r => r.Count); } }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public float TotalDigitalPrice { get { return ItemRecordSets.Where(r => r.ItemRecord.IsDigital).Sum(r => r.TotalPrice); } }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public int TotalDigitalCount { get { return ItemRecordSets.Where(r => r.ItemRecord.IsDigital).Sum(r => r.Count); } }

        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///关联用户信息（一对多）
        /// </summary>
        public virtual UserData UserData { get; set; }

        /// <summary>
        ///关联商品历史记录（一对多）
        /// </summary>
        public virtual ICollection<ItemRecordSet> ItemRecordSets { get; set; }
    }


    [Table("Comment")]
    public class Comment
    {
        public Comment()
        {
            CreateDate = DateTime.Now;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        ///关联商品
        /// </summary>
        public virtual Item Item { get; set; }

        /// <summary>
        ///关联用户
        /// </summary>
        public virtual UserProfile User { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}