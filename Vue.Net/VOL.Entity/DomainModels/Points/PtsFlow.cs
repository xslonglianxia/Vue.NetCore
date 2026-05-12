using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Points
{
    [Table("pts_flows")]
    [Entity(ApiInput = typeof(ApiPtsFlowInput), ApiOutput = typeof(ApiPtsFlowOutput))]
    public class PtsFlow : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "MemberId")]
        [Column(TypeName = "bigint")]
        public long? MemberId { get; set; }

        [Display(Name = "Username")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Display(Name = "Type")]
        [Column(TypeName = "int")]
        public int Type { get; set; }

        [Display(Name = "Points")]
        [Column(TypeName = "int")]
        public int Points { get; set; }

        [Display(Name = "BeforeBalance")]
        [Column(TypeName = "int")]
        public int BeforeBalance { get; set; }

        [Display(Name = "AfterBalance")]
        [Column(TypeName = "int")]
        public int AfterBalance { get; set; }

        [Display(Name = "OrderNo")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string OrderNo { get; set; }

        [Display(Name = "Remark")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Remark { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
