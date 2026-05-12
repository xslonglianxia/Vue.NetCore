using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels.System
{
    [Table("Sys_FileReference")]
    [Entity(ApiInput = typeof(ApiSys_FileReferenceInput), ApiOutput = typeof(ApiSys_FileReferenceOutput))]
    public class Sys_FileReference : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "bigint")]
        [Required(AllowEmptyStrings = false)]
        public long Id { get; set; }

        [Display(Name = "FileId")]
        [Column(TypeName = "bigint")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public long FileId { get; set; }

        [Display(Name = "EntityType")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string EntityType { get; set; }

        [Display(Name = "EntityId")]
        [Column(TypeName = "bigint")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public long EntityId { get; set; }

        [Display(Name = "FieldName")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string FieldName { get; set; }

        [Display(Name = "Sort")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? Sort { get; set; }

        [Display(Name = "CreateID")]
        [Column(TypeName = "int")]
        public int? CreateID { get; set; }

        [Display(Name = "Creator")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Creator { get; set; }

        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? CreateDate { get; set; }
    }
}
