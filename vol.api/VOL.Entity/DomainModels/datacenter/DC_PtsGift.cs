using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels
{
    [Entity(TableCnName = "积分礼品", TableName = "DC_PtsGift", DBServer = "VOLContext")]
    public partial class DC_PtsGift : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "标题")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Display(Name = "图片")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Pic { get; set; }

        [Display(Name = "类型")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Kind { get; set; }

        [Display(Name = "积分")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Points { get; set; }

        [Display(Name = "价格")]
        [Column(TypeName = "decimal(18,2)")]
        [Editable(true)]
        public decimal Price { get; set; }

        [Display(Name = "礼品库存")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int GiftStock { get; set; }

        [Display(Name = "礼品可用库存")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int GiftAvailableStock { get; set; }

        [Display(Name = "礼品冻结库存")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int GiftFreezeStock { get; set; }

        [Display(Name = "礼品销量")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int GiftSaleVolume { get; set; }

        [Display(Name = "是否启用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        public bool Enabled { get; set; }

        [Display(Name = "备注")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string Remark { get; set; }

        [Display(Name = "创建人ID")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? CreateID { get; set; }

        [Display(Name = "创建人")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Creator { get; set; }

        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "修改人ID")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? ModifyID { get; set; }

        [Display(Name = "修改人")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Modifier { get; set; }

        [Display(Name = "修改时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? ModifyDate { get; set; }
    }
}
