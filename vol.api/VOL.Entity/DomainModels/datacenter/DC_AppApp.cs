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
    [Entity(TableCnName = "应用管理", TableName = "DC_AppApp", DBServer = "VOLContext")]
    public partial class DC_AppApp : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "应用名称")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "应用编码")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Code { get; set; }

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
