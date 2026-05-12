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
    [Entity(TableCnName = "会员登录日志", TableName = "DC_MktMemberLoginLog", DBServer = "VOLContext")]
    public partial class DC_MktMemberLoginLog : BaseEntity
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

        [Display(Name = "请求参数")]
        [Column(TypeName = "nvarchar(max)")]
        [Editable(true)]
        public string Param { get; set; }

        [Display(Name = "请求头")]
        [Column(TypeName = "nvarchar(max)")]
        [Editable(true)]
        public string Headers { get; set; }

        [Display(Name = "IP地址")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Ip { get; set; }

        [Display(Name = "归属地")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Address { get; set; }

        [Display(Name = "是否成功")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool Success { get; set; }

        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? CreateDate { get; set; }
    }
}
