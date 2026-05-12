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
    [Route("api/Mkt_Bulletin")]
    [PermissionTable(Name = "MktBulletin")]
    public partial class Mkt_BulletinController : ApiBaseController<IMkt_BulletinService>
    {
        public Mkt_BulletinController(IMkt_BulletinService service)
        : base("Marketing","Marketing","MktBulletin", service)
        {
        }
    }
}
