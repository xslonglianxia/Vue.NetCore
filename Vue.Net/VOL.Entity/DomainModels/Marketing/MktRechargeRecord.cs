using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_recharge_records")]
    [Entity(ApiInput = typeof(ApiMktRechargeRecordInput), ApiOutput = typeof(ApiMktRechargeRecordOutput))]
    public class MktRechargeRecord : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "OrderNo")]
        [Column(TypeName = "nvarchar(100)")]
        public string OrderNo { get; set; }

        [Display(Name = "MemberId")]
        [Column(TypeName = "bigint")]
        public long? MemberId { get; set; }

        [Display(Name = "Username")]
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "GiveAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GiveAmount { get; set; }

        [Display(Name = "PaymentMethod")]
        [Column(TypeName = "int")]
        public int? PaymentMethod { get; set; }

        [Display(Name = "PaymentChannel")]
        [Column(TypeName = "nvarchar(100)")]
        public string PaymentChannel { get; set; }

        [Display(Name = "Status")]
        [Column(TypeName = "int")]
        public int Status { get; set; }

        [Display(Name = "AuditStatus")]
        [Column(TypeName = "int")]
        public int? AuditStatus { get; set; }

        [Display(Name = "AuditUserId")]
        [Column(TypeName = "int")]
        public int? AuditUserId { get; set; }

        [Display(Name = "AuditUserName")]
        [Column(TypeName = "nvarchar(200)")]
        public string AuditUserName { get; set; }

        [Display(Name = "AuditTime")]
        [Column(TypeName = "datetime")]
        public DateTime? AuditTime { get; set; }

        [Display(Name = "Visible")]
        [Column(TypeName = "tinyint")]
        public byte Visible { get; set; }

        [Display(Name = "Remark")]
        [Column(TypeName = "nvarchar(500)")]
        public string Remark { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
