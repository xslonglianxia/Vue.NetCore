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
    [Route("api/Pts_Gift")]
    [PermissionTable(Name = "PtsGift")]
    public partial class Pts_GiftController : ApiBaseController<IPts_GiftService>
    {
        public Pts_GiftController(IPts_GiftService service)
        : base("Points","Points","PtsGift", service)
        {
        }
    }
}
