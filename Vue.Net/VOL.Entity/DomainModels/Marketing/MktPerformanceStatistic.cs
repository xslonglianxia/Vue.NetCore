using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_performance_statistics")]
    [Entity(ApiInput = typeof(ApiMktPerformanceStatisticInput), ApiOutput = typeof(ApiMktPerformanceStatisticOutput))]
    public class MktPerformanceStatistic : BaseEntity
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
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Display(Name = "Nickname")]
        [Column(TypeName = "nvarchar(100)")]
        public string Nickname { get; set; }

        [Display(Name = "LevelName")]
        [Column(TypeName = "nvarchar(100)")]
        public string LevelName { get; set; }

        [Display(Name = "ParentUsername")]
        [Column(TypeName = "nvarchar(100)")]
        public string ParentUsername { get; set; }

        [Display(Name = "RechargeAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RechargeAmount { get; set; }

        [Display(Name = "WithdrawalAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal WithdrawalAmount { get; set; }

        [Display(Name = "CommissionAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CommissionAmount { get; set; }

        [Display(Name = "ParentCommissionAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ParentCommissionAmount { get; set; }

        [Display(Name = "FirstRechargeDate")]
        [Column(TypeName = "datetime")]
        public DateTime? FirstRechargeDate { get; set; }

        [Display(Name = "LastRechargeDate")]
        [Column(TypeName = "datetime")]
        public DateTime? LastRechargeDate { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
