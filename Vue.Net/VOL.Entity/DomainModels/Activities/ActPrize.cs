using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.Activities
{
    [Table("act_prizes")]
    [Entity(ApiInput = typeof(ApiActPrizeInput), ApiOutput = typeof(ApiActPrizeOutput))]
    public class ActPrize : BaseEntity
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

        [Display(Name = "Probability")]
        [Column(TypeName = "decimal(10,6)")]
        public decimal Probability { get; set; }

        [Display(Name = "Quantity")]
        [Column(TypeName = "int")]
        public int Quantity { get; set; }

        [Display(Name = "Remaining")]
        [Column(TypeName = "int")]
        public int Remaining { get; set; }

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
