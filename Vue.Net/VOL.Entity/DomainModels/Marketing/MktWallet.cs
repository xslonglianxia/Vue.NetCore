using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_wallets")]
    [Entity(ApiInput = typeof(ApiMktWalletInput), ApiOutput = typeof(ApiMktWalletOutput))]
    public class MktWallet : BaseEntity
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

        [Display(Name = "FrozenBalance")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FrozenBalance { get; set; }

        [Display(Name = "CommissionBalance")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CommissionBalance { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "ModifyDate")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
    }
}
