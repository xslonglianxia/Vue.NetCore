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
    [Entity(TableCnName = "系统用户", TableName = "DC_SysUser", DBServer = "VOLContext")]
    public partial class DC_SysUser : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "用户名")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Display(Name = "密码")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        [Display(Name = "姓名")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Name { get; set; }

        [Display(Name = "头像")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Avatar { get; set; }

        [Display(Name = "邮箱")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Email { get; set; }

        [Display(Name = "手机号")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Phone { get; set; }

        [Display(Name = "性别")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Gender { get; set; }

        [Display(Name = "组织ID")]
        [Column(TypeName = "bigint")]
        [Editable(true)]
        public long OrgId { get; set; }

        [Display(Name = "是否启用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool Enabled { get; set; }

        [Display(Name = "是否内置")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool Builtin { get; set; }

        [Display(Name = "锁定状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int LockedStatus { get; set; }

        [Display(Name = "在线状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int OnlineStatus { get; set; }

        [Display(Name = "最后登录IP")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string LastLoginIp { get; set; }

        [Display(Name = "最后登录时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? LastLoginDate { get; set; }

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
