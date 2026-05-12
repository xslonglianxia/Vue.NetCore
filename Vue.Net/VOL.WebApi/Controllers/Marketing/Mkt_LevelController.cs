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
    [Route("api/Mkt_Level")]
    [PermissionTable(Name = "MktLevel")]
    public partial class Mkt_LevelController : ApiBaseController<IMkt_LevelService>
    {
        public Mkt_LevelController(IMkt_LevelService service)
        : base("Marketing","Marketing","MktLevel", service)
        {
        }
    }
}
