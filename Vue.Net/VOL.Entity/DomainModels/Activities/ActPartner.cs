using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Activities
{
    [Table("act_partners")]
    [Entity(ApiInput = typeof(ApiActPartnerInput), ApiOutput = typeof(ApiActPartnerOutput))]
    public class ActPartner : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "ActivityId")]
        [Column(TypeName = "bigint")]
        public long? ActivityId { get; set; }

        [Display(Name = "Name")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Image { get; set; }

        [Display(Name = "Link")]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        public string Link { get; set; }

        [Display(Name = "Sort")]
        [Column(TypeName = "int")]
        public int Sort { get; set; }

        [Display(Name = "Visible")]
        [Column(TypeName = "tinyint")]
        public byte Visible { get; set; }

        [Display(Name = "CreateID")]
        [Column(TypeName = "int")]
        public int? CreateID { get; set; }

        [Display(Name = "Creator")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Creator { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "ModifyID")]
        [Column(TypeName = "int")]
        public int? ModifyID { get; set; }

        [Display(Name = "Modifier")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Modifier { get; set; }

        [Display(Name = "ModifyDate")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
    }
}
