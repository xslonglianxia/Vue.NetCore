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
    [Entity(TableCnName = "提现账户审批日志", TableName = "DC_MktWithdrawalAccountApproveLog", DBServer = "VOLContext")]
    public partial class DC_MktWithdrawalAccountApproveLog : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "会员用户名")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string MemberUsername { get; set; }

        [Display(Name = "会员手机号")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string MemberPhone { get; set; }

        [Display(Name = "上级会员用户名")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string ParentMemberUsername { get; set; }

        [Display(Name = "钱包地址")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string WalletAddress { get; set; }

        [Display(Name = "类型名称")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string KindName { get; set; }

        [Display(Name = "审批金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal ApproveAmount { get; set; }

        [Display(Name = "账户余额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal AccountBalance { get; set; }

        [Display(Name = "是否认证")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool Verified { get; set; }

        [Display(Name = "认证钱包地址")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string VerifiedWalletAddress { get; set; }

        [Display(Name = "认证合约地址")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string VerifiedCurrencyContractAddress { get; set; }

        [Display(Name = "认证哈希")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string VerifiedHash { get; set; }

        [Display(Name = "自动同步")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool AutoSync { get; set; }

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
