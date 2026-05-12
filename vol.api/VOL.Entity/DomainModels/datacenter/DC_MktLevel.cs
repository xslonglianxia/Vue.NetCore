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
    [Entity(TableCnName = "会员等级", TableName = "DC_MktLevel", DBServer = "VOLContext")]
    public partial class DC_MktLevel : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "等级名称")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "图标")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Icon { get; set; }

        [Display(Name = "排序")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Seq { get; set; }

        [Display(Name = "价格")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal Price { get; set; }

        [Display(Name = "最低余额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal BalanceMin { get; set; }

        [Display(Name = "订单限制")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int OrderLimit { get; set; }

        [Display(Name = "完成限制")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int CompleteLimit { get; set; }

        [Display(Name = "提现限制")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int WithdrawalLimit { get; set; }

        [Display(Name = "提现订单序号限制")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int WithdrawalOrderSeqLimit { get; set; }

        [Display(Name = "提现最低金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal WithdrawalAmountMin { get; set; }

        [Display(Name = "提现最高金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal WithdrawalAmountMax { get; set; }

        [Display(Name = "提现手续费率")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal WithdrawalFeeRate { get; set; }

        [Display(Name = "最低佣金比例")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal MinCommissionPercentage { get; set; }

        [Display(Name = "最高佣金比例")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal MaxCommissionPercentage { get; set; }

        [Display(Name = "最低均分佣金比例")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal MinEvenCommissionPercentage { get; set; }

        [Display(Name = "最高均分佣金比例")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal MaxEvenCommissionPercentage { get; set; }

        [Display(Name = "最低邀请数量")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int InviteQuantityMin { get; set; }

        [Display(Name = "签到奖励")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal SignInBonus { get; set; }

        [Display(Name = "任务组奖励")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal TaskGroupsBonus { get; set; }

        [Display(Name = "完成任务组数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int NumberOfCompletedTaskGroups { get; set; }

        [Display(Name = "产品匹配启用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool ProductMatchEnabled { get; set; }

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
