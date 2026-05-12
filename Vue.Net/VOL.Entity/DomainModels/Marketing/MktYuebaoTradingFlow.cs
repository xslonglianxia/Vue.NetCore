using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_yuebao_trading_flows")]
    [Entity(ApiInput = typeof(ApiMktYuebaoTradingFlowInput), ApiOutput = typeof(ApiMktYuebaoTradingFlowOutput))]
    public class MktYuebaoTradingFlow : BaseEntity
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

        [Display(Name = "Type")]
        [Column(TypeName = "int")]
        public int Type { get; set; }

        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "BeforeBalance")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BeforeBalance { get; set; }

        [Display(Name = "AfterBalance")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AfterBalance { get; set; }

        [Display(Name = "Profit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Profit { get; set; }

        [Display(Name = "Remark")]
        [Column(TypeName = "nvarchar(500)")]
        public string Remark { get; set; }

        [Display(Name = "Visible")]
        [Column(TypeName = "tinyint")]
        public byte Visible { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
