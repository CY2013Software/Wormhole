using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musikall.Models
{
    [Table("AddressBook")]
    public class AddressBook
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string FullName { get; set; }

        public string PostCode { get; set; }
        /// <summary>
        ///关联用户信息（一对多）
        /// </summary>
        public virtual UserProfile UserProfile { get; set; }
        public int UserProfileId { get; set; }
    }

    public class AddressBookEdit
    {
        public AddressBook AddressBook { get; set; }

        public City City { get; set; }
    }

    [Table("Country")]
    public class Country
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Province> Provinces { get; set; }
    }

    [Table("Province")]
    public class Province
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
    }

    [Table("City")]
    public class City
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual Province Province { get; set; }
        public int ProvinceId { get; set; }
    }
}