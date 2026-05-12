using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Entity.DomainModels.Marketing;
using VOL.System.IServices.Marketing;

namespace VOL.System.Controllers
{
    [Route("api/Mkt_Banner")]
    [PermissionTable(Name = "MktBanner")]
    public partial class Mkt_BannerController : ApiBaseController<IMkt_BannerService>
    {
        public Mkt_BannerController(IMkt_BannerService service)
        : base("Marketing","Marketing","MktBanner", service)
        {
        }
    }
}
