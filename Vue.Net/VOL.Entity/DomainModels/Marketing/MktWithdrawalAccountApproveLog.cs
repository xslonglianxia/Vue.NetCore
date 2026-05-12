using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_withdrawal_account_approve_logs")]
    [Entity(ApiInput = typeof(ApiMktWithdrawalAccountApproveLogInput), ApiOutput = typeof(ApiMktWithdrawalAccountApproveLogOutput))]
    public class MktWithdrawalAccountApproveLog : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "MemberId")]
        [Column(TypeName = "bigint")]
        public long? MemberId { get; set; }

        [Display(Name = "Username")]
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Display(Name = "RealName")]
        [Column(TypeName = "nvarchar(50)")]
        public string RealName { get; set; }

        [Display(Name = "BankName")]
        [Column(TypeName = "nvarchar(200)")]
        public string BankName { get; set; }

        [Display(Name = "BankAccount")]
        [Column(TypeName = "nvarchar(100)")]
        public string BankAccount { get; set; }

        [Display(Name = "Status")]
        [Column(TypeName = "int")]
        public int Status { get; set; }

        [Display(Name = "ApproveUserId")]
        [Column(TypeName = "int")]
        public int? ApproveUserId { get; set; }

        [Display(Name = "ApproveUserName")]
        [Column(TypeName = "nvarchar(200)")]
        public string ApproveUserName { get; set; }

        [Display(Name = "ApproveTime")]
        [Column(TypeName = "datetime")]
        public DateTime? ApproveTime { get; set; }

        [Display(Name = "Remark")]
        [Column(TypeName = "nvarchar(500)")]
        public string Remark { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
