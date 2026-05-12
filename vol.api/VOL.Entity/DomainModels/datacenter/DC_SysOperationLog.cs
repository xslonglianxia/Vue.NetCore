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
    [Entity(TableCnName = "操作日志", TableName = "DC_SysOperationLog", DBServer = "VOLContext")]
    public partial class DC_SysOperationLog : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "用户名")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Username { get; set; }

        [Display(Name = "资源编码")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string ResourceCode { get; set; }

        [Display(Name = "请求方法")]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Editable(true)]
        public string Method { get; set; }

        [Display(Name = "请求地址")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Url { get; set; }

        [Display(Name = "请求参数")]
        [Column(TypeName = "nvarchar(max)")]
        [Editable(true)]
        public string Parameter { get; set; }

        [Display(Name = "查询参数")]
        [Column(TypeName = "nvarchar(max)")]
        [Editable(true)]
        public string Query { get; set; }

        [Display(Name = "请求体")]
        [Column(TypeName = "nvarchar(max)")]
        [Editable(true)]
        public string Body { get; set; }

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

        [Display(Name = "状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Status { get; set; }

        [Display(Name = "消息")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Message { get; set; }

        [Display(Name = "耗时")]
        [Column(TypeName = "bigint")]
        [Editable(true)]
        public long Duration { get; set; }

        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? CreateDate { get; set; }
    }
}
