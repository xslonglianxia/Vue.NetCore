using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_banners")]
    [Entity(ApiInput = typeof(ApiMktBannerInput), ApiOutput = typeof(ApiMktBannerOutput))]
    public class MktBanner : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "Title")]
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Display(Name = "Image")]
        [Column(TypeName = "nvarchar(500)")]
        public string Image { get; set; }

        [Display(Name = "Link")]
        [Column(TypeName = "nvarchar(1000)")]
        public string Link { get; set; }

        [Display(Name = "Sort")]
        [Column(TypeName = "int")]
        public int Sort { get; set; }

        [Display(Name = "Enable")]
        [Column(TypeName = "tinyint")]
        public byte Enable { get; set; }

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
