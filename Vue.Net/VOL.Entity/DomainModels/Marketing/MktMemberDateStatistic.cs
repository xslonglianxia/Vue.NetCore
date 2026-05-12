using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_member_date_statistics")]
    [Entity(ApiInput = typeof(ApiMktMemberDateStatisticInput), ApiOutput = typeof(ApiMktMemberDateStatisticOutput))]
    public class MktMemberDateStatistic : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "Date")]
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [Display(Name = "MemberNumber")]
        [Column(TypeName = "int")]
        public int MemberNumber { get; set; }

        [Display(Name = "RechargeAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RechargeAmount { get; set; }

        [Display(Name = "RechargeNumber")]
        [Column(TypeName = "int")]
        public int RechargeNumber { get; set; }

        [Display(Name = "WithdrawalAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal WithdrawalAmount { get; set; }

        [Display(Name = "WithdrawalNumber")]
        [Column(TypeName = "int")]
        public int WithdrawalNumber { get; set; }

        [Display(Name = "CommissionAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CommissionAmount { get; set; }

        [Display(Name = "CommissionNumber")]
        [Column(TypeName = "int")]
        public int CommissionNumber { get; set; }

        [Display(Name = "ParentCommissionAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ParentCommissionAmount { get; set; }

        [Display(Name = "ParentCommissionNumber")]
        [Column(TypeName = "int")]
        public int ParentCommissionNumber { get; set; }

        [Display(Name = "GiveAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GiveAmount { get; set; }

        [Display(Name = "GiveNumber")]
        [Column(TypeName = "int")]
        public int GiveNumber { get; set; }

        [Display(Name = "SignAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SignAmount { get; set; }

        [Display(Name = "SignNumber")]
        [Column(TypeName = "int")]
        public int SignNumber { get; set; }

        [Display(Name = "OrderNumber")]
        [Column(TypeName = "int")]
        public int OrderNumber { get; set; }

        [Display(Name = "BetNumber")]
        [Column(TypeName = "int")]
        public int BetNumber { get; set; }

        [Display(Name = "TaskCompleteNumber")]
        [Column(TypeName = "int")]
        public int TaskCompleteNumber { get; set; }

        [Display(Name = "ResetNumber")]
        [Column(TypeName = "int")]
        public int ResetNumber { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
