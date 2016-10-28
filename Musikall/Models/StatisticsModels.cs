using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musikall.Models
{
    [Table("PageView")]
    public class PageView
    {
        [Key]
        [ForeignKey("Item")]
        public int Id { get; set; }

        /// <summary>
        /// 关联商品（一对一）
        /// </summary>
        public virtual Item Item { get; set; }


        [Range(0, int.MaxValue)]
        [Display(Name = "Page View")]
        public int VisitCount { get; set; }
    }

    public class ReportModel
    {
        /// <summary>
        /// 时间段
        /// </summary>
        public TimeSpan TimeSpan { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 销售额
        /// </summary>
        [Display(Name = "Total Sales")]
        public float Sales { get; set; }
        /// <summary>
        /// 销售数量
        /// </summary>
        [Display(Name = "Sales Amount")]
        public int Count { get; set; }
        /// <summary>
        /// 数字商品销售额
        /// </summary>
        [Display(Name = "Sales(Digital)")]
        public float DigitalSales { get; set; }

        /// <summary>
        /// 数字商品销售数量
        /// </summary>
        [Display(Name = "Sales Amount(Digital)")]
        public int DigitalCount { get; set; }
        /// <summary>
        /// 产生订单数量
        /// </summary>
        [Display(Name = "Order Quantity")]
        public int OrderCount { get; set; }
        /// <summary>
        /// 支付过的用户数量
        /// </summary>
        [Display(Name = "Pay User Count")]
        public int UserCount { get; set; }
        /// <summary>
        /// 平均每个订单消费
        /// </summary>
        [Display(Name = "Per-purchase Spending ")]
        public float AvgCost { get { return OrderCount == 0 ? 0 : Sales / OrderCount; } }

        /// <summary>
        /// 平均每个用户消费
        /// </summary>
        [Display(Name = "Per Capita Consumption")]
        public float UserAvgCost { get { return UserCount == 0 ? 0 : Sales / UserCount; } }
        /// <summary>
        /// 总浏览量
        /// </summary>
        [Display(Name = "Total PV")]
        public int TotalPV { get; set; }
        /// <summary>
        /// 上架新专辑数量
        /// </summary>
        [Display(Name = "New Album")]
        public int NewAlbum { get; set; }
    }

    public class TroubleData
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public static TroubleData Create(Item item, string trouble)
        {
            return new TroubleData() { IId = item.Id, ControllerName = "item", Name = item.ItemName, Trouble = trouble };
        }

        public static TroubleData Create(Artist artist, string trouble)
        {
            return new TroubleData() { IId = artist.Id, ControllerName = "artist", Name = artist.ArtistName, Trouble = trouble };
        }
        public int IId { get; set; }

        public string Name { get; set; }

        public string ControllerName { get; set; }

        public string Trouble { get; set; }
    }
}