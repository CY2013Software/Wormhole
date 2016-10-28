using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Security;
using Musikall.Resources;

namespace Musikall.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        public UserProfile()
        {
        }

        public UserProfile(MKContext db)
        {
            db.UserDataSet.Add(new UserData(db) { UserProfile = this });
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// 头像Url
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public string AvatarUrl
        {
            get
            {
                string pngPath = string.Format("~/Images/Avatar/{0}.png", Id);
                if (File.Exists(HttpContext.Current.Server.MapPath(pngPath)))
                {
                    return pngPath;
                }
                string jpgPath = string.Format("~/Images/Avatar/{0}.jpg", Id);
                if (File.Exists(HttpContext.Current.Server.MapPath(jpgPath)))
                {
                    return jpgPath;
                }
                return MKContextHelper.NoData;
            }
        }

        /// <summary>
        /// 默认使用的银行卡
        /// </summary>
        public CardDetails DefaultCard
        {
            get { return CardDetailsSet.Where(s => s.Id == DefaultCardId).FirstOrDefault(); }
        }
        /// <summary>
        /// 建议不要直接修改
        /// </summary>
        public int? DefaultCardId { get; set; }

        /// <summary>
        /// 是否关联用户默认的绑定的银行卡
        /// </summary>
        public bool IsDefaultCard(CardDetails card) { return DefaultCardId == card.Id; }

        /// <summary>
        ///关联绑定的银行卡（一对多）
        /// </summary>
        public virtual ICollection<CardDetails> CardDetailsSet { get; set; }

        /// <summary>
        /// 默认使用的地址薄
        /// </summary>
        public AddressBook DefaultAddress 
        { 
            get { return AddressBooks.Where(s => s.Id == DefaultAddressId).FirstOrDefault(); }
        }
        /// <summary>
        /// 建议不要直接修改
        /// </summary>
        public int? DefaultAddressId { get; set; }

        /// <summary>
        /// 是否关联用户默认的地址薄
        /// </summary>
        public bool IsDefaultAddress(AddressBook address) { return DefaultAddressId == address.Id; }

        /// <summary>
        ///关联地址薄（一对多）
        /// </summary>
        public virtual ICollection<AddressBook> AddressBooks { get; set; }

        //关联用户数据（一对一）
        public virtual UserData UserData { get; set; }
    }

    [Table("CardDetails")]
    public class CardDetails
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        [Required]
        [RegularExpression("^[0-9]{16,19}$")]
        public string CardId { get; set; }

        /// <summary>
        /// 显示卡号
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public string DisplayCardId { get { return CardId.Remove(4, CardId.Length - 8).Insert(4, new string('*', CardId.Length - 8)) ; } }

        /// <summary>
        /// 身份证Id
        /// </summary>
        [Required]
        [StringLength(18, MinimumLength=18)]
        public string IdentityId { get; set; }

        /// <summary>
        /// 持卡人
        /// </summary>
        [Required]
        public string CardName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public string BankName
        {
            get
            {
                using (var db = new MKContext())
                {
                    var bank = db.Banks.FirstOrDefault(b => CardId.StartsWith(b.Head));
                    if (bank == null)
                        return Strings.Others;
                    else
                        return bank.Name;
                }
            }
        }

        /// <summary>
        ///关联用户信息（一对多）
        /// </summary>
        public virtual UserProfile UserProfile { get; set; }
        public int UserProfileId { get; set; }
    }

    [Table("Bank")]
    public class Bank
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 银行卡前六位
        /// </summary>
        [Required]
        [RegularExpression("[0-9]{6}")]
        public string Head { get; set; }

        /// <summary>
        /// 银行名字
        /// </summary>
        [Required]
        public string Name { get; set; }
    }

    public class UserEditModel
    {
        public UserProfile User { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Account")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email format error")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} must contain at least {2} chars", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

//         [DataType(DataType.Password)]
//         [Display(Name = "Password confirm")]
//         [Compare("Password", ErrorMessage = "Passwords're not matched")]
//         public string ConfirmPassword { get; set; }

        public void AddUserProfile(MKContext db)
        {
            db.UserProfiles.Add(new UserProfile(db) { Email = Email, UserName = UserName });
        }
    }
}
