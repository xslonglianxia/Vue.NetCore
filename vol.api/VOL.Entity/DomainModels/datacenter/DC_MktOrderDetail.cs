using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels
{
    [Entity(TableCnName = "订单明细", TableName = "DC_MktOrderDetail", DBServer = "VOLContext")]
    public partial class DC_MktOrderDetail : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "明细编号")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string DetailNo { get; set; }

        [Display(Name = "会员用户名")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string MemberUsername { get; set; }

        [Display(Name = "类型")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Kind { get; set; }

        [Display(Name = "商品ID")]
        [Column(TypeName = "bigint")]
        [Editable(true)]
        public long SpuId { get; set; }

        [Display(Name = "商品标题")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string SpuTitle { get; set; }

        [Display(Name = "商品图片")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string SpuPic { get; set; }

        [Display(Name = "排序")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Seq { get; set; }

        [Display(Name = "金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal Amount { get; set; }

        [Display(Name = "佣金比例")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal CommissionPercentage { get; set; }

        [Display(Name = "佣金")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal Commission { get; set; }

        [Display(Name = "上级佣金比例")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal ParentCommissionPercentage { get; set; }

        [Display(Name = "上级佣金")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal ParentCommission { get; set; }

        [Display(Name = "额外佣金")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal AdditionalCommission { get; set; }

        [Display(Name = "状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Status { get; set; }

        [Display(Name = "过期时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? ExpiredDate { get; set; }

        [Display(Name = "备注")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Remark { get; set; }

        [Display(Name = "版本号")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Version { get; set; }

        [Display(Name = "创建人ID")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? CreateID { get; set; }

        [Display(Name = "创建人")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Creator { get; set; }

        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "修改人ID")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? ModifyID { get; set; }

        [Display(Name = "修改人")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Modifier { get; set; }

        [Display(Name = "修改时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? ModifyDate { get; set; }
    }
}
