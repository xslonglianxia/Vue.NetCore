using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Points
{
    [Table("pts_accounts")]
    [Entity(ApiInput = typeof(ApiPtsAccountInput), ApiOutput = typeof(ApiPtsAccountOutput))]
    public class PtsAccount : BaseEntity
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

        [Display(Name = "Balance")]
        [Column(TypeName = "int")]
        public int Balance { get; set; }

        [Display(Name = "TotalEarned")]
        [Column(TypeName = "int")]
        public int TotalEarned { get; set; }

        [Display(Name = "TotalSpent")]
        [Column(TypeName = "int")]
        public int TotalSpent { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "ModifyDate")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
    }
}
