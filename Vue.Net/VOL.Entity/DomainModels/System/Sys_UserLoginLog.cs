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
    [Table("Sys_UserLoginLog")]
    [Entity(ApiInput = typeof(ApiSys_UserLoginLogInput), ApiOutput = typeof(ApiSys_UserLoginLogOutput))]
    public class Sys_UserLoginLog : BaseEntity
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

        [Display(Name = "LoginType")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? LoginType { get; set; }

        [Display(Name = "Ip")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Ip { get; set; }

        [Display(Name = "Location")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Location { get; set; }

        [Display(Name = "UserAgent")]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        [Editable(true)]
        public string UserAgent { get; set; }

        [Display(Name = "Browser")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Browser { get; set; }

        [Display(Name = "Os")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Os { get; set; }

        [Display(Name = "Status")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? Status { get; set; }

        [Display(Name = "Message")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Message { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? CreateDate { get; set; }
    }
}
