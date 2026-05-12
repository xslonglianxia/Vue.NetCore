using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Marketing
{
    [Table("mkt_levels")]
    [Entity(ApiInput = typeof(ApiMktLevelInput), ApiOutput = typeof(ApiMktLevelOutput))]
    public class MktLevel : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Display(Name = "Icon")]
        [Column(TypeName = "nvarchar(500)")]
        public string Icon { get; set; }

        [Display(Name = "MinAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinAmount { get; set; }

        [Display(Name = "MaxAmount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxAmount { get; set; }

        [Display(Name = "Discount")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Discount { get; set; }

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
