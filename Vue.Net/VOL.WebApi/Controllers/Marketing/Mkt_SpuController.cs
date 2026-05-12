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
    [Route("api/Mkt_Spu")]
    [PermissionTable(Name = "MktSpu")]
    public partial class Mkt_SpuController : ApiBaseController<IMkt_SpuService>
    {
        public Mkt_SpuController(IMkt_SpuService service)
        : base("Marketing","Marketing","MktSpu", service)
        {
        }
    }
}
