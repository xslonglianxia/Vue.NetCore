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
    [Entity(TableCnName = "业绩统计", TableName = "DC_MktPerformanceStatistic", DBServer = "VOLContext")]
    public partial class DC_MktPerformanceStatistic : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "日期")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? Date { get; set; }

        [Display(Name = "权限用户名")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string PermissionUsername { get; set; }

        [Display(Name = "会员数量")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int MemberNumber { get; set; }

        [Display(Name = "充值金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal RechargeAmount { get; set; }

        [Display(Name = "提现金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal WithdrawalAmount { get; set; }

        [Display(Name = "佣金金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal CommissionAmount { get; set; }

        [Display(Name = "上级佣金金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal ParentCommissionAmount { get; set; }

        [Display(Name = "赠送金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal GiveAmount { get; set; }

        [Display(Name = "签到金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal SignAmount { get; set; }

        [Display(Name = "订单数量")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int OrderNumber { get; set; }

        [Display(Name = "投注数量")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int BetNumber { get; set; }

        [Display(Name = "任务完成数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int TaskCompleteNumber { get; set; }

        [Display(Name = "重置次数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int ResetNumber { get; set; }

        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? CreateDate { get; set; }
    }
}
