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
    [Entity(TableCnName = "积分礼品订单", TableName = "DC_PtsGiftOrder", DBServer = "VOLContext")]
    public partial class DC_PtsGiftOrder : BaseEntity
    {
        [Key]
        [Display(Name = "主键ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "订单编号")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string OrderNo { get; set; }

        [Display(Name = "会员用户名")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string MemberUsername { get; set; }

        [Display(Name = "礼品标题")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string GiftTitle { get; set; }

        [Display(Name = "礼品图片")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string GiftPic { get; set; }

        [Display(Name = "积分")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Points { get; set; }

        [Display(Name = "收货人")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Consignee { get; set; }

        [Display(Name = "联系电话")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string Telephone { get; set; }

        [Display(Name = "收货地址")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string DeliveryAddress { get; set; }

        [Display(Name = "状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int Status { get; set; }

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
