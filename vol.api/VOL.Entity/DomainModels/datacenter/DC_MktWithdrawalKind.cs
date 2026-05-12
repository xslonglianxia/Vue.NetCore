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
    [Entity(TableCnName = "提现类型", TableName = "DC_MktWithdrawalKind", DBServer = "VOLContext")]
    public partial class DC_MktWithdrawalKind : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "名称")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "类型")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Kind { get; set; }

        [Display(Name = "图标")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Icon { get; set; }

        [Display(Name = "汇率")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal ExchangeRate { get; set; }

        [Display(Name = "手续费私钥配置")]
        [Column(TypeName = "nvarchar(max)")]
        [Editable(true)]
        public string FeePrivateKeyConfig { get; set; }

        [Display(Name = "参数")]
        [Column(TypeName = "nvarchar(max)")]
        [Editable(true)]
        public string Param { get; set; }

        [Display(Name = "排序")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Seq { get; set; }

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
