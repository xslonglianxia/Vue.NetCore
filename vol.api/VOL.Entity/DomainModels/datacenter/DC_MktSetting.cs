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
    [Entity(TableCnName = "系统设置", TableName = "DC_MktSetting", DBServer = "VOLContext")]
    public partial class DC_MktSetting : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "编码")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Code { get; set; }

        [Display(Name = "类型")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Kind { get; set; }

        [Display(Name = "值")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Value { get; set; }

        [Display(Name = "等级序号")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int LevelSeq { get; set; }

        [Display(Name = "金额")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal Amount { get; set; }

        [Display(Name = "奖金")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal Bonus { get; set; }

        [Display(Name = "排序")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Seq { get; set; }

        [Display(Name = "链接")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Url { get; set; }

        [Display(Name = "消息")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Message { get; set; }

        [Display(Name = "间隔")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Interval { get; set; }

        [Display(Name = "限制")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Limit { get; set; }

        [Display(Name = "日利率")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal DailyInterestRate { get; set; }

        [Display(Name = "订单数量")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int OrderNumber { get; set; }

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
