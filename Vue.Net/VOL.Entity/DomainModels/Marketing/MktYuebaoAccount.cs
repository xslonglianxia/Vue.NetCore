using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_yuebao_accounts")]
    [Entity(ApiInput = typeof(ApiMktYuebaoAccountInput), ApiOutput = typeof(ApiMktYuebaoAccountOutput))]
    public class MktYuebaoAccount : BaseEntity
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

        [Display(Name = "Balance")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [Display(Name = "YesterdayProfit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal YesterdayProfit { get; set; }

        [Display(Name = "TotalProfit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalProfit { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "ModifyDate")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
    }
}
