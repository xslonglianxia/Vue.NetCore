using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Entity.DomainModels.Points;
using VOL.System.IServices.Points;

namespace VOL.System.Controllers
{
    [Route("api/Pts_GiftOrder")]
    [PermissionTable(Name = "PtsGiftOrder")]
    public partial class Pts_GiftOrderController : ApiBaseController<IPts_GiftOrderService>
    {
        public Pts_GiftOrderController(IPts_GiftOrderService service)
        : base("Points","Points","PtsGiftOrder", service)
        {
        }
    }
}
