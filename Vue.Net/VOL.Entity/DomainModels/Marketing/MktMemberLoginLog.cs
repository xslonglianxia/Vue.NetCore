using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_member_login_logs")]
    [Entity(ApiInput = typeof(ApiMktMemberLoginLogInput), ApiOutput = typeof(ApiMktMemberLoginLogOutput))]
    public class MktMemberLoginLog : BaseEntity
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

        [Display(Name = "Ip")]
        [Column(TypeName = "nvarchar(100)")]
        public string Ip { get; set; }

        [Display(Name = "Location")]
        [Column(TypeName = "nvarchar(200)")]
        public string Location { get; set; }

        [Display(Name = "UserAgent")]
        [Column(TypeName = "nvarchar(1000)")]
        public string UserAgent { get; set; }

        [Display(Name = "Browser")]
        [Column(TypeName = "nvarchar(200)")]
        public string Browser { get; set; }

        [Display(Name = "Os")]
        [Column(TypeName = "nvarchar(200)")]
        public string Os { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
