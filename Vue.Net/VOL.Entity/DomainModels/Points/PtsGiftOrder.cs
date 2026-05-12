using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Points
{
    [Table("pts_gift_orders")]
    [Entity(ApiInput = typeof(ApiPtsGiftOrderInput), ApiOutput = typeof(ApiPtsGiftOrderOutput))]
    public class PtsGiftOrder : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "OrderNo")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string OrderNo { get; set; }

        [Display(Name = "MemberId")]
        [Column(TypeName = "bigint")]
        public long? MemberId { get; set; }

        [Display(Name = "Username")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Display(Name = "GiftId")]
        [Column(TypeName = "bigint")]
        public long? GiftId { get; set; }

        [Display(Name = "GiftName")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string GiftName { get; set; }

        [Display(Name = "GiftImage")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string GiftImage { get; set; }

        [Display(Name = "Points")]
        [Column(TypeName = "int")]
        public int Points { get; set; }

        [Display(Name = "Quantity")]
        [Column(TypeName = "int")]
        public int Quantity { get; set; }

        [Display(Name = "TotalPoints")]
        [Column(TypeName = "int")]
        public int TotalPoints { get; set; }

        [Display(Name = "Status")]
        [Column(TypeName = "int")]
        public int Status { get; set; }

        [Display(Name = "ShippingName")]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string ShippingName { get; set; }

        [Display(Name = "ShippingPhone")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string ShippingPhone { get; set; }

        [Display(Name = "ShippingAddress")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string ShippingAddress { get; set; }

        [Display(Name = "Remark")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Remark { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
