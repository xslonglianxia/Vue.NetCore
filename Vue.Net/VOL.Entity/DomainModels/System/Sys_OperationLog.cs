using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.System
{
    [Table("Sys_OperationLog")]
    [Entity(ApiInput = typeof(ApiSys_OperationLogInput), ApiOutput = typeof(ApiSys_OperationLogOutput))]
    public class Sys_OperationLog : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "UserId")]
        [Column(TypeName = "int")]
        public int? UserId { get; set; }

        [Display(Name = "UserName")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string UserName { get; set; }

        [Display(Name = "Module")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Module { get; set; }

        [Display(Name = "Action")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Action { get; set; }

        [Display(Name = "Method")]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Editable(true)]
        public string Method { get; set; }

        [Display(Name = "Url")]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        [Editable(true)]
        public string Url { get; set; }

        [Display(Name = "Ip")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Ip { get; set; }

        [Display(Name = "UserAgent")]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        [Editable(true)]
        public string UserAgent { get; set; }

        [Display(Name = "RequestData")]
        [Column(TypeName = "nvarchar(max)")]
        [Editable(true)]
        public string RequestData { get; set; }

        [Display(Name = "ResponseData")]
        [Column(TypeName = "nvarchar(max)")]
        [Editable(true)]
        public string ResponseData { get; set; }

        [Display(Name = "Duration")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? Duration { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? CreateDate { get; set; }
    }
}
