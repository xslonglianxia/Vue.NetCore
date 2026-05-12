using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_order_details")]
    [Entity(ApiInput = typeof(ApiMktOrderDetailInput), ApiOutput = typeof(ApiMktOrderDetailOutput))]
    public class MktOrderDetail : BaseEntity
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

        [Display(Name = "ProductName")]
        [Column(TypeName = "nvarchar(500)")]
        public string ProductName { get; set; }

        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "CommissionRate")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CommissionRate { get; set; }

        [Display(Name = "CommissionAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CommissionAmount { get; set; }

        [Display(Name = "ParentCommissionAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ParentCommissionAmount { get; set; }

        [Display(Name = "Status")]
        [Column(TypeName = "int")]
        public int Status { get; set; }

        [Display(Name = "Type")]
        [Column(TypeName = "int")]
        public int Type { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
