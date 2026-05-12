using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Websites
{
    [Table("web_customers")]
    [Entity(ApiInput = typeof(ApiWebCustomerInput), ApiOutput = typeof(ApiWebCustomerOutput))]
    public class WebCustomer : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Display(Name = "Domain")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Domain { get; set; }

        [Display(Name = "Logo")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Logo { get; set; }

        [Display(Name = "ContactName")]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string ContactName { get; set; }

        [Display(Name = "ContactPhone")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string ContactPhone { get; set; }

        [Display(Name = "ContactEmail")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string ContactEmail { get; set; }

        [Display(Name = "Status")]
        [Column(TypeName = "int")]
        public int Status { get; set; }

        [Display(Name = "CreateID")]
        [Column(TypeName = "int")]
        public int? CreateID { get; set; }

        [Display(Name = "Creator")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Creator { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "ModifyID")]
        [Column(TypeName = "int")]
        public int? ModifyID { get; set; }

        [Display(Name = "Modifier")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Modifier { get; set; }

        [Display(Name = "ModifyDate")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
    }
}
