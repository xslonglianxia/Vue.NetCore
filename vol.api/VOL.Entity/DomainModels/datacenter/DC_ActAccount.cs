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
    [Entity(TableCnName = "活动账户", TableName = "DC_ActAccount", DBServer = "VOLContext")]
    public partial class DC_ActAccount : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "活动ID")]
        [Column(TypeName = "bigint")]
        [Editable(true)]
        public long ActivityId { get; set; }

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

        [Display(Name = "可用次数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int AvailableTimes { get; set; }

        [Display(Name = "已用次数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int UsedTimes { get; set; }

        [Display(Name = "是否中奖")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool Winning { get; set; }

        [Display(Name = "奖品类型")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int PrizeKind { get; set; }

        [Display(Name = "奖品标题")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string PrizeTitle { get; set; }

        [Display(Name = "奖品图片")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string PrizePic { get; set; }

        [Display(Name = "奖品价格")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal PrizePrice { get; set; }

        [Display(Name = "排序")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Seq { get; set; }

        [Display(Name = "是否认证")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool Verified { get; set; }

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
