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
    [Entity(TableCnName = "交易流水", TableName = "DC_MktTradingFlow", DBServer = "VOLContext")]
    public partial class DC_MktTradingFlow : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "流水号")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string FlowNo { get; set; }

        [Display(Name = "交易号")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string TradingNo { get; set; }

        [Display(Name = "交易类型")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int TradingKind { get; set; }

        [Display(Name = "会员用户名")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string MemberUsername { get; set; }

        [Display(Name = "金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal Amount { get; set; }

        [Display(Name = "交易前余额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal BeforeBalance { get; set; }

        [Display(Name = "交易后余额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal AfterBalance { get; set; }

        [Display(Name = "是否隐藏")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool Hidden { get; set; }

        [Display(Name = "备注")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Remark { get; set; }

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
