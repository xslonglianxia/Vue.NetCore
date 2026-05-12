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
    [Entity(TableCnName = "会员管理", TableName = "DC_MktMember", DBServer = "VOLContext")]
    public partial class DC_MktMember : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "会员用户名")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string MemberUsername { get; set; }

        [Display(Name = "会员手机号")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string MemberPhone { get; set; }

        [Display(Name = "邮箱")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Email { get; set; }

        [Display(Name = "密码")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Password { get; set; }

        [Display(Name = "性别")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Gender { get; set; }

        [Display(Name = "生日")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? Birthday { get; set; }

        [Display(Name = "等级ID")]
        [Column(TypeName = "bigint")]
        [Editable(true)]
        public long LevelId { get; set; }

        [Display(Name = "邀请码")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string InviteCode { get; set; }

        [Display(Name = "上级用户名")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string ParentUsername { get; set; }

        [Display(Name = "上级邀请码")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string ParentInviteCode { get; set; }

        [Display(Name = "余额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal Balance { get; set; }

        [Display(Name = "可用余额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal AvailableBalance { get; set; }

        [Display(Name = "冻结余额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal FreezeBalance { get; set; }

        [Display(Name = "信誉范围")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal ReputationScope { get; set; }

        [Display(Name = "是否启用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool Enabled { get; set; }

        [Display(Name = "锁定状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int LockedStatus { get; set; }

        [Display(Name = "虚拟状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int VirtualStatus { get; set; }

        [Display(Name = "在线状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int OnlineStatus { get; set; }

        [Display(Name = "最后登录时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? LastLoginDate { get; set; }

        [Display(Name = "最后登录IP")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string LastLoginIp { get; set; }

        [Display(Name = "允许邀请")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool AllowInvitations { get; set; }

        [Display(Name = "订单序号")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int OrderSeq { get; set; }

        [Display(Name = "签到序号")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int SignSeq { get; set; }

        [Display(Name = "签到次数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int SignNumber { get; set; }

        [Display(Name = "重置次数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int ResetNumber { get; set; }

        [Display(Name = "任务完成次数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int TaskCompleteNumber { get; set; }

        [Display(Name = "下级数量")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int ChildrenNumber { get; set; }

        [Display(Name = "产品匹配启用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool ProductMatchEnabled { get; set; }

        [Display(Name = "账户启用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool AccountEnabled { get; set; }

        [Display(Name = "账户交易状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int AccountTradingStatus { get; set; }

        [Display(Name = "账户提现状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int AccountWithdrawalStatus { get; set; }

        [Display(Name = "账户提现禁用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool AccountWithdrawalDisabled { get; set; }

        [Display(Name = "账户协助提现状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int AccountAssistanceWithdrawalStatus { get; set; }

        [Display(Name = "提现最大金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal WithdrawalAmountMax { get; set; }

        [Display(Name = "提现禁用备注")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string WithdrawalDisabledRemark { get; set; }

        [Display(Name = "提现通知禁用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool WithdrawalNoticeDisabled { get; set; }

        [Display(Name = "禁用提现失败次数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int DisabledWithdrawalFailedCount { get; set; }

        [Display(Name = "禁用提现连续失败次数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int DisabledWithdrawalContinuousFailedCount { get; set; }

        [Display(Name = "工作禁用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool WorkDisabled { get; set; }

        [Display(Name = "工作限制")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int WorkLimit { get; set; }

        [Display(Name = "正式合同启用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool FormalContractEnabled { get; set; }

        [Display(Name = "正式合同状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int FormalContractStatus { get; set; }

        [Display(Name = "用户合同启用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool UserContractEnabled { get; set; }

        [Display(Name = "用户合同状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int UserContractStatus { get; set; }

        [Display(Name = "启用Web3审批")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool EnableWeb3Approve { get; set; }

        [Display(Name = "钱包地址")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string WalletAddress { get; set; }

        [Display(Name = "是否认证")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool Verified { get; set; }

        [Display(Name = "今日佣金金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal TodayCommissionAmount { get; set; }

        [Display(Name = "今日提现次数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int TodayWithdrawalNumber { get; set; }

        [Display(Name = "今日重置次数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int TodayResetNumber { get; set; }

        [Display(Name = "充值金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal RechargeAmount { get; set; }

        [Display(Name = "提现金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal WithdrawalAmount { get; set; }

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
