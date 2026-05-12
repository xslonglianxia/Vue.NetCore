using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_members")]
    [Entity(ApiInput = typeof(ApiMktMemberInput), ApiOutput = typeof(ApiMktMemberOutput))]
    public class MktMember : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "Username")]
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Display(Name = "Nickname")]
        [Column(TypeName = "nvarchar(100)")]
        public string Nickname { get; set; }

        [Display(Name = "Phone")]
        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [Column(TypeName = "nvarchar(200)")]
        public string Email { get; set; }

        [Display(Name = "Avatar")]
        [Column(TypeName = "nvarchar(500)")]
        public string Avatar { get; set; }

        [Display(Name = "LevelId")]
        [Column(TypeName = "bigint")]
        public long? LevelId { get; set; }

        [Display(Name = "ParentId")]
        [Column(TypeName = "bigint")]
        public long? ParentId { get; set; }

        [Display(Name = "Balance")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [Display(Name = "FrozenBalance")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FrozenBalance { get; set; }

        [Display(Name = "CommissionBalance")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CommissionBalance { get; set; }

        [Display(Name = "TotalRecharge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalRecharge { get; set; }

        [Display(Name = "TotalWithdrawal")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalWithdrawal { get; set; }

        [Display(Name = "TotalCommission")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCommission { get; set; }

        [Display(Name = "Ip")]
        [Column(TypeName = "nvarchar(100)")]
        public string Ip { get; set; }

        [Display(Name = "LastLoginTime")]
        [Column(TypeName = "datetime")]
        public DateTime? LastLoginTime { get; set; }

        [Display(Name = "LastLoginIp")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastLoginIp { get; set; }

        [Display(Name = "Status")]
        [Column(TypeName = "int")]
        public int Status { get; set; }

        [Display(Name = "RealName")]
        [Column(TypeName = "nvarchar(50)")]
        public string RealName { get; set; }

        [Display(Name = "IdCard")]
        [Column(TypeName = "nvarchar(50)")]
        public string IdCard { get; set; }

        [Display(Name = "BankName")]
        [Column(TypeName = "nvarchar(200)")]
        public string BankName { get; set; }

        [Display(Name = "BankAccount")]
        [Column(TypeName = "nvarchar(100)")]
        public string BankAccount { get; set; }

        [Display(Name = "BankBranch")]
        [Column(TypeName = "nvarchar(200)")]
        public string BankBranch { get; set; }

        [Display(Name = "InviteCode")]
        [Column(TypeName = "nvarchar(50)")]
        public string InviteCode { get; set; }

        [Display(Name = "CreateID")]
        [Column(TypeName = "int")]
        public int? CreateID { get; set; }

        [Display(Name = "Creator")]
        [Column(TypeName = "nvarchar(200)")]
        public string Creator { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "ModifyID")]
        [Column(TypeName = "int")]
        public int? ModifyID { get; set; }

        [Display(Name = "Modifier")]
        [Column(TypeName = "nvarchar(200)")]
        public string Modifier { get; set; }

        [Display(Name = "ModifyDate")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
    }
}
