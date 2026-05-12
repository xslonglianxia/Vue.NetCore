using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_settings")]
    [Entity(ApiInput = typeof(ApiMktSettingInput), ApiOutput = typeof(ApiMktSettingOutput))]
    public class MktSetting : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "Key")]
        [Column(TypeName = "nvarchar(200)")]
        public string Key { get; set; }

        [Display(Name = "Value")]
        [Column(TypeName = "nvarchar(max)")]
        public string Value { get; set; }

        [Display(Name = "Description")]
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        [Display(Name = "GroupName")]
        [Column(TypeName = "nvarchar(100)")]
        public string GroupName { get; set; }

        [Display(Name = "Sort")]
        [Column(TypeName = "int")]
        public int Sort { get; set; }

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
