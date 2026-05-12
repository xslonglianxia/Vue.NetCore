using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_member_duplicate_ips")]
    [Entity(ApiInput = typeof(ApiMktMemberDuplicateIpInput), ApiOutput = typeof(ApiMktMemberDuplicateIpOutput))]
    public class MktMemberDuplicateIp : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "Ip")]
        [Column(TypeName = "nvarchar(100)")]
        public string Ip { get; set; }

        [Display(Name = "MemberCount")]
        [Column(TypeName = "int")]
        public int MemberCount { get; set; }

        [Display(Name = "MemberIds")]
        [Column(TypeName = "nvarchar(max)")]
        public string MemberIds { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
