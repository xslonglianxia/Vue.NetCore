using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_statistics")]
    [Entity(ApiInput = typeof(ApiMktStatisticInput), ApiOutput = typeof(ApiMktStatisticOutput))]
    public class MktStatistic : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "Date")]
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [Display(Name = "RechargeAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RechargeAmount { get; set; }

        [Display(Name = "WithdrawalAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal WithdrawalAmount { get; set; }

        [Display(Name = "CommissionAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CommissionAmount { get; set; }

        [Display(Name = "MemberNumber")]
        [Column(TypeName = "int")]
        public int MemberNumber { get; set; }

        [Display(Name = "OrderNumber")]
        [Column(TypeName = "int")]
        public int OrderNumber { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
